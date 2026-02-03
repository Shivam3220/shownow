using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;
using ShopNow.Core.Persistence.Common.Repositories.Orders;

namespace ShopNow.Core.Services.Orders
{
    public class OrdersServices(IOrdersRepository repository) : IOrdersServices
    {
        public async Task<Result<Order>> GetOrderByIdAsync(Guid orderId)
        {
            try
            {
                return await repository.GetOrderByIdAsync(orderId);
            }
            catch
            {
                return Result.Failure<Order>("Failed To Process request");
            }
        }

        public async Task<Result<List<Order>>> GetAllOrdersAsync()
        {
             try
            {
                return await repository.GetAllOrdersAsync();
            }
            catch
            {
                return Result.Failure<List<Order>>("Failed To Process request");
            }
        }
    }
}