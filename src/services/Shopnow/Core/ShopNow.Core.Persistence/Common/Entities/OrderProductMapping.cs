namespace ShopNow.Core.Persistence.Common.Entities
{
    public class OrderProductMapping : BaseEntity
    {
        public OrderProductMapping() { }

        public Guid OrderFk { get; set; }
        public Guid ProductFk { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

        public static OrderProductMapping CreateNew(Guid orderId, Guid productFk, int quantity, decimal purchasePrice)
        {
            return new OrderProductMapping
            {
                Uid = Guid.NewGuid(),
                OrderFk = orderId,
                ProductFk = productFk,
                Quantity = quantity,
                PurchasePrice = purchasePrice,
                CreatedOn = DateTime.Now
            };
        }
    }
}