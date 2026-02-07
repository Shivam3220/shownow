using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Repositories.Orders
{
    public interface IOrdersRepository
    {
        Task<Result<Order>> GetOrderByIdAsync(Guid orderId);
        Task<Result<List<Order>>> GetAllOrdersAsync(Guid userId);
    }
}