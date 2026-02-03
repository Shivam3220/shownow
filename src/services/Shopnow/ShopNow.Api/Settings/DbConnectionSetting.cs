using ShopNow.Core.Contracts.Interfaces.Settings;

namespace ShopNow.Api.Settings
{
    public class DbConnectionSetting(IConfiguration _configuration) : IDbConnectionSetting
    {
        public string ConnectionString => _configuration.GetValue<string>("ConnectionStrings:SqlDb")!;
    }
}