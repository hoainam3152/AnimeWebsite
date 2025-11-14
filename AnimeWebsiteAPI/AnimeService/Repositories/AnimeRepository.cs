using AnimeService.DTOs.Requests;
using AnimeService.DTOs.Response;
using AnimeService.Entities;
using AnimeService.Helpers;
using AnimeService.Interfaces;
using AnimeService.Interfaces.RepositoryInterfaces;
using RepoDb;

namespace AnimeService.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly IDatabase _database;

        public AnimeRepository(IDatabase database) => _database = database;

        public Task<int> AddAsync(Anime anime)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Anime?>> GetAllAsync()
        {
            using (var connection = _database.Connect())
            {
                return await connection.QueryAllAsync<Anime>();
            }
        }

        public async Task<Anime?> GetByIdAsync(int animeId)
        {
            using (var connection = _database.Connect())
            {
                var animes = await connection.QueryAsync<Anime>(animeId);
                return animes.FirstOrDefault();
            }
        }

        public async Task<PagedResult<Anime>> GetByParamtersAsync(ItemQueryParameters parameters)
        {
            using (var connection = _database.Connect())
            {
                var orderBy = new OrderField(parameters.SortBy, parameters.Order);
                var fields = new List<Field>();
                if (!string.IsNullOrEmpty(parameters.SelectBy))
                {
                    //tách chuỗi SelectBy thành các trường riêng biệt
                    //ví dụ "Id, Title, AlternateTitle" => ["Id", "Title", "AlternateTitle"]
                    var selects = StringHelper.SplitByComma(parameters.SelectBy);
                    foreach (var select in selects)
                    {
                        fields.Add(new Field(select));
                    }
                }

                //sử dụng BatchQuery(có tích hợp phân trang) hoặc Query(chỉ để lấy dữ liệu)
                var animes = await connection.BatchQueryAsync<Anime>(
                        page: parameters.PageIndex,
                        rowsPerBatch: parameters.PageSize,
                        orderBy: new[] { orderBy },
                        where: (object)null,
                        fields: fields.Any() ? fields : null
                    );

                var totalCount = await connection.CountAllAsync<Anime>();

                return new PagedResult<Anime>
                {
                    Items = animes,
                    TotalCount = totalCount,
                    PageIndex = parameters.PageIndex,
                    PageSize = parameters.PageSize
                };
            }
        }

        public async Task<IEnumerable<Anime>> SearchAsync(string query= "")
        {
            using (var connection = _database.Connect())
            {
                if (string.IsNullOrEmpty(query))
                {
                    return await connection.QueryAllAsync<Anime>();
                }
                string queryString = @"SELECT * FROM Anime
                WHERE Title LIKE @query OR AlternateTitle LIKE @query;";
                var animes = await connection.ExecuteQueryAsync<Anime>(queryString, new { query = $"%{query}%" });
                return animes;
            }
        }

        public Task<int> UpdateAsync(Anime anime)
        {
            throw new NotImplementedException();
        }
    }
}
