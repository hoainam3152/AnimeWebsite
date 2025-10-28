using System.Net;
using AccountService.Constants;
using AccountService.DTOs.Requests;
using AccountService.Interfaces.ServiceInterfaces;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserProfileController : BaseController
    {
        private readonly IAccountService _userService;

        public UserProfileController(IAccountService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserProfileRequest request)
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
    }
}
