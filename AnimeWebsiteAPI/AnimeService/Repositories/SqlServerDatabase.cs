using AnimeService.Interfaces;
using Microsoft.Data.SqlClient;

namespace AnimeService.Repositories
{
    public class SqlServerDatabase : IDatabase
    {
        private readonly string? _connectionString;

        public SqlServerDatabase(IConfiguration configuration) 
            => _connectionString = configuration.GetConnectionString("DefaultConnection");

        public SqlConnection Connect()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
