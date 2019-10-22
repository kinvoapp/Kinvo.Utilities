using System;

namespace Kinvo.Utilities.Util
{
    public static class Truncate
    {
        public static decimal TruncateDecimal(decimal value, int precision)
        {
            decimal step = (decimal)Math.Pow(10, precision);
            decimal tmp = Math.Truncate(step * value);
            return tmp / step;
        }

    }
}
