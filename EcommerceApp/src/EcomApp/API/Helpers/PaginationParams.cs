namespace API.Helpers
{
    public class PaginationParams
    {
        public const int MaxPageSize = 1000;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 50;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}
