using System;

namespace Kinvo.Utilities.Util
{
    public static class Timezone
    {
        /// <summary>
        /// Get datetime now from south america timezone
        /// </summary>
        /// <returns></returns>
        public static DateTime GetSouthAmericaDateTimeNow()
        {
            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo kstZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(timeUtc, kstZone);
        }
    }
}
