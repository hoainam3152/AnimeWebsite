using System.Net;
using AccountService.Constants;
using AccountService.DTOs.Requests;
using AccountService.Interfaces.ServiceInterfaces;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers
{
    [Route("api/v1/user-roles")]
    [ApiController]
    public class UserRoleController : BaseController
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRoleAsynce(UserRoleRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newId = await _userRoleService.AddAsync(request);
                    if (newId != null)
                    {
                        return CustomResult(ResponseMessage.CREATE_SUCCESSFUL, newId, HttpStatusCode.Created);
                    }
                    return CustomResult(ResponseMessage.CREATE_FAILED, HttpStatusCode.BadRequest);
                }
                catch (Exception ex)
                {
                    return CustomResult(
                        ResponseMessage.CREATE_FAILED + " " + ex.Message, 
                        HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
