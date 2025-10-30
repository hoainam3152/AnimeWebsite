using AccountService.Entities;

namespace AccountService.Interfaces.RepositoryInterfaces
{
    public interface IUserProfileRepository: IRepository<UserProfile>
    {
        Task<bool> IsEmailExistAsync(string email);
        Task<UserProfile?> FindByEmailAsync(string email);
    }
}
