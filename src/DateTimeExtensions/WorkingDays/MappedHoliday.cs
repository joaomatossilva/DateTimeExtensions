using System;
using System.Collections.Generic;
using DateTimeExtensions.WorkingDays.DayInYearResolvers;

namespace DateTimeExtensions.WorkingDays
{
    public class YearMapNamedDay : NamedDay
    {
        public YearMapNamedDay(string name, Dictionary<int, DayInYear> map)
            : base(name, new FixedDayResolver(year =>
            {
                DayInYear day;
                return map.TryGetValue(year, out day) ? day.GetDayOnYear(year) : (DateTime?)null;
            }))
        {
        }
    }
}
