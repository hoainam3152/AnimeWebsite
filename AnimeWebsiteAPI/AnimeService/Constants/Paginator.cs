namespace AnimeService.Constants
{
    public class Paginator
    {
        public const int DefaultPageIndex = 0;
        public const int DefaultPageSize = 24;
        public const int MaxPageSize = 100;
        public const int MinPageSize = 1;
        public const string DefaultSortBy = "Id";
        
        public class SortOrder
        {
            public const string Ascending = "asc";
            public const string Descending = "desc";
        }
    }
}
