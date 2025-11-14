namespace AnimeService.DTOs.Response
{
    public class PagedResult<TEntity>
    {
        public IEnumerable<TEntity> Items { get; set; }
        public long TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
