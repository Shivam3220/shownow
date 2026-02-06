using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Repositories.Users
{
    public interface IUserRepository
    {
        void AddNew(User user);
        Task<Result<User>> GetByEmailAsync(string email);
        Task<Result<User>> GetByUserIdAsyncAsync(Guid userId);
    }
}