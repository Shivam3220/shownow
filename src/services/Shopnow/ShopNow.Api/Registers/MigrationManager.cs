using Microsoft.EntityFrameworkCore;
using ShopNow.Core.Persistence.Common.Context;

public static class MigrationManager
{
    public static void MigrateDatabase(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ShopDbContext>();

        for (int i = 0; i < 10; i++)
        {
            try
            {
                db.Database.Migrate();
                break;
            }
            catch
            {
                Thread.Sleep(3000);
            }
        }
    }
}
