using DateTimeExtensions.Common;
using System;

namespace DateTimeExtensions.WorkingDays
{
    public class EasterOrthodoxBasedHoliday : Holiday
    {
        private int daysOffset;
        private readonly ConcurrentLazyDictionary<int, DateTime> dayCache;

        public EasterOrthodoxBasedHoliday(string name, int daysOffset)
            : base(name)
        {
            this.daysOffset = daysOffset;
            dayCache = new ConcurrentLazyDictionary<int, DateTime>();
        }

        public override DateTime? GetInstance(int year)
        {
            return dayCache.GetOrAdd(year, () => EasterCalculator.CalculateEasterDate(year).AddDays(daysOffset));
        }

        public override bool IsInstanceOf(DateTime date)
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

            //https://blog.georgekosmidis.net/c-calculating-orthodox-and-catholic-easter.html
            public static DateTime GetOrthodoxEaster(int year)
            {
                var a = year % 19;
                var b = year % 7;
                var c = year % 4;

                var d = (19 * a + 16) % 30;
                var e = (2 * c + 4 * b + 6 * d) % 7;
                var f = (19 * a + 16) % 30;

                var key = f + e + 3;
                var month = (key > 30) ? 5 : 4;
                var day = (key > 30) ? key - 30 : key;

                return new DateTime(year, month, day);
            }
        }
    }
}