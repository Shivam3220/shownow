using ShopNow.Core.Persistence.Common.Repositories.Products;

namespace ShopNow.Api.Registers
{
    public static partial class Register
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            
            return services;
        }
    }
}