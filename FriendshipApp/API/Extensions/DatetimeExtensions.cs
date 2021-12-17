using System;

namespace API.Extensions
{
    public static class DatetimeExtensions
    {
        public static int CalculateAge(this DateTime bd)
        {
            return bd.Year - DateTime.Now.Year > 0 ? bd.Year - DateTime.Now.Year : -1;
        }
    }
}