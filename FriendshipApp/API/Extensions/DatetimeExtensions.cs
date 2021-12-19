using System;

namespace API.Extensions
{
    public static class DatetimeExtensions
    {
        public static int CalculateAge(this DateTime bd)
        {
            return DateTime.Now.Year- bd.Year;
        }
    }
}