using AccountService.Entities;
using AccountService.Interfaces;
using RepoDb;

namespace AccountService.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly IDatabase _database;

        public RoleRepository(IDatabase database)
        {
            this._database = database;
        }
        public Task<object> AddAsync(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<object> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role?>> GellAllAsync()
        {
            using (var connection = _database.Connect())
            {
                return await connection.QueryAllAsync<Role>();
            }
        }

        public Task<Role?> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateAsync(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
