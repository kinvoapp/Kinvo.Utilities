using System;
using System.Collections.Generic;
using System.Linq;

namespace Kinvo.Utilities.Extensions
{
    public static class ExceptionExtensions
    {
        public static string ToFormattedString(this Exception exception)
        {
            var messages = exception
                .GetAllInnerExceptions()
                .Where(e => !String.IsNullOrWhiteSpace(e.Message))
                .Select(e => e.Message.Trim());
            var flattened = String.Join("; ", messages);
            return flattened;
        }

        public static IEnumerable<Exception> GetAllInnerExceptions(this Exception exception)
        {
            yield return exception;

            if (exception is AggregateException aggrEx)
            {
                foreach (Exception innerEx in aggrEx.InnerExceptions.SelectMany(e => e.GetAllInnerExceptions()))
                    yield return innerEx;
            }
            else if (exception.InnerException != null)
            {
                foreach (Exception innerEx in exception.InnerException.GetAllInnerExceptions())
                    yield return innerEx;
            }
        }
    }
}
