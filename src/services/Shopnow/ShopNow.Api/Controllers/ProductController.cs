using Microsoft.AspNetCore.Mvc;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;
using ShopNow.Core.Persistence.Common.Repositories.Products;
using ShopNow.Core.Services.Products;

namespace ShopNow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productRepository;

        public ProductController(IProductService productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            Result<List<Product>> products = await _productRepository.GetAllProductsAsync();
            return OkOrError(products);
        }
    }
}