using AccountService.Entities;
using AccountService.Interfaces;
using AccountService.Interfaces.ServiceInterfaces;

namespace AccountService.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        public Task<object?> AddAsync(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<object> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role?>> GetAllAsync()
        {
            return await _roleRepository.GellAllAsync();
        }

        public Task<Role?> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateAsync(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
