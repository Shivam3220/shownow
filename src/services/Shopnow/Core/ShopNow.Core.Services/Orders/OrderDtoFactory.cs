using ShopNow.Core.Contracts.Dtos.Carts;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Services.Carts
{
    public static class OrderDtoFactory
    {
        public static OrderDto ToOrderDto(this Order cart)
        {
            return new OrderDto
            {
                OrderUid = cart.Uid,
                Status = cart.Status,
                SubTotal = cart.SubTotal,
                Discount = cart.Discount,
                TotalItem = cart.TotalItem,
                Coupon = cart.Coupon,
                Items = cart.OrderProducts.Select(cp => new OrderItemDto
                {
                    ProductUid = cp.Product.Uid,
                    ProductName = cp.Product.Name,
                    Price = cp.PurchasePrice,
                    Quantity = cp.Quantity
                }).ToList()
            };
        }
    }
}