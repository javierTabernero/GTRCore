using GTR.CrossCutting.Common;
using System;
using System.Globalization;
using System.Threading;

namespace GTR.CrossCutting.DateTime
{
    public sealed class DateTimeDiff
    {
        public static long DateDiffDay(System.DateTime date1, System.DateTime date2)
        {
            TimeSpan timeSpan = date2.Subtract(date1);
            long daydiff = checked((long)Math.Round(Conversion.Fix(timeSpan.TotalDays)));

            return daydiff;
        }

        public static long DateDiffMonth(System.DateTime date1, System.DateTime date2)
        {
            TimeSpan timeSpan = date2.Subtract(date1);
            Calendar currentCalendar = Thread.CurrentThread.CurrentCulture.Calendar;
            long mesdiff = (long)checked((currentCalendar.GetYear(date2) - currentCalendar.GetYear(date1)) * 12 + currentCalendar.GetMonth(date2) - currentCalendar.GetMonth(date1));

            return mesdiff;
        }
    }
}
