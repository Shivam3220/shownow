using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Repositories.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
    }
}