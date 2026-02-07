using ShopNow.Core.Contracts.Dtos.Carts;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Services.Carts
{
    public interface ICartService
    {
        Task<Result<CartDto>> GetCartByIdAsync(Guid cartId);
        Task<Result<CartDto>> GetCartByUserIdAsync(Guid userId);
        Task<Result<CartDto>> ApplyCoupon(Guid cartUid);
        Task<Result<CartDto>> CreateNewCart(Guid userId);
        Task<Result<CartDto>> UpdateCart(Guid cartId, Guid productId, int quantity);
    }
}