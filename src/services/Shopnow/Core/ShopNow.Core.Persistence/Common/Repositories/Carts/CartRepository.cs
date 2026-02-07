using Microsoft.EntityFrameworkCore;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Context;
using ShopNow.Core.Persistence.Common.Entities;
using ShopNow.Core.Persistence.Common.Repositories.UnitOfWork;

namespace ShopNow.Core.Persistence.Common.Repositories.Carts
{
    public class CartRepository(IShopDbContext shopDbContext) : ICartRepository
    {
        public void CreateNew(Cart cart)
        {
            shopDbContext.Set<Cart>().Add(cart);
        }

        public async Task<Result<Cart>> GetCartByIdAsync(Guid productId)
        {
            try
            {
                Cart? cart = await shopDbContext.Set<Cart>()
                                                .AsNoTracking()
                                                .Where(x => x.Uid == productId)
                                                .FirstOrDefaultAsync();
                if (cart is null)
                {
                    return Result.NotFound<Cart>("Cart not found");
                }
    
                return Result.Ok(cart);
            }
            catch (System.Exception ex)
            {
                 Console.Write(ex);
                return Result.Failure<Cart>("Failed to process request at this moment");
            }
        }

        public async Task<Result<Cart>> GetCartByUserIdAsync(Guid userId)
        {
            try
            {
                Cart? cart = await shopDbContext.Set<Cart>()
                                            .AsNoTracking()
                                            .Where(x => x.UserFk == userId)
                                            .Where(x => x.Status == "ACTIVE")
                                            .FirstOrDefaultAsync();
                if (cart is null)
                {
                    return Result.NotFound<Cart>("Cart not found");
                }

                return Result.Ok(cart);
            }
            catch (System.Exception ex)
            {
                Console.Write(ex);
                return Result.Failure<Cart>("Failed to process request at this moment");
            }
        }

        public void UpdateCart(Cart cart)
        {
            shopDbContext.Set<Cart>().Update(cart);
        }
    }
}