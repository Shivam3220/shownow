using ShopNow.Core.Contracts.Dtos.Carts;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Services.Carts
{
    public static class CartDtoFactory
    {
        public static CartDto ToCartDto(this Cart cart)
        {
            return new CartDto
            {
                CartUid = cart.Uid,
                Status = cart.Status,
                SubTotal = cart.SubTotal,
                Discount = cart.Discount,
                Coupon = cart.Coupon,
                Items = cart.CartProducts.Select(cp => new CartItemDto
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