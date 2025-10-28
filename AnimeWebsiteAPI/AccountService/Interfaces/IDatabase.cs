using Microsoft.Data.SqlClient;

namespace AccountService.Interfaces
{
    public interface IDatabase
    {
        SqlConnection Connect();
    }
}
