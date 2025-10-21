using AnimeService.Entities;
using AnimeService.Interfaces;
using RepoDb;
using System.Linq;

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

        public Task<int> UpdateAsync(Anime anime)
        {
            throw new NotImplementedException();
        }
    }
}
