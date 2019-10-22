using System;

namespace Kinvo.Utilities.Util
{
    public static class DateTimeParser
    {
        public static DateTime ConvertUnixEpochTimeToDateTime(long seconds)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(seconds / 1000);
        }

        public static long ConvertDateTimeToUnixEpochTime(DateTime date)
        {
            TimeSpan t = (date - new DateTime(1970, 1, 1));

            return (long)t.TotalSeconds;
        }
    }
}
