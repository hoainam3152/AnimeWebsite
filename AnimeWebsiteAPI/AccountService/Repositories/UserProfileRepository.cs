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
                //var newId = await connection.InsertAsync(entity);
                //return newId; 
                return await connection.InsertAsync(entity);
            }
        }

        public async Task<object> DeleteAsync(object id)
        {
            using (var connection = _database.Connect())
            {
                var result = await connection.DeleteAsync(id);
                return result;
            }
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

        public async Task<UserProfile?> GetByIdAsync(object id)
        {
            using (var connection = _database.Connect())
            {
                var users = await connection.QueryAsync<UserProfile>(id);
                return users.FirstOrDefault();
            }
        }

        public async Task<object> UpdateAsync(UserProfile entity)
        {
            using (var connection = _database.Connect())
            {
                var result = await connection.UpdateAsync(entity);
                return result;
            }
        }

        public async Task<UserProfile?> FindByEmailAsync(string email)
        {
            using (var connection = _database.Connect())
            {
                var user = await connection.QueryAsync<UserProfile>(user => user.Email == email);
                return user.FirstOrDefault();
            }
        }
    }
}
