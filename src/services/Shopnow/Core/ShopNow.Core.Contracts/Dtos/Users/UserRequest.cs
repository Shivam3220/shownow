using ShopNow.Core.Contracts.Results;

namespace ShopNow.Core.Contracts.Dtos.Users
{
    public class UserRegisterRequest
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public virtual Result<bool> ValidateDto()
        {
            if(string.IsNullOrEmpty(Name))
            {
                return Result.Failure<bool>("Name cannot be empty");
            }
            if(string.IsNullOrEmpty(Email))
            {
                return Result.Failure<bool>("Email cannot be empty");
            }
            if(string.IsNullOrEmpty(Password))
            {
                return Result.Failure<bool>("Password cannot be empty");
            }

            return Result.Ok(true);
        }
    }

    public class UserLogInRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }

        public virtual Result<bool> ValidateDto()
        {
            if(string.IsNullOrEmpty(Email))
            {
                return Result.Failure<bool>("Email cannot be empty");
            }
            if(string.IsNullOrEmpty(Password))
            {
                return Result.Failure<bool>("Password cannot be empty");
            }

            return Result.Ok(true);
        }
    }
}