using Microsoft.Extensions.Caching.StackExchangeRedis;
using ShopNow.Api.Settings;
using ShopNow.Core.Contracts.Interfaces;
using ShopNow.Core.Contracts.Interfaces.Settings;
using ShopNow.Core.Services.Cache;

namespace ShopNow.Api.Registers
{
    public static partial class Register
    {
        public static IServiceCollection RegisterCaching(this IServiceCollection services, IConfiguration configuration)
        {
            ICacheSettings cacheSettings = new CacheSettings(configuration);

            services.AddSingleton<ICacheService>(x => new CacheService(new RedisCache(new RedisCacheOptions
            {
                Configuration = cacheSettings.ConnectionString,
                InstanceName = cacheSettings.InstanceName
            }), x.GetRequiredService<ILoggerService<CacheService>>()));

            return services;
        } 
    }
}