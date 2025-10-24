using AnimeService.DTOs.Response;
using AnimeService.Entities;
using AnimeService.Interfaces;
using AnimeService.Interfaces.ServiceInterfaces;
using AutoMapper;

namespace AnimeService.Services
{
    public class AnimeServiceImp : IAnimeService
    {
        private readonly IRepository<Anime> _animeRepository;
        private readonly IMapper _mapper;

        public AnimeServiceImp(IRepository<Anime> animeRepository, IMapper mapper)
        {
            this._animeRepository = animeRepository;
            this._mapper = mapper;
        }

        public Task<int> AddAsync(AnimeResponse entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnimeResponse?>> GetAllAsync()
        {
            var animes = await _animeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AnimeResponse?>>(animes);
        }

        public async Task<AnimeResponse?> GetByIdAsync(int id)
        {
            var anime = await _animeRepository.GetByIdAsync(id);
            return _mapper.Map<AnimeResponse?>(anime);
        }

        public Task<int> UpdateAsync(AnimeResponse entity)
        {
            throw new NotImplementedException();
        }
    }
}
