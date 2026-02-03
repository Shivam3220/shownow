using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Repositories.Products
{
    public interface IProductRepository
    {
        Task<Result<Product>> GetProductByIdAsync(Guid productId);
        Task<Result<List<Product>>> GetAllProductsAsync();
    }
}