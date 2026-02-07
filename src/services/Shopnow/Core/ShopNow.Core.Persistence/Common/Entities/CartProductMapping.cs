namespace ShopNow.Core.Persistence.Common.Entities
{
    public class CartProductMapping : BaseEntity
    {
        public CartProductMapping() { }

        public Guid CartFk { get; set; }
        public Guid ProductFk { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }

        public static CartProductMapping CreateNew(Guid cartUid, Guid productUid, int quantity, decimal productPrice)
        {
            return new CartProductMapping
            {
                Uid = Guid.NewGuid(),
                CartFk = cartUid,
                ProductFk = productUid,
                Quantity = quantity,
                PurchasePrice = productPrice,
                CreatedOn = DateTime.UtcNow
            };
        }
    }
}