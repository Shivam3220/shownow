namespace ShopNow.Core.Persistence.Common.Entities
{
    public class Cart : BaseEntity
    {
        public Cart() { }

        public Guid UserFk { get; set; }
        public string Status { get; set; }
        public int TotalItem { get; set; }
        public decimal SubTotal { get; set; }
        public string Coupon { get; set; }
        public decimal Discount { get; set; }
    }
}