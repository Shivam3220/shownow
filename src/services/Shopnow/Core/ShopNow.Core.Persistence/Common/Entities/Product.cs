namespace ShopNow.Core.Persistence.Common.Entities
{
    public class Product : BaseEntity
    {
        public Product() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public Decimal Price { get; set; }
        public int Stock { get; set; }

        public ICollection<CartProductMapping> CartProducts { get; set; }
    }
}