using Microsoft.EntityFrameworkCore;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Context;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Repositories.Products
{
    public class ProductRepository(IShopDbContext shopDbContext) : IProductRepository
    {
        public async Task<Result<Product>> GetProductByIdAsync(Guid productId)
        {
            var product = await shopDbContext.Set<Product>()
                                    .Where(x => x.Uid == productId)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();
            if (product is null)
            {
                return Result.NotFound<Product>("No product found!");
            }
            return Result.Ok(product);
        }

        public async Task<Result<List<Product>>> GetAllProductsAsync()
        {
            var products = await shopDbContext.Set<Product>().AsNoTracking().ToListAsync();
            if (products is null)
            {
                return Result.NotFound<List<Product>>("No product found!");
            }
            return Result.Ok(products);
        }
    }
}