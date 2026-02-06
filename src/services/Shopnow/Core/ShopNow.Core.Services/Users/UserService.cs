using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;
using ShopNow.Core.Persistence.Common.Repositories.UnitOfWork;
using ShopNow.Core.Persistence.Common.Repositories.Users;
using ShopNow.Core.Services.Users;

namespace ShopNow.Core.Services.Products
{
    public class UserService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserService
    {
        public async Task<Result<User>> CreateNewUser(string name, string email, string password)
        {
            User newUser = User.CreateNew(
                name:name,
                email: email,
                password: password
            );

            Result<User> existingUser = await userRepository.GetByEmailAsync(email.ToLower());

            if(existingUser.IsFailure && !existingUser.IsNotFound)
            {
                return existingUser;
            }

            if(existingUser.IsSuccess)
            {
                return Result.Failure<User>("User already exists");
            }
            
            userRepository.AddNew(newUser);
            Result result =  await unitOfWork.SaveChangeAsync();

            if(result.IsFailure)
            {
                return Result.FromError<User>(result);
            }

            return Result.Ok(newUser);
        }

        public async Task<Result<User>> GetValidUser(string email, string password)
        {
             Result<User> existingUser = await userRepository.GetByEmailAsync(email.ToLower());

            if(existingUser.IsFailure)
            {
                return existingUser;
            }

            if(existingUser.Value.Password != password)
            {
                return Result.BadRequest<User>("Please enter valid user and password");
            }

            return existingUser;
        }
    }
}