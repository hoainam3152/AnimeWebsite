using AnimeService.Entities;
using AnimeService.Interfaces;

namespace AnimeService.Services
{
    public class AnimeServiceCore
    {
        private readonly IAnimeRepository _animeRepository;

        public AnimeServiceCore(IAnimeRepository animeRepository)
        {
            this._animeRepository = animeRepository;
        }

        public async Task<IEnumerable<Anime?>> GetAllAnimesAsync()
        {
            return await _animeRepository.GetAllAsync();
        }

        public async Task<Anime?> GetAnimeByIdAsync(int id)
        {
            return await _animeRepository.GetByIdAsync(id);
        }
    }
}
