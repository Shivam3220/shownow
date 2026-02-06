using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<Result> SaveChangeAsync();

         Task<Result> SaveChangesAsTransactionAsync(Func<Task> action);
    }
}