
using ShopNow.Api.Registers;
using ShopNow.Core.Services.Logger;

namespace ShopNow.Api;

public class Program
{
    public static void Main(string[] args)
    {

        LoggerService<Program> logger = new LoggerService<Program>();

        try
        {
            RunApplication(BuildApplication(WebApplication.CreateBuilder(args)));
        }
        catch (Exception ex)
        {
            logger.LogTerminateApp(ex);
        }
    }

    private static WebApplication BuildApplication(WebApplicationBuilder builder)
    {
        builder.Services
            .AddSingleton(builder.Environment)
            .RegisterAppLogger()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .RegisterSettings()
            .RegisterCaching(builder.Configuration)
            .RegisterDatabase(builder.Configuration)
            .RegisterServices()
            .RegisterControllers();

        builder.Services.AddCors(options =>
{
options.AddPolicy("AllowAll", policy =>
{
    policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});
});

        return builder.Build();
    }

    private static void RunApplication(WebApplication app)
    {
        MigrationManager.MigrateDatabase(app.Services);
        app.UseCors("AllowAll");

        app
            .UseRouting()
            .UseSwagger()
            .UseSwaggerUI()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        app.Run();
    }
}
