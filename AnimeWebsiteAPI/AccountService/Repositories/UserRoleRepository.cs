using AccountService.Entities;
using AccountService.Interfaces;
using AccountService.Interfaces.RepositoryInterfaces;
using RepoDb;

namespace AccountService.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IDatabase _database;

        public UserRoleRepository(IDatabase database)
        {
            _database = database;
        }

        public async Task<object> AddAsync(UserRole entity)
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

        public Task<IEnumerable<UserRole?>> GellAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserRole?> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateAsync(UserRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
