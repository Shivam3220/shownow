using Microsoft.AspNetCore.Mvc;
using ShopNow.Core.Contracts.Dtos.Carts;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Services.Carts;

namespace ShopNow.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController(ICartService cartService) : BaseController
    {
        [HttpGet("user/{userId}/cart")]
        public async Task<IActionResult> GetActiveCart(Guid userId)
        {

            Result<CartDto> cart = await cartService.GetCartByUserIdAsync(userId: userId);

            return OkOrError(cart);
        }

        [HttpPost("user/{userId}/create-cart")]
        public async Task<IActionResult> CreateNewCart(Guid userId)
        {

            Result<CartDto> cart = await cartService.CreateNewCart(userId: userId);

            return OkOrError(cart);
        }


        [HttpPost("{cartId}/apply-coupon")]
        public async Task<IActionResult> ApplyCouponByCartIdAsync(Guid cartId)
        {

            Result<CartDto> cart = await cartService.ApplyCoupon(cartUid: cartId);

            return OkOrError(cart);
        }

        [HttpPost("{userId}/checkout")]
        public async Task<IActionResult> CheckoutCartAsync(Guid userId)
        {

            Result<Guid> cart = await cartService.CheckoutAsync(userId);

            return OkOrError(cart);
        }

        [HttpGet("{cartId}/")]
        public async Task<IActionResult> GetCartByUidAsync(Guid cartId)
        {

            Result<CartDto> cart = await cartService.GetCartByIdAsync(cartId: cartId);

            return OkOrError(cart);
        }

        [HttpPost("item")]
        public async Task<IActionResult> AddUpdateCartAsync(UpdateItemToCart request)
        {

            Result<CartDto> cart = await cartService.UpdateCart(request.CartUid, request.ProductUid, request.Quantity);

            return OkOrError(cart);
        }

    }
}