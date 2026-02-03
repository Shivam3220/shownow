using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Services.Products
{
    public interface IProductService
    {
        Task<Result<List<Product>>> GetAllProductsAsync();
    }
}