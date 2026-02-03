namespace ShopNow.Core.Persistence.Common.Entities
{
    public class CartProductMapping : BaseEntity
    {
        public CartProductMapping() { }

        public Guid CartFk { get; set; }
        public Guid ProductFk { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}