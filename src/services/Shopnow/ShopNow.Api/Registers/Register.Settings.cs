using ShopNow.Api.Settings;
using ShopNow.Core.Contracts.Interfaces.Settings;

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