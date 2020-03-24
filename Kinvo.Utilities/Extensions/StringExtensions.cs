using System;
using System.Globalization;
using System.Linq;

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

        public static string GetUntilOrEmpty(this string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }

        public static string StringBetween(this string text, string begin, string end)
        {
            return text.StringBetween(begin, end, 1);
        }

        public static string StringBetween(this string text, string begin, string end, int numorder)
        {
            return text.StringBetween(begin, end, numorder, false);
        }

        public static string StringBetween(this string text, string begin, string end, int numorder, bool revert)
        {
            if ((text != null) && (text != string.Empty))
            {
                char[] strArrayRevert;
                if (revert)
                {
                    strArrayRevert = text.ToCharArray();
                    Array.Reverse(strArrayRevert);
                    text = new string(strArrayRevert);
                }
                int i = 0;
                int startingPosition = -1;
                int finalPosition = -1;
                int startIndex = 0;
                while ((i < numorder) && (startIndex < text.Length))
                {
                    startingPosition = text.IndexOf(begin, startIndex, StringComparison.OrdinalIgnoreCase);
                    finalPosition = ((startingPosition + begin.Length) < text.Length)
                        ? text.IndexOf(end, startingPosition + begin.Length, StringComparison.OrdinalIgnoreCase)
                        : -1;

                    if ((startingPosition != -1) && (finalPosition != -1))
                    {
                        i++;
                        startIndex = finalPosition + 1;
                    }
                    else
                    {
                        break;
                    }
                }
                if (((startingPosition != -1) && (finalPosition != -1)) && (i == numorder))
                {
                    try
                    {
                        string result = text.Substring(startingPosition + begin.Length, finalPosition - (startingPosition + begin.Length));
                        if (revert)
                        {
                            strArrayRevert = result.ToCharArray();
                            Array.Reverse(strArrayRevert);
                            result = new string(strArrayRevert);
                        }
                        return result;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        public static string JoinWithDifferentLastDelimitor(this string[] stringArray, string defaultDelimitor, string lastDelimitor)
        {
            if (stringArray == null)
                throw new ArgumentException();

            var stringArrayCount = stringArray.Count();
            return (stringArrayCount <= 1) ? string.Join(defaultDelimitor, stringArray)
                : string.Join(defaultDelimitor, stringArray, 0, stringArrayCount - 1) + lastDelimitor + stringArray.LastOrDefault();
        }
    }
}
