namespace ShopNow.Core.Contracts.Dtos.Carts
{
    public class UpdateItemToCart
    {
        public int Quantity { get; set; }
        public Guid ProductUid { get; set; }
        public Guid CartUid { get; set; }
    }
}