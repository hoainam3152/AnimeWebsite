using System.Net.Mime;
using System.Text;
using System.Text.Json;
using AccountService.Constants;
using AccountService.DTOs.Requests;
using AccountService.DTOs.Response;
using AccountService.Entities;
using AccountService.Helpers;
using AccountService.Interfaces.RepositoryInterfaces;
using AccountService.Interfaces.ServiceInterfaces;
using AutoMapper;

namespace AccountService.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userRepository;
        private const int EmailExistsErrorCode = -1;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public UserProfileService(
            IUserProfileRepository userRepository, 
            IHttpClientFactory httpClientFactory,
            IMapper mapper)
        {
            this._userRepository = userRepository;
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<object?> AddAsync(UserProfileRequest entity)
        {
            bool isEmailExisting = await _userRepository.IsEmailExistAsync(entity.Email);

            if (isEmailExisting)
            {
                return EmailExistsErrorCode;
            }

            string passwordHash = Pbkdf2Hasher.HashPassword(entity.Password);
            string newId = Guid.NewGuid().ToString();

            UserProfile newUser = new UserProfile
            {
                Id = newId,
                //Id = SequentialGuid.Generate().ToString(),
                UserName = entity.UserName,
                Email = entity.Email,
                PasswordHash = passwordHash,
                PhoneNumber = entity.PhoneNumber
            };

            var result = await _userRepository.AddAsync(newUser);

            if (result != null)
            {
                try
                {
                    HttpClient client = _httpClientFactory.CreateClient("Account");

                    ApiResponse? role = await client.GetFromJsonAsync<ApiResponse>(
                        $"api/v1/roles/role-name?roleName={ApplicationRoles.User}",
                        new JsonSerializerOptions(JsonSerializerDefaults.Web)
                        );
                    if (role == null || role.Data == null)
                    {
                        throw new Exception("Default role not found and cancel register account");
                    }

                    var postData = new Dictionary<string, string>
                    {
                        { "userId", newId },
                        { "roleId", role.Data.ToString() }
                    };

                    using StringContent json = new(
                        JsonSerializer.Serialize(
                            postData,
                            new JsonSerializerOptions(JsonSerializerDefaults.Web)
                            ),
                            Encoding.UTF8,
                            MediaTypeNames.Application.Json
                        );
                    using HttpResponseMessage httpResponse = await client.PostAsync("/api/v1/user-roles", json);

                    httpResponse.EnsureSuccessStatusCode();
                }
                catch (Exception)
                {
                    await DeleteAsync(newUser.Id);
                    throw;
                }
            }

            return result;
        }

        public async Task<object> DeleteAsync(object id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserProfileResponse?>> GetAllAsync()
        {
            var users = await _userRepository.GellAllAsync();
            return _mapper.Map<IEnumerable<UserProfileResponse>>(users);
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
