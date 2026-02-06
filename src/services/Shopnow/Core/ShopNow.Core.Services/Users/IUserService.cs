using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Services.Users
{
    public interface IUserService
    {
        Task<Result<User>> CreateNewUser(string name, string email, string password);
        Task<Result<User>> GetValidUser(string email, string password);
    }
}