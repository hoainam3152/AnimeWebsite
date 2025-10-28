using AccountService.DTOs.Requests;
using AccountService.Entities;
using AccountService.Helpers;
using AccountService.Interfaces;
using AccountService.Interfaces.RepositoryInterfaces;
using AccountService.Interfaces.ServiceInterfaces;

namespace AccountService.Services
{
    public class UserProfileService : IAccountService
    {
        private readonly IUserProfileRepository _userRepository;
        private const int EmailExistsErrorCode = -1;

        public UserProfileService(IUserProfileRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<object?> AddAsync(UserProfileRequest entity)
        {
            bool isEmailExisting = await _userRepository.IsEmailExistAsync(entity.Email);

            if (isEmailExisting)
            {
                return EmailExistsErrorCode;
            }

            string passwordHash = Pbkdf2Hasher.HashPassword(entity.Password);

            UserProfile newUser = new UserProfile
            {
                Id = Guid.NewGuid().ToString(),
                UserName = entity.UserName,
                Email = entity.Email,
                PasswordHash = passwordHash,
                PhoneNumber = entity.PhoneNumber
            };

            var result = await _userRepository.AddAsync(newUser);

            if (result != null)
            {
                //thêm vai trò
            }

            return result;
        }

        public Task<object> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserProfileRequest?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserProfileRequest?> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateAsync(UserProfileRequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
