using System.Collections.Generic;
using System.Linq;

namespace Kinvo.Utilities.Extensions
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || list.Count() == 0;
        }
    }
}
