using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullCalc;
internal static class DateOnly
{
    internal static bool DoEqual(this DateTime dt1, DateTime dt2)
    {
        return dt1.Year == dt2.Year && dt1.Month == dt2.Month && dt1.Day == dt2.Day;
    }


    internal static bool DoSmallerEqual(this DateTime dt1, DateTime dt2)
    {
        if (dt1.Year == dt2.Year)
            return dt1.DayOfYear <= dt2.DayOfYear;
        else
            return dt1.Year < dt2.Year;
    }
    internal static bool DoSmaller(this DateTime dt1, DateTime dt2)
    {
        if (dt1.Year == dt2.Year)
            return dt1.DayOfYear < dt2.DayOfYear;
        else
            return dt1.Year < dt2.Year;
    }


    internal static bool DoLargerEqual(this DateTime dt1, DateTime dt2)
    {
        if (dt1.Year == dt2.Year)
            return dt1.DayOfYear >= dt2.DayOfYear;
        else
            return dt1.Year > dt2.Year;
    }
    internal static bool DoLarger(this DateTime dt1, DateTime dt2)
    {
        if (dt1.Year == dt2.Year)
            return dt1.DayOfYear > dt2.DayOfYear;
        else
            return dt1.Year > dt2.Year;
    }



    internal static string DoToString(this DateTime dt)
    {
        return dt.Day + "." + dt.Month + "." + dt.Year;
    }
}
