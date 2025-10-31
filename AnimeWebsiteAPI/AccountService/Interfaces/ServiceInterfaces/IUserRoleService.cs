using AccountService.DTOs.Requests;
using AccountService.DTOs.Response;

namespace AccountService.Interfaces.ServiceInterfaces
{
    public interface IUserRoleService: IService<UserRoleRequest, UserRoleResponse>
    {
    }
}
