using AccountService.DTOs.Requests;
using AccountService.DTOs.Response;
using AccountService.Entities;
using AccountService.Interfaces.RepositoryInterfaces;
using AccountService.Interfaces.ServiceInterfaces;
using AutoMapper;

namespace AccountService.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            this._roleRepository = roleRepository;
            this._mapper = mapper;
        }

        public async Task<object?> AddAsync(RoleCreateRequest entity)
        {
            Role role = new Role {
                Id = Guid.NewGuid().ToString("N"),
                Name = entity.Name 
            };
            var newId = await _roleRepository.AddAsync(role);
            return newId;
        }

        public Task<object> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoleResponse?>> GetAllAsync()
        {
            var roles = await _roleRepository.GellAllAsync();
            return _mapper.Map<IEnumerable<RoleResponse?>>(roles);
        }

        public async Task<RoleResponse?> GetByIdAsync(object id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            return _mapper.Map<RoleResponse?>(role);
        }

        public async Task<object?> GetByNameAsync(string roleName)
        {
            return await _roleRepository.GetByNameAsync(roleName);
        }

        public Task<object> UpdateAsync(RoleCreateRequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
