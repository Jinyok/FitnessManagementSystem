using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.Extensions
{
    public static class Locallize
    {
        public static string ToStringCh(this DayOfWeek d)
        {
            string day=null;
            switch (d)
            {
                case DayOfWeek.Sunday:
                    day="周日";
                    break;
                case DayOfWeek.Monday:
                    day = "周一";
                    break;
                case DayOfWeek.Tuesday:
                    day = "周二";
                    break;
                case DayOfWeek.Wednesday:
                    day = "周三";
                    break;
                case DayOfWeek.Thursday:
                    day = "周四";
                    break;
                case DayOfWeek.Friday:
                    day = "周五";
                    break;
                case DayOfWeek.Saturday:
                    day = "周六";
                    break;
            }
            return day;
        }
    }
}
