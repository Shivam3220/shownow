using System.Data;
using Microsoft.EntityFrameworkCore;
using ShopNow.Core.Contracts.Dtos.Carts;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Context;
using ShopNow.Core.Persistence.Common.Entities;
using ShopNow.Core.Persistence.Common.Repositories.Carts;
using ShopNow.Core.Persistence.Common.Repositories.Products;
using ShopNow.Core.Persistence.Common.Repositories.UnitOfWork;
using ShopNow.Core.Persistence.Common.Repositories.Users;

namespace ShopNow.Core.Services.Carts
{
    public class CartService(IShopDbContext shopDbContext, ICartRepository cartRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, IUserRepository userRepository) : ICartService
    {
        Dictionary<string, int> AvailableCoupon = new Dictionary<string, int>
        {
            { "FLAT50", 50 },
            { "SAVE10", 10 },
        };

        public async Task<Result<CartDto>> ApplyCoupon(Guid cartUid)
        {
            try
            {
                Result<Cart> cart = await cartRepository.GetCartByIdAsync(cartUid);
                if (cart.IsFailure)
                {
                    return Result.FromError<CartDto>(cart);
                }

                if (cart.Value.SubTotal > 1000)
                {
                    decimal discount = (cart.Value.SubTotal * AvailableCoupon["SAVE10"]) / 100;

                    if (discount > 200)
                    {
                        discount = 200;
                    }

                    cart.Value.ApplyCoupon("SAVE10", discount);

                }
                else if (cart.Value.SubTotal > 500 && cart.Value.SubTotal < 1000)
                {
                    cart.Value.ApplyCoupon("FLAT50", 50);
                }
                cartRepository.UpdateCart(cart.Value);
                Result result = await unitOfWork.SaveChangeAsync();

                if (result.IsFailure)
                {
                    return Result.FromError<CartDto>(result);
                }

                return Result.Ok(cart.Value.ToCartDto());
            }
            catch
            {
                return Result.Failure<CartDto>("Failed To Process request");
            }
        }

        public async Task<Result<CartDto>> CreateNewCart(Guid userId)
        {
            Result<User> user = await userRepository.GetByUserIdAsyncAsync(userId);

            if (user.IsFailure)
            {
                return Result.Failure<CartDto>("Invalid user id");
            }

            Result<CartDto> existingCart = await GetCartByUserIdAsync(userId);

            if (existingCart.IsFailure && !existingCart.IsNotFound)
            {
                return existingCart;
            }

            if (existingCart.IsSuccess)
            {
                return Result.Conflict<CartDto>("User already have a active cart");
            }

            Cart newCart = Cart.CreateNew(userFk: userId);
            cartRepository.CreateNew(newCart);
            Result result = await unitOfWork.SaveChangeAsync();

            if (result.IsFailure)
            {
                return Result.FromError<CartDto>(result);
            }

            return Result.Ok(newCart.ToCartDto());
        }

        public async Task<Result<CartDto>> GetCartByIdAsync(Guid cartId)
        {
            Result<Cart> cart = await cartRepository.GetCartByIdAsync(cartId, true);
            if (cart.IsFailure)
            {
                return Result.FromError<CartDto>(cart);
            }
            return Result.Ok(cart.Value.ToCartDto());

        }

        public async Task<Result<CartDto>> GetCartByUserIdAsync(Guid userId)
        {
            Result<Cart> cart = await cartRepository.GetCartByUserIdAsync(userId);
            if (cart.IsFailure)
            {
                return Result.FromError<CartDto>(cart);
            }
            return Result.Ok(cart.Value.ToCartDto());
        }

        public async Task<Result<CartDto>> UpdateCart(Guid cartId, Guid productId, int quantity)
        {
            Result<Product> product = await productRepository.GetProductByIdAsync(productId);

            if (product.IsFailure)
            {
                return Result.FromError<CartDto>(product);
            }

            if (product.Value.Stock < quantity)
            {
                return Result.Conflict<CartDto>($"Only {product.Value.Stock} left");
            }

            Result<Cart> cart = await cartRepository.GetCartByIdAsync(cartId, true);

            if (cart.IsFailure)
            {
                return Result.FromError<CartDto>(cart);
            }

            var existingItem = cart.Value.CartProducts?
                        .FirstOrDefault(cp => cp.ProductFk == productId);

            if (existingItem != null)
            {
                existingItem.Quantity = quantity;
                existingItem.PurchasePrice = product.Value.Price;
            }

            if (existingItem == null)
            {
                var newItem = CartProductMapping.CreateNew(cartId, productId, quantity, product.Value.Price);

                cart.Value.CartProducts.Add(newItem);
            }

            cart.Value.TotalItem = cart.Value.CartProducts.Sum(x => x.Quantity);
            cart.Value.SubTotal = cart.Value.CartProducts.Sum(
                                    x => x.Quantity * x.PurchasePrice
                                );

            cartRepository.UpdateCart(cart.Value);
            Result result = await unitOfWork.SaveChangeAsync();

            if (result.IsFailure)
            {
                return Result.FromError<CartDto>(result);
            }

            Result<Cart> updateCart = await cartRepository.GetCartByIdAsync(cartId, true);

            if (updateCart.IsFailure)
            {
                return Result.FromError<CartDto>(updateCart);
            }

            return Result.Ok(updateCart.Value.ToCartDto());

        }

        public async Task<Result<Guid>> CheckoutAsync(Guid userId)
        {
            var strategy = shopDbContext.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
        {
            await using var transaction =
                await shopDbContext.Database.BeginTransactionAsync();

            try
            {
                var cart = await shopDbContext.Set<Cart>()
                    .Where(x => x.UserFk == userId && x.Status == "ACTIVE")
                    .Include(x => x.CartProducts)
                        .ThenInclude(cp => cp.Product)
                    .FirstOrDefaultAsync();

                if (cart == null)
                    return Result.Failure<Guid>("Active cart not found");

                if (!cart.CartProducts.Any())
                    return Result.Failure<Guid>("Cart is empty");

                // 2️⃣ Validate stock
                foreach (var item in cart.CartProducts)
                {
                    if (item.Product.Stock < item.Quantity)
                    {
                        return Result.Failure<Guid>(
                            $"Insufficient stock for product {item.Product.Name}");
                    }
                }

                // 3️⃣ Decrease product stock
                foreach (var item in cart.CartProducts)
                {
                    item.Product.Stock -= item.Quantity;
                }

                // 4️⃣ Create order
                var order = Order.CreateNew(userId, cart.CartProducts.Select(cp => new OrderProductMapping
                {
                    ProductFk = cp.ProductFk,
                    Quantity = cp.Quantity,
                    PurchasePrice = cp.PurchasePrice,
                }).ToList(), cart.Discount);

                shopDbContext.Set<Order>().Add(order);

                // 5️⃣ Update cart status
                cart.Status = "CHECKED_OUT";

                // 6️⃣ Save all changes
                await shopDbContext.SaveChangesAsync();

                // 7️⃣ Commit transaction
                await transaction.CommitAsync();

                return Result.Ok(order.Uid);
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                return Result.Failure<Guid>("Failed to process request");
            }
        });
        }
    }
}