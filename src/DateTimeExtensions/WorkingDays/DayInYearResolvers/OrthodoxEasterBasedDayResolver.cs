using DateTimeExtensions.Common;
using System;

namespace DateTimeExtensions.WorkingDays.DayInYearResolvers
{
    /// <summary>
    /// Representation of a calendar day that is based on the date of Orthodox Easter, with a fixed offset in days.
    /// A 0 offset represents Orthodox Easter.
    /// </summary>
    public class OrthodoxEasterBasedDayResolver : IDayResolver
    {
        private readonly int daysOffset;
        private readonly ConcurrentLazyDictionary<int, DateTime> dayCache;

        public OrthodoxEasterBasedDayResolver(int daysOffset)
        {
            this.daysOffset = daysOffset;
            dayCache = new ConcurrentLazyDictionary<int, DateTime>();
        }

        public DateTime? GetInstance(int year)
        {
            return dayCache.GetOrAdd(year, () => EasterCalculator.CalculateEasterDate(year).AddDays(daysOffset));
        }

        public bool IsInstanceOf(DateTime date)
        {
            var day = GetInstance(date.Year);
            return day.HasValue && date.Month == day.Value.Month && date.Day == day.Value.Day;
        }

        public static class EasterCalculator
        {
            private static ConcurrentLazyDictionary<int, DateTime> easterPerYear;

            static EasterCalculator()
            {
                easterPerYear = new ConcurrentLazyDictionary<int, DateTime>();
            }

            public static DateTime CalculateEasterDate(int year)
            {
                return easterPerYear.GetOrAdd(year, () => GetOrthodoxEaster(year));
            }

            public static DateTime GetOrthodoxEaster(int year)
            {
                //Meeus' Julian algorithm gives Easter as a date in the Julian calendar
                var a = year % 4;
                var b = year % 7;
                var c = year % 19;
                var d = (19 * c + 15) % 30;
                var e = (2 * a + 4 * b - d + 34) % 7;
                var month = (d + e + 114) / 31;
                var day = (d + e + 114) % 31 + 1;

                //Julian to Gregorian: the gap is 13 days only in 1900-2099
                //(12 days in 1800-1899, 14 days in 2100-2199, ...)
                var julianToGregorianDays = year / 100 - year / 400 - 2;

                return new DateTime(year, month, day).AddDays(julianToGregorianDays);
            }
        }
    }
}