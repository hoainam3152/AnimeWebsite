using AccountService.DTOs.Requests;
using AccountService.DTOs.Response;
using AccountService.Entities;
using AccountService.Helpers;
using AccountService.Interfaces.RepositoryInterfaces;
using AccountService.Interfaces.ServiceInterfaces;

namespace AccountService.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userRepository;
        private const int EmailExistsErrorCode = -1;
        private readonly IHttpClientFactory _httpClientFactory;

        public UserProfileService(
            IUserProfileRepository userRepository
            , IHttpClientFactory httpClientFactory)
        {
            this._userRepository = userRepository;
            _httpClientFactory = httpClientFactory;
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
                //Id = Guid.NewGuid().ToString(),
                Id = SequentialGuid.Generate().ToString(),
                UserName = entity.UserName,
                Email = entity.Email,
                PasswordHash = passwordHash,
                PhoneNumber = entity.PhoneNumber
            };

            var result = await _userRepository.AddAsync(newUser);

            if (result != null)
            {
                HttpClient client = _httpClientFactory.CreateClient("UserRole");
            }

            return result;
        }

        public Task<object> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserProfileResponse?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserProfileResponse?> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateAsync(UserProfileRequest entity)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> Authentication(string email, string password)
        {
            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null)
            {
                return String.Empty;
            }

            bool isPasswordValid = Pbkdf2Hasher.VerifyPassword(password, user.PasswordHash);
            if (!isPasswordValid)
            {
                return String.Empty;
            }

            return user.Id;
        }
    }
}
