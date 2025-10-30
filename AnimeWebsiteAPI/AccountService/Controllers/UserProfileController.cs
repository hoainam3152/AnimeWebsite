using System.Net;
using AccountService.Constants;
using AccountService.DTOs.Requests;
using AccountService.Interfaces.ServiceInterfaces;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using RepoDb.Extensions;

namespace AccountService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserProfileController : BaseController
    {
        private readonly IUserProfileService _userService;

        public UserProfileController(IUserProfileService userService)
        {
            this._userService = userService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserProfileRequest request)
        {
            try
            {
                var result = await _userService.AddAsync(request);

                if (result == null)
                {
                    return CustomResult(ResponseMessage.CREATE_FAILED, HttpStatusCode.BadRequest);
                }

                if (result.Equals(-1))
                {
                    return CustomResult("Email is existed", HttpStatusCode.Conflict);
                }

                return CustomResult(ResponseMessage.CREATE_SUCCESSFUL, result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            try
            {
                var result = await _userService.Authentication(email, password);

                if (result.IsNullOrEmpty())
                {
                    return CustomResult("Email hoặc mật khẩu không đúng", HttpStatusCode.BadRequest);
                }

                return CustomResult(ResponseMessage.SIGNIN_SUCCESSFUL, result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
