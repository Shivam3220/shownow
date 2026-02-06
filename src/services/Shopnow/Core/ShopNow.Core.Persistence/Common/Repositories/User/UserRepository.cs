using Microsoft.EntityFrameworkCore;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Context;
using ShopNow.Core.Persistence.Common.Entities;

namespace ShopNow.Core.Persistence.Common.Repositories.Users
{
    public class UserRepository(IShopDbContext shopDbContext) : IUserRepository
    {
        public void AddNew(User user)
        {
            shopDbContext.Set<User>().Add(user);
        }

        public async Task<Result<User>> GetByEmailAsync(string email)
        {
            try
            {
                var user = await shopDbContext.Set<User>().Where(x => x.Email == email.ToLower()).FirstOrDefaultAsync();
    
                if(user is null)
                {
                    return Result.NotFound<User>("User not found");
                }
    
                return Result.Ok(user);
            }
            catch (Exception e)
            {
                Console.Write(e);
                return Result.Failure<User>("Failed to process request at this moment");
            }
        }
    }
}