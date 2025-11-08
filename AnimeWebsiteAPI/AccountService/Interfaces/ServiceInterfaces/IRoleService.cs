using AccountService.DTOs.Requests;
using AccountService.DTOs.Response;
using AccountService.Entities;

namespace AccountService.Interfaces.ServiceInterfaces
{
    public interface IRoleService: IService<RoleCreateRequest, RoleResponse>
    {
        Task<object?> GetByNameAsync(string roleName);
        Task<IEnumerable<string>> GetUserRolesAsync(string userId);
    }
}
