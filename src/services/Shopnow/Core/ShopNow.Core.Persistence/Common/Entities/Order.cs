namespace ShopNow.Core.Persistence.Common.Entities
{
    public class Order : BaseEntity
    {
        public Order() { }

        public Guid UserFk { get; set; }
        public string Status { get; set; }
        public int TotalItem { get; set; }
        public decimal SubTotal { get; set; }
        public string Coupon { get; set; }
        public decimal Discount { get; set; }

        public ICollection<OrderProductMapping> OrderProducts { get; set; } = new List<OrderProductMapping>();

        public static Order CreateNew(Guid userId, List<OrderProductMapping> orderProducts, decimal discount)
        {
            Guid orderId = Guid.NewGuid();
            return new Order
            {
                Uid = orderId,
                UserFk = userId,
                SubTotal = orderProducts.Sum(x => x.PurchasePrice * x.Quantity),
                Discount = discount,
                TotalItem = orderProducts.Sum(x => x.Quantity),
                Status = "PLACED",
                CreatedOn = DateTime.UtcNow,
                OrderProducts = orderProducts.Select(x => OrderProductMapping.CreateNew(orderId, x.ProductFk, x.Quantity, x.PurchasePrice)).ToList()
            };
        }
    }
}