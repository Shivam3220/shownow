using ShopNow.Core.Contracts.Interfaces;
using ShopNow.Core.Services.Logger;

namespace ShopNow.Api.Registers
{
    public static partial class Register
    {
        public static IServiceCollection RegisterAppLogger(this IServiceCollection services)
        {
             services.AddSingleton(typeof(ILoggerService<>), typeof(LoggerService<>));
            return services;
        }
    }
}