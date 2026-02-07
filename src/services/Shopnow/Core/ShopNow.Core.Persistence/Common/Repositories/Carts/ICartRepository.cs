using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Repositories.Carts
{
    public interface ICartRepository
    {
        Task<Result<Cart>> GetCartByIdAsync(Guid userId, bool includeProduct = false);
        Task<Result<Cart>> GetCartByUserIdAsync(Guid userId);
        void UpdateCart(Cart cart);
        void CreateNew(Cart cart);
    }
}