using Microsoft.Data.SqlClient;

namespace AnimeService.Interfaces
{
    public interface IDatabase
    {
        SqlConnection Connect();
    }
}
