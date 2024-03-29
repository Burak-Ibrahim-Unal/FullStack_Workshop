namespace API.Helpers
{
    public class PaginationParams
    {
        private const int MaxPagedSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int pageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPagedSize ? MaxPagedSize : value;
        }
    }
}