using Microsoft.AspNetCore.Mvc;
using ShopNow.Core.Contracts.Dtos.Users;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;
using ShopNow.Core.Persistence.Common.Repositories.Products;
using ShopNow.Core.Services.Carts;
using ShopNow.Core.Services.Products;
using ShopNow.Core.Services.Users;

namespace ShopNow.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController(ICartService cartService) : BaseController
    {
        [HttpPost("user/{userId}/cart")]
        public async Task<IActionResult> GetActiveCart(Guid userId)
        {

            Result<Cart> cart = await cartService.GetCartByUserIdAsync(userId: userId);

            return OkOrError(cart);
        }

        [HttpPost("user/{userId}/create-cart")]
        public async Task<IActionResult> CreateNewCart(Guid userId)
        {

            Result<Cart> cart = await cartService.CreateNewCart(userId: userId);

            return OkOrError(cart);
        }

    }
}