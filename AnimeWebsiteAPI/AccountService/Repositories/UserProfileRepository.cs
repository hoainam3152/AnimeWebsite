using AccountService.Entities;
using AccountService.Interfaces;
using AccountService.Interfaces.RepositoryInterfaces;
using RepoDb;

namespace AccountService.Repositories
{
    public class UserProfileRepository: IUserProfileRepository  
    {
        private readonly IDatabase _database;

        public UserProfileRepository(IDatabase database)
        {
            this._database = database;
        }

        public async Task<object> AddAsync(UserProfile entity)
        {
            using (var connection = _database.Connect())
            {
                var newId = await connection.InsertAsync(entity);
                return newId; 
            }
        }

        public Task<object> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            using (var connection = _database.Connect())
            {
                var exists = await connection.ExistsAsync<UserProfile>(user => user.Email == email);
                return exists;
            }
        }

        public async Task<IEnumerable<UserProfile?>> GellAllAsync()
        {
            using (var connection = _database.Connect())
            {
                return await connection.QueryAllAsync<UserProfile>();
            }
        }

        public Task<UserProfile?> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateAsync(UserProfile entity)
        {
            throw new NotImplementedException();
        }
    }
}
