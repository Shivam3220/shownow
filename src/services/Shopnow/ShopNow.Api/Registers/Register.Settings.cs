using ShopNow.Api.Settings;
using ShopNow.Core.Contracts.Interfaces.Settings;
using ShopNow.Core.Persistence.Common.Repositories.UnitOfWork;
using ShopNow.Core.Persistence.Common.Repositories.Users;
using ShopNow.Core.Services.Products;
using ShopNow.Core.Services.Users;

namespace ShopNow.Api.Registers
{
    public static partial class Register
    {
        public static IServiceCollection RegisterSettings(this IServiceCollection services)
        {
            services.AddSingleton<ICacheSettings, CacheSettings>();

            return services;
        }
    }
}