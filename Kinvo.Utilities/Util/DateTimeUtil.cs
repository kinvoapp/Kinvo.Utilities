using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Utilities.Util
{
    public static class DateTimeUtil
    {
        public static int GetAmountOfMonthsBetweenDates(DateTime date1, DateTime date2)
        {
            return Convert.ToInt32(date1.Subtract(date2).Days / (365.25 / 12));
        }
    }
}
