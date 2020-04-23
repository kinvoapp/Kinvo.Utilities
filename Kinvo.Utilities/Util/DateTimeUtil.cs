using System;
using System.Globalization;

namespace Kinvo.Utilities.Util
{
    public static class DateTimeUtil
    {
        public static int GetAmountOfMonthsBetweenDates(DateTime date1, DateTime date2)
        {
            return Convert.ToInt32(date1.Subtract(date2).Days / (365.25 / 12));
        }

        public static DateTime GetSouthAmericaDateTimeNow()
        {
            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo kstZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(timeUtc, kstZone);
        }

        public static DateTime? GetMonthlyDateFromString(string inputDate)
        {
            if (string.IsNullOrEmpty(inputDate))
                return null;

            var provider = CultureInfo.InvariantCulture;
            var format = "dd/MM/yyyy";

            return DateTime.ParseExact("01/" + inputDate, format, provider);
        }

        public static DateTime ParseWithFallbacks(string inputDate, params string[] formats)
        {
            if (formats.Length == 0)
                throw new ArgumentException();

            for (int index = 0; index < formats.Length; index++)
            {
                var currentFormat = formats[index];
                var successfullyParsed = DateTime.TryParseExact(inputDate,
                                                                currentFormat,
                                                                CultureInfo.InvariantCulture,
                                                                DateTimeStyles.None,
                                                                out var parsedDate);
                if (successfullyParsed)
                    return parsedDate;
            }

            throw new Exception("Couldn't convert to DateTime with the available formats");
        }
    }
}
