using Microsoft.EntityFrameworkCore;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Context;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Repositories.Orders
{
    public class OrdersRepository(IShopDbContext shopDbContext) : IOrdersRepository
    {
        public async Task<Result<Order>> GetOrderByIdAsync(Guid orderId)
        {
            var product = await shopDbContext.Set<Order>()
                                    .Where(x => x.Uid == orderId)
                                    .Include(x => x.OrderProducts)
                                    .ThenInclude(cp => cp.Product)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();
            if (product is null)
            {
                return Result.NotFound<Order>("No order found!");
            }
            return Result.Ok(product);
        }

        public async Task<Result<List<Order>>> GetAllOrdersAsync(Guid userId)
        {
            var products = await shopDbContext.Set<Order>().AsNoTracking().Where(x => x.UserFk == userId).ToListAsync();
            if (products is null)
            {
                return Result.NotFound<List<Order>>("No orders found!");
            }
            return Result.Ok(products);
        }
    }
}