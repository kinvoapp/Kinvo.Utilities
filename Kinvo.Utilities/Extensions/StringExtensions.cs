using System;
using System.Globalization;

namespace Kinvo.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static DateTime ToDateTime(this string inputDate, string format = "dd/MM/yyyy")
        {
            if (string.IsNullOrEmpty(inputDate))
                throw new ArgumentException(inputDate);

            var provider = CultureInfo.InvariantCulture;
            return DateTime.ParseExact(inputDate, format, provider);
        }
    }
}
