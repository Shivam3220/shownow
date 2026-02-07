using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ShopNow.Core.Contracts.Results;

namespace ShopNow.Core.Persistence.Common.Context
{
    public interface IShopDbContext: IDisposable
    {
        /// <summary>
        /// Gets a DbSet for the specified entity type.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// Gets the EntityEntry for the given entity.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Saves all changes made in this context to the database asynchronously.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Performs a health check on the database connection.
        /// </summary>
        void HealthCheck();

        /// <summary>
        /// Executes the provided action within a database transaction.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<Result> SaveChangesAsTransactionAsync(Func<Task> action);

        DatabaseFacade Database {get; }
    }
}