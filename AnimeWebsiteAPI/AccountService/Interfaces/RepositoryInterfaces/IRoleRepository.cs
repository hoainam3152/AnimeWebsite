using AccountService.Entities;

namespace AccountService.Interfaces.RepositoryInterfaces
{
    public interface IRoleRepository: IRepository<Role>
    {
        Task<object?> GetByNameAsync(string roleName);
        Task<IEnumerable<string>> GetUserRolesAsync(string userId);
    }
}
