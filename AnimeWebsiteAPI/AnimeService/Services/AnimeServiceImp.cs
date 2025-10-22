using AnimeService.Entities;
using AnimeService.Interfaces;
using AnimeService.Interfaces.ServiceInterfaces;

namespace AnimeService.Services
{
    public class AnimeServiceImp : IAnimeService
    {
        private readonly IRepository<Anime> _animeRepository;

        public AnimeServiceImp(IRepository<Anime> animeRepository)
        {
            this._animeRepository = animeRepository;
        }

        public Task<int> AddAsync(Anime entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Anime?>> GetAllAsync()
        {
            return await _animeRepository.GetAllAsync();
        }

        public async Task<Anime?> GetByIdAsync(int id)
        {
            return await _animeRepository.GetByIdAsync(id);
        }

        public Task<int> UpdateAsync(Anime entity)
        {
            throw new NotImplementedException();
        }
    }
}
