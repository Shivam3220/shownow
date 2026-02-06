using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Context;

namespace ShopNow.Core.Persistence.Common.Repositories.UnitOfWork
{
    public class UnitOfWork(IShopDbContext shopDbContext) : IUnitOfWork
    {
        public async Task<Result> SaveChangeAsync()
        {
            try
            {
                await shopDbContext.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return Result.Failure("Failed to save to db");
            }
        }

        public async Task<Result> SaveChangesAsTransactionAsync(Func<Task> action)
        {
            return await shopDbContext.SaveChangesAsTransactionAsync(action);
        }
    }
}