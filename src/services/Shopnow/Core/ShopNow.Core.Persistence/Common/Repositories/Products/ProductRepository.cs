using Microsoft.EntityFrameworkCore;
using ShopNow.Core.Persistence.Common.Context;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Repositories.Products
{
    public class ProductRepository(IShopDbContext shopDbContext) : IProductRepository
    {
        public async Task<List<Product>> GetAllProducts()
        {
            return await shopDbContext.Set<Product>().AsNoTracking().ToListAsync();
        }
    }
}