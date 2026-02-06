using ShopNow.Core.Persistence.Common.Repositories.Carts;
using ShopNow.Core.Persistence.Common.Repositories.Products;
using ShopNow.Core.Persistence.Common.Repositories.UnitOfWork;
using ShopNow.Core.Persistence.Common.Repositories.Users;
using ShopNow.Core.Services.Carts;
using ShopNow.Core.Services.Products;
using ShopNow.Core.Services.Users;

namespace ShopNow.Api.Registers
{
    public static partial class Register
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICartService, CartService>();

            return services;
        }
    }
}