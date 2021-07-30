using System;
using System.Text.RegularExpressions;

namespace Kinvo.Utilities.Util
{
    public static class RegexUtil
    {
        /// <summary>
        /// Detects if string contains html injection pattern
        /// </summary>
        /// <returns>True or False</returns>
        public static bool MatchHTMLInjection(string input, int timeoutInSeconds = 1)
        {
            return Regex.IsMatch(input, "<[^>]*>", RegexOptions.Compiled, TimeSpan.FromSeconds(timeoutInSeconds));
        }
    }
}
