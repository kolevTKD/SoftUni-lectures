using System;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int DateDifference(string startDate, string endDate)
        {
            DateTime startingDate = DateTime.Parse(startDate);
            DateTime endingDate = DateTime.Parse(endDate);
            TimeSpan difference = startingDate - endingDate;

            return Math.Abs(difference.Days);
        }
    }
}
