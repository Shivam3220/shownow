using ShopNow.Core.Contracts.Interfaces.Settings;

namespace ShopNow.Api.Settings
{
    public class CacheSettings(IConfiguration _configuration) : ICacheSettings
    {
        public string ConnectionString => _configuration.GetValue<string>("ConnectionStrings:Redis")!;

        public string InstanceName => _configuration.GetValue<string>("Cache:Local:InstanceName")!;

    }
}