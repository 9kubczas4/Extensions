using System;

namespace Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsBetween(this DateTime date, DateTime first, DateTime second)
            => (date < second && date > first) || (date < first && date > second);

        public static bool IsAfter(this DateTime date, DateTime dateToCompare)
            => date > dateToCompare;

        public static bool IsBefore(this DateTime date, DateTime dateToCompare)
            => date < dateToCompare;
    }
}
