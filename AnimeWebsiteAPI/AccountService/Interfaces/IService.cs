namespace AccountService.Interfaces
{
    public interface IService<TEntity, TResult> where TEntity : class
    {
        Task<object?> AddAsync(TEntity entity);
        Task<object> UpdateAsync(TEntity entity);
        Task<object> DeleteAsync(object id);

        Task<IEnumerable<TResult?>> GetAllAsync();
        Task<TResult?> GetByIdAsync(object id);
    }
}
