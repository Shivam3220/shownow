using ShopNow.Core.Contracts.Dtos.Carts;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;
using ShopNow.Core.Persistence.Common.Repositories.Orders;
using ShopNow.Core.Services.Carts;

namespace ShopNow.Core.Services.Orders
{
    public class OrdersServices(IOrdersRepository repository) : IOrdersServices
    {
        public async Task<Result<OrderDto>> GetOrderByIdAsync(Guid orderId)
        {
            try
            {
                Result<Order> cart = await repository.GetOrderByIdAsync(orderId);
                if (cart.IsFailure)
                {
                    return Result.FromError<OrderDto>(cart);
                }
                return Result.Ok(cart.Value.ToOrderDto());
            }
            catch
            {
                return Result.Failure<OrderDto>("Failed To Process request");
            }
        }

        public async Task<Result<List<OrderDto>>> GetAllOrdersAsync(Guid userId)
        {
            try
            {
                Result<List<Order>> cart = await repository.GetAllOrdersAsync(userId);
                if (cart.IsFailure)
                {
                    return Result.FromError<List<OrderDto>>(cart);
                }
                return Result.Ok(cart.Value.Select(x => x.ToOrderDto()).ToList());
            }
            catch
            {
                return Result.Failure<List<OrderDto>>("Failed To Process request");
            }
        }
    }
}