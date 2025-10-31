using System.Text.Json;
using AccountService.DTOs.Requests;
using AccountService.DTOs.Response;
using AccountService.Entities;
using AccountService.Interfaces.RepositoryInterfaces;
using AccountService.Interfaces.ServiceInterfaces;
using AutoMapper;

namespace AccountService.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClient;

        public UserRoleService(
            IUserRoleRepository userRoleRepository,
            IMapper mapper,
            IHttpClientFactory httpClient)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<object?> AddAsync(UserRoleRequest entity)
        {
            UserRole userRole = _mapper.Map<UserRole>(entity);
            var result = await _userRoleRepository.AddAsync(userRole);
            return result;
        }

        public Task<object> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserRoleResponse?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserRoleResponse?> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateAsync(UserRoleRequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
