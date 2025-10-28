namespace AccountService.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<object?> AddAsync(TEntity entity);
        Task<object> UpdateAsync(TEntity entity);
        Task<object> DeleteAsync(object id);

        Task<IEnumerable<TEntity?>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(object id);
    }
}
