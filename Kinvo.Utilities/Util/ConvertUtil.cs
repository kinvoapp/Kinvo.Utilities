using System;
using System.Globalization;

namespace Kinvo.Utilities.Util
{
    public static class ConvertUtil
    {
        public static DateTime? TryParseNullableDateTime(string dateTimeString)
        {
            return DateTime.TryParse(dateTimeString, CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out var parsedValue)
                ? (DateTime?)parsedValue
                : null;
        }

        public static decimal? TryParseNullableDecimal(string decimalString)
        {
            return decimal.TryParse(decimalString, NumberStyles.Float, CultureInfo.GetCultureInfo("pt-BR"), out var parsedValue)
                ? (decimal?)parsedValue
                : null;
        }

        public static long? TryParseNullableLong(string longString)
        {
            return long.TryParse(longString, out var parsedValue)
                ? (long?)parsedValue
                : null;
        }
    }
}
