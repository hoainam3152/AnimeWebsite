using System.Net;
using AccountService.Constants;
using AccountService.Interfaces.ServiceInterfaces;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            try
            {
                var roles = await _roleService.GetAllAsync();
                if (roles.Any())
                {
                    return CustomResult(ResponseMessage.SUCCESSFUL, roles, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
