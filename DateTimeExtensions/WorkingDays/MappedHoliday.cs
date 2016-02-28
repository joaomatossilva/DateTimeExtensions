using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.WorkingDays
{
    public class YearMapHoliday : Holiday
    {
        private readonly Dictionary<int, DayInYear> _map;

        public YearMapHoliday(string name, Dictionary<int, DayInYear> map) : base(name)
        {
            _map = map;
        }

        public override DateTime? GetInstance(int year)
        {
            if (!_map.ContainsKey(year))
            {
                return null;
            }
            var day = _map[year];
            return day.GetDayOnYear(year);
        }

        public override bool IsInstanceOf(DateTime date)
        {
            var day = GetInstance(date.Year);
            return day.HasValue && date.Month == day.Value.Month && date.Day == day.Value.Day;
        }
    }
}
