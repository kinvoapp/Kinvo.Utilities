using System;
using System.Globalization;
using TimeZoneConverter;

namespace Kinvo.Utilities.Util
{
    public static class DateTimeUtil
    {
        public static int GetAmountOfMonthsBetweenDates(DateTime date1, DateTime date2)
        {
            return Convert.ToInt32(date1.Subtract(date2).Days / (365.25 / 12));
        }

        /// <summary>
        /// Defaults to the TZ database name: America/Sao_Paulo
        /// </summary>
        /// <returns></returns>
        public static DateTime GetSouthAmericaDateTimeNow()
        {
            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo kstZone = TZConvert.GetTimeZoneInfo("America/Sao_Paulo");
            return TimeZoneInfo.ConvertTimeFromUtc(timeUtc, kstZone);
        }

        /// <summary>
        /// The timezoneId is the TZ database name provided on this link
        /// https://en.wikipedia.org/wiki/List_of_tz_database_time_zones
        /// </summary>
        /// <param name="timeZoneId"></param>
        /// <returns></returns>
        public static DateTime GetDateTimeNowByTimeZoneInfo(string timeZoneId)
        {
            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo kstZone = TZConvert.GetTimeZoneInfo(timeZoneId);
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
