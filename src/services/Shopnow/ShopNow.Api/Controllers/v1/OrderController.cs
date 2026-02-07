using Microsoft.AspNetCore.Mvc;
using ShopNow.Core.Contracts.Dtos.Carts;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Services.Orders;

namespace ShopNow.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController(IOrdersServices services) : BaseController
    {
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetActiveCart(Guid userId)
        {

            Result<List<OrderDto>> cart = await services.GetAllOrdersAsync(userId);

            return OkOrError(cart);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderByOrderIdAsync(Guid orderId)
        {

            Result<OrderDto> cart = await services.GetOrderByIdAsync(orderId);

            return OkOrError(cart);
        }

    }
}