using System.Net;
using AccountService.Constants;
using AccountService.DTOs.Requests;
using AccountService.Interfaces.ServiceInterfaces;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers
{
    [ApiController]
    [Route("api/v1/roles")]
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

        [HttpGet("id")]
        public async Task<IActionResult> GetRoleByIdAsync(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var role = await _roleService.GetByIdAsync(id);
                    if (role != null)
                    {
                        return CustomResult(ResponseMessage.SUCCESSFUL, role, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (Exception ex)
                {
                    return CustomResult(ex.Message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleAsynce(RoleCreateRequest request)
        {
            try
            {
                var role = await _roleService.AddAsync(request);
                if (role != null)
                {
                    return CustomResult(ResponseMessage.SUCCESSFUL, role, HttpStatusCode.Created);
                }
                return CustomResult(ResponseMessage.CREATE_FAILED, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("role-name")]
        public async Task<IActionResult> GetIdByRoleNameAsync(string roleName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var roleId = await _roleService.GetByNameAsync(roleName);
                    if (roleId != null)
                    {
                        return CustomResult(ResponseMessage.SUCCESSFUL, roleId, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (Exception ex)
                {
                    return CustomResult(ex.Message, HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
