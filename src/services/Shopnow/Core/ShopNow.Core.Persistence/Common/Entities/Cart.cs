using System.Security.Claims;
using System.Text.Json.Serialization;

namespace ShopNow.Core.Persistence.Common.Entities
{
    public class Cart : BaseEntity
    {
        public Cart() { }

        public Guid UserFk { get; set; }
        public string Status { get; set; }
        public int TotalItem { get; set; }
        public decimal SubTotal { get; set; }
        public string? Coupon { get; set; }
        public decimal Discount { get; set; }

        public ICollection<CartProductMapping> CartProducts { get; set; } = new List<CartProductMapping>();

        public void ApplyCoupon(string couponName, decimal discountAmount)
        {
            Coupon = couponName;
            Discount = discountAmount;
        }

        public static Cart CreateNew(Guid userFk)
        {
            return new Cart
            {
                Uid = Guid.NewGuid(),
                UserFk = userFk,
                Status = "ACTIVE",
                TotalItem = 0,
                SubTotal = 0
            };
        }
    }
}