namespace ShopNow.Core.Persistence.Common.Entities
{
    public class User : BaseEntity
    {
        public User() { }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}