using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopNow.Core.Contracts.Dtos.Carts
{
    public class CartDto
    {
        public Guid CartUid { get; set; }
        public string Status { get; set; }
        public int TotalItem { get; set; }
        public decimal SubTotal { get; set; }
        public string? Coupon { get; set; }
        public decimal Discount { get; set; }
        public List<CartItemDto> Items { get; set; }
    }

    public class CartItemDto
    {
        public Guid ProductUid { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

}