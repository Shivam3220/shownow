using ShopNow.Core.Persistence.Common.Repositories.Products;
using ShopNow.Core.Services.Products;

namespace ShopNow.Api.Registers
{
    public static partial class Register
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}