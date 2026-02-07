using ShopNow.Core.Contracts.Dtos.Carts;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Services.Orders
{
    public interface IOrdersServices
    {
        Task<Result<OrderDto>> GetOrderByIdAsync(Guid orderId);
        Task<Result<List<OrderDto>>> GetAllOrdersAsync(Guid userId);
    }
}