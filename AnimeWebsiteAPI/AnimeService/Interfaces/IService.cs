namespace AnimeService.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<int> AddAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteByIdAsync(int id);
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity?>> GetAllAsync();
    }
}
