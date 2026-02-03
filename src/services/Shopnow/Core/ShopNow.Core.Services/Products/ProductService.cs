using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;
using ShopNow.Core.Persistence.Common.Repositories.Products;

namespace ShopNow.Core.Services.Products
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<Result<List<Product>>> GetAllProductsAsync()
        {
            try
            {
                return await productRepository.GetAllProductsAsync();
            }
            catch
            {
                return Result.Failure<List<Product>>("Failed To Process request");
            }
        }
    }
}