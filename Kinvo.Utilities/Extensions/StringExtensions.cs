using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        public static Stream ToStream(this string input)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(input);
            writer.Flush();
            stream.Position = 0;
            return stream;
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

        public static string RemoveFromEnd(this string text, string suffix)
        {
            return text.EndsWith(suffix) ? text.Substring(0, text.Length - suffix.Length) : text;
        }

        public static string RemoveAllTextBetween(this string text, string begin, string end, bool includeBeginAndEnd)
        {
            return ReplaceAllTextBetween(text, begin, end, string.Empty, includeBeginAndEnd);
        }

        public static string ReplaceAllTextBetween(this string text, string begin, string end, string newText, bool includeBeginAndEnd)
        {
            if (!string.IsNullOrEmpty(begin) && !string.IsNullOrEmpty(end))
            {
                var targetString = StringBetween(text, begin, end);
                var ocurrencies = new List<string>();
                int ocurrentyAmount = 0;
                while (targetString != null)
                {
                    if (includeBeginAndEnd)
                    {
                        text = text.Replace(begin + targetString + end, newText);
                        ocurrentyAmount++;
                        targetString = StringBetween(text, begin, end);
                    }
                    else
                    {
                        if (!ocurrencies.Contains(targetString))
                        {
                            text = text.Replace(begin + targetString + end, begin + newText + end);
                            ocurrencies.Add(targetString);
                        }
                        targetString = text.StringBetween(begin, end, ++ocurrentyAmount);
                    }

                    if (ocurrentyAmount > 0x2710)
                        throw new StackOverflowException();
                }
            }
            return text;
        }
    }
}
