using Microsoft.EntityFrameworkCore;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Context;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Repositories.Carts
{
    public class CartRepository(IShopDbContext shopDbContext) : ICartRepository
    {
        public async Task<Result<Cart>> GetCartByIdAsync(Guid productId)
        {
            Cart? cart = await shopDbContext.Set<Cart>()
                                            .AsNoTracking()
                                            .Where(x => x.Uid == productId)
                                            .FirstOrDefaultAsync();
            if(cart is null)
            {
                return Result.NotFound<Cart>("Cart not found");
            }

            return Result.Ok(cart);
        }

        public async Task<Result<bool>> UpdateCartById(Cart cart)
        {
            shopDbContext.Set<Cart>().Update(cart);
            await shopDbContext.SaveChangesAsync();
            return Result.Ok(true);
        }
    }
}