using AnimeService.Constants;
using AnimeService.DTOs.Requests;
using AnimeService.DTOs.Response;
using AnimeService.Entities;
using AnimeService.Interfaces;
using AnimeService.Interfaces.RepositoryInterfaces;
using AnimeService.Interfaces.ServiceInterfaces;
using AutoMapper;
using RepoDb.Enumerations;

namespace AnimeService.Services
{
    public class AnimeServiceImp : IAnimeService
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly IMapper _mapper;

        public AnimeServiceImp(IAnimeRepository animeRepository, IMapper mapper)
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

        

        public Task<IEnumerable<AnimeResponse?>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<AnimeResponse>> GetItemsAsync(int pageIndex, int pageSize, string? sortBy, string? order, string? select)
        {
            if (pageSize <= Paginator.MinPageSize || pageSize > Paginator.MaxPageSize)
            {
                pageSize = Paginator.DefaultPageSize;
            }

            if (pageIndex < Paginator.DefaultPageIndex)
            {
                pageIndex = Paginator.DefaultPageIndex;
            }

            if (string.IsNullOrEmpty(order))
            {
                order = Paginator.SortOrder.Ascending;
            }
            else if (!order.Equals(Paginator.SortOrder.Ascending, StringComparison.OrdinalIgnoreCase) &&
                !order.Equals(Paginator.SortOrder.Descending, StringComparison.OrdinalIgnoreCase)) 
            {
                throw new ArgumentException("Order must be either 'asc' or 'desc'");
            }

                var parameters = new ItemQueryParameters
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SortBy = sortBy ?? "Id",
                    Order = order.Equals(Paginator.SortOrder.Ascending, StringComparison.OrdinalIgnoreCase) ? Order.Ascending : Order.Descending,
                    SelectBy = select ?? string.Empty
                };

            var pagedAnimes = await _animeRepository.GetByParamtersAsync(parameters);
            var animeResponses = _mapper.Map<IEnumerable<AnimeResponse>>(pagedAnimes.Items);

            return new PagedResult<AnimeResponse>
            {
                Items = animeResponses,
                TotalCount = pagedAnimes.TotalCount,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }

        public async Task<IEnumerable<AnimeResponse>> SearchAsync(string query)
        {
            var animesSearch = await _animeRepository.SearchAsync(query);
            return _mapper.Map<IEnumerable<AnimeResponse>>(animesSearch);
        }

        public Task<int> UpdateAsync(AnimeResponse entity)
        {
            throw new NotImplementedException();
        }
    }
}
