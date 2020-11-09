using System;
using System.Collections.Generic;

namespace DateTimeExtensions.WorkingDays.OccurrencesCalculators
{
    public class YearMapDayStrategy : ICalculateDayStrategy
    {
        private readonly Dictionary<int, DayInYear> map;

        public YearMapDayStrategy(Dictionary<int, DayInYear> map)
        {
            this.map = map;
        }

        public DateTime? GetInstance(int year)
        {
            if (!map.ContainsKey(year))
            {
                return null;
            }
            var day = map[year];
            return day.GetDayOnYear(year);
        }

        public bool IsInstanceOf(DateTime date)
        {
            var day = GetInstance(date.Year);
            return day.HasValue && date.Month == day.Value.Month && date.Day == day.Value.Day;
        }
    }
}
