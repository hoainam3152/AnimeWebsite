using AnimeService.Constants;
using RepoDb.Enumerations;

namespace AnimeService.DTOs.Requests
{
    public class ItemQueryParameters
    {
        public int PageIndex { get; set; } = Paginator.DefaultPageIndex;
        public int PageSize { get; set; } = Paginator.DefaultPageSize;
        public string SortBy { get; set; } = Paginator.DefaultSortBy;
        public Order Order { get; set; } = Order.Ascending;
        public string SelectBy { get; set; } = String.Empty;
    }
}
