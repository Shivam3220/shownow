using Microsoft.EntityFrameworkCore;
using ShopNow.Core.Contracts.Results;

namespace ShopNow.Core.Persistence.Common.Context
{
    public class ShopDbContext : DbContext, IShopDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);
        }

        public void HealthCheck()
        {
            Database.OpenConnection();
            Database.CloseConnection();
        }

        public async Task<Result> SaveChangesAsTransactionAsync(Func<Task> action)
        {
            var strategy = Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                if (Database.CurrentTransaction != null)
                {
                    await action();
                    return Result.Ok();
                }

                await using var transaction = await Database.BeginTransactionAsync();

                try
                {
                    await action();
                    await transaction.CommitAsync();
                    return Result.Ok();
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    await transaction.RollbackAsync();
                    return Result.Failure("FAILED_TO_PROCESS_REQUEST");
                }
            });
        }

    }
}