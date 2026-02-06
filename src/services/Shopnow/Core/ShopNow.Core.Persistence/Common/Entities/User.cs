namespace ShopNow.Core.Persistence.Common.Entities
{
    public class User : BaseEntity
    {
        public User() { }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public static User CreateNew(string name, string email, string password)
        {
            return new User
            {
                Uid = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Name = name.ToLower(),
                Email = email.ToLower(),
                Password = password
            };
        }
    }
}