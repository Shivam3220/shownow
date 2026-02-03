using Microsoft.EntityFrameworkCore;
using ShopNow.Api.Settings;
using ShopNow.Core.Persistence.Common.Context;

namespace ShopNow.Api.Registers
{
    public static partial class Register
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            DbConnectionSetting settings = new DbConnectionSetting(configuration);

            services.AddScoped<IShopDbContext, ShopDbContext>()
                    .AddDbContext<ShopDbContext>(options =>
                    {
                        options.UseSqlServer(settings.ConnectionString,
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly("ShopNow.Core.Persistence");
                            sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(15),
                            errorNumbersToAdd: null);
                        });
                    });

            return services;
        }
    }
}