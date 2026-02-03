using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Services.Orders
{
    public interface IOrdersServices
    {
        Task<Result<Order>> GetOrderByIdAsync(Guid orderId);
        Task<Result<List<Order>>> GetAllOrdersAsync();
    }
}