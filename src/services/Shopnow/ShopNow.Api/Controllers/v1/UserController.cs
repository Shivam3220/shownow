using Microsoft.AspNetCore.Mvc;
using ShopNow.Core.Contracts.Dtos.Users;
using ShopNow.Core.Contracts.Results;
using ShopNow.Core.Persistence.Common.Entities;
using ShopNow.Core.Persistence.Common.Repositories.Products;
using ShopNow.Core.Services.Products;
using ShopNow.Core.Services.Users;

namespace ShopNow.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController(IUserService userService) : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> CreateNew(UserRegisterRequest userRegisterRequest)
        {
            Result<bool> validateModal = userRegisterRequest.ValidateDto();

            if(validateModal.IsFailure)
            {
                return OkOrError(validateModal);
            }

            Result<User> user = await userService.CreateNewUser(userRegisterRequest.Name, userRegisterRequest.Email, userRegisterRequest.Password);

            return OkOrError(user);
        }


        [HttpPost("signIn")]
        public async Task<IActionResult> LoginUser(UserLogInRequest userRegisterRequest)
        {
            Result<bool> validateModal = userRegisterRequest.ValidateDto();

            if(validateModal.IsFailure)
            {
                return OkOrError(validateModal);
            }

            Result<User> user = await userService.GetValidUser(userRegisterRequest.Email, userRegisterRequest.Password);

            return OkOrError(user);
        }
    }
}