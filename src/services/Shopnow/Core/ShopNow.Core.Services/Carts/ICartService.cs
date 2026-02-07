using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Services.Carts
{
    public interface ICartService
    {
        Task<Result<Cart>> GetCartByIdAsync(Guid cartId);
        Task<Result<Cart>> GetCartByUserIdAsync(Guid userId);
        Task<Result<Cart>> ApplyCoupon(Guid cartUid);
        Task<Result<Cart>> CreateNewCart(Guid userId);
    }
}