using AccountService.Entities;
using AccountService.Interfaces;
using AccountService.Interfaces.RepositoryInterfaces;
using RepoDb;

namespace AccountService.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDatabase _database;

        public RoleRepository(IDatabase database)
        {
            this._database = database;
        }
        public async Task<object> AddAsync(Role entity)
        {
            using (var connection = _database.Connect())
            {
                var roleId = await GetByNameAsync(entity.Name);
                if (roleId != null)
                {
                    throw new Exception("Role is existed");
                }
                var newId = await connection.InsertAsync(entity);
                return newId;
            }
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

        public async Task<Role?> GetByIdAsync(object id)
        {
            using (var connection = _database.Connect())
            {
                var role = await connection.QueryAsync<Role>(id);
                return role.FirstOrDefault();
            }
        }

        public async Task<object?> GetByNameAsync(string roleName)
        {
            using (var connection = _database.Connect())
            {
                string queryString = "SELECT Id FROM Role WHERE Name = @Name";
                var roleId = await connection.ExecuteScalarAsync(queryString, new { Name = roleName});
                return roleId;
            }
        }

        public Task<object> UpdateAsync(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
