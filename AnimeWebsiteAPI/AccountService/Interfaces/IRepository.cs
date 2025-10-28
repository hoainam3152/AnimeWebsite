namespace AccountService.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<object> AddAsync(TEntity entity);
        Task<object> UpdateAsync(TEntity entity);
        Task<object> DeleteAsync(object id);

        Task<IEnumerable<TEntity?>> GellAllAsync();
        Task<TEntity?> GetByIdAsync(object id);
    }
}
