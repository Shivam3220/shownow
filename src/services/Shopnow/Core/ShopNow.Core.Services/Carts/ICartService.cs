using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Services.Carts
{
    public interface ICartService
    {
        Task<Result<Cart>> GetCartByIdAsync(Guid productId);
        Task<Result<bool>> ApplyCoupon(Guid productId);
    }
}