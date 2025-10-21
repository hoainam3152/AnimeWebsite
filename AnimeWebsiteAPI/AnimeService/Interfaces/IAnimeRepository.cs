using System.Xml.Linq;
using AnimeService.Entities;

namespace AnimeService.Interfaces
{
    public interface IAnimeRepository
    {
        Task<int> AddAsync(Anime anime);
        Task<int> UpdateAsync(Anime anime);
        Task<int> DeleteByIdAsync(int id);
        Task<Anime?> GetByIdAsync(int id);
        Task<IEnumerable<Anime?>> GetAllAsync();
    }
}
