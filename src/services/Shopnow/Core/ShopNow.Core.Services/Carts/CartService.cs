using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;
using ShopNow.Core.Persistence.Common.Repositories.Carts;
using ShopNow.Core.Persistence.Common.Repositories.UnitOfWork;
using ShopNow.Core.Persistence.Common.Repositories.Users;

namespace ShopNow.Core.Services.Carts
{
    public class CartService(ICartRepository cartRepository, IUnitOfWork unitOfWork, IUserRepository userRepository) : ICartService
    {
        Dictionary<string, int> AvailableCoupon = new Dictionary<string, int>
        {
            { "FLAT50", 50 },
            { "SAVE10", 10 },
        };

        public async Task<Result<Cart>> ApplyCoupon(Guid cartUid)
        {
            try
            {
                Result<Cart> cart = await cartRepository.GetCartByIdAsync(cartUid);
                if (cart.IsFailure)
                {
                    return Result.FromError<Cart>(cart);
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
                    return Result.FromError<Cart>(result);
                }

                return Result.Ok(cart.Value);
            }
            catch
            {
                return Result.Failure<Cart>("Failed To Process request");
            }
        }

        public async Task<Result<Cart>> CreateNewCart(Guid userId)
        {
            Result<User> user = await userRepository.GetByUserIdAsyncAsync(userId);

            if (user.IsFailure)
            {
                return Result.Failure<Cart>("Invalid user id");
            }

            Result<Cart> existingCart = await GetCartByUserIdAsync(userId);

            if (existingCart.IsFailure && !existingCart.IsNotFound)
            {
                return existingCart;
            }

            if (existingCart.IsSuccess)
            {
                return Result.Conflict<Cart>("User already have a active cart");
            }

            Cart newCart = Cart.CreateNew(userFk: userId);
            cartRepository.CreateNew(newCart);
            Result result = await unitOfWork.SaveChangeAsync();

            if (result.IsFailure)
            {
                return Result.FromError<Cart>(result);
            }

            return Result.Ok(newCart);
        }

        public async Task<Result<Cart>> GetCartByIdAsync(Guid cartId)
        {
            return await cartRepository.GetCartByIdAsync(cartId);

        }

        public async Task<Result<Cart>> GetCartByUserIdAsync(Guid userId)
        {
            return await cartRepository.GetCartByUserIdAsync(userId);
        }
    }
}