using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
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
using Microsoft.IdentityModel.Tokens;

namespace AccountService.Services
{
    public class UserProfileService : IUserProfileService
    {
        private const int EmailExistsErrorCode = -1;

        private readonly IUserProfileRepository _userRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IRoleService _roleService;

        public UserProfileService(
            IUserProfileRepository userRepository, 
            IHttpClientFactory httpClientFactory,
            IMapper mapper,
            IConfiguration configuration,
            IRoleService roleService)
        {
            _userRepository = userRepository;
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _configuration = configuration;
            _roleService = roleService;
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
                    var roleId = await _roleService.GetByNameAsync(ApplicationRoles.User);
                    if (roleId == null)
                    {
                        throw new Exception("Role default not found and cancel register account");
                    }

                    var postData = new Dictionary<string, string>
                        {
                            { "userId", newId },
                            { "roleId", roleId.ToString() }
                        };

                    HttpClient client = _httpClientFactory.CreateClient("Account");
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

            return await GenerateJwtToken(user);
        }

        private async Task<string> GenerateJwtToken(UserProfile user)
        {
            // Create Payload
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            //Find and create roles claims
            var userRoles = await _roleService.GetUserRolesAsync(user.Id);
            foreach (string role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //Create Signature Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //Create Token Descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(30),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = creds
            };


            //Create Token and return JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
