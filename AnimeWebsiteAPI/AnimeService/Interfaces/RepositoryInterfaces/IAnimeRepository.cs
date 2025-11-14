using AnimeService.DTOs.Requests;
using AnimeService.DTOs.Response;
using AnimeService.Entities;

namespace AnimeService.Interfaces.RepositoryInterfaces
{
    public interface IAnimeRepository: IRepository<Anime>
    {
        Task<IEnumerable<Anime>> SearchAsync(string query);
        Task<PagedResult<Anime>> GetByParamtersAsync(ItemQueryParameters parameters);
    }
}
