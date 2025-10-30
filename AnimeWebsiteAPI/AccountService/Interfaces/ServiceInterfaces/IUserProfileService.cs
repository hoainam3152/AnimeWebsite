using AccountService.DTOs.Requests;
using AccountService.DTOs.Response;

namespace AccountService.Interfaces.ServiceInterfaces
{
    public interface IUserProfileService: IService<UserProfileRequest, UserProfileResponse>
    {
        Task<string?> Authentication(string email, string password);
    }
}
