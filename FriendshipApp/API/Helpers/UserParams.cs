namespace API.Helpers
{
    public class UserParams
    {
        private const int MaxPagedSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int pageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPagedSize ? MaxPagedSize : value;
        }


        public string CurrentUsername { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; } = 18;
        public int MaxAge { get; set; } = 130;
        public string OrderBy { get; set; } = "lastActive";

    }
}