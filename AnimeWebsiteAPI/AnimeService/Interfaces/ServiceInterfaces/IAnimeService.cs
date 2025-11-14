using AnimeService.DTOs.Requests;
using AnimeService.DTOs.Response;

namespace AnimeService.Interfaces.ServiceInterfaces
{
    public interface IAnimeService : IService<AnimeResponse>
    {
        Task<IEnumerable<AnimeResponse>> SearchAsync(string query);
        Task<PagedResult<AnimeResponse>> GetItemsAsync(int pageIndex, int pageSize, string? sortBy, string? order, string? select);
    }
}
