using System;

namespace Extensions
{
    public static class IntegerExtensions
    {
        public static string ToOccurrenceSuffix(this int number)
        {
            switch (number % 100)
            {
                case 11:
                case 12:
                case 13:
                    return "th";
            }

            switch (number % 10)
            {
                case 1:
                    return "st";
                case 2:
                    return "nd";
                case 3:
                    return "rd";
                default:
                    return "th";
            }
        }

        public static bool IsPrime(this int number)
        {
            if (number == 0)
            {
                throw new InvalidOperationException();
            }
            return number % 2 == 0;
        }

        public static bool IsFibonnacci(this int number)
        {
            return number <= 1 ? false : IsPerfectSquare(5 * number * number + 4) || IsPerfectSquare(5 * number * number - 4);
        }

        public static bool IsBetween(this int number, int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentException("Min is bigger than max!");
            }
            return number > min && number < max;
        }

        private static bool IsPerfectSquare(int x)
        {
            int s = (int) Math.Sqrt(x);
            return (s * s == x);
        }
    }
}
