using AccountService.Entities;
using AccountService.Interfaces;
using Microsoft.Data.SqlClient;

namespace AccountService.Repositories
{
    public class SqlServerDatabase : IDatabase
    {
        private readonly string? _connectionString;

        public SqlServerDatabase(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection Connect()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
