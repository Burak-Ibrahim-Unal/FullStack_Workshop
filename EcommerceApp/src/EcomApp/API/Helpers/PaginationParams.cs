﻿namespace API.Helpers
{
    public class PaginationParams_
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}
