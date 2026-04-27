using System;
using DateTimeExtensions.WorkingDays.DayInYearResolvers;

namespace DateTimeExtensions.WorkingDays
{
    public class NewYearEveFridayOnly : NamedDay
    {
        public NewYearEveFridayOnly()
            : base(GlobalHolidays.NewYearsEve.Name,
                new YearDependantDayResolver(
                    year => new DateTime(year, 12, 31).DayOfWeek == DayOfWeek.Friday,
                    new FixedDayResolver(12, 31)))
        {
        }
    }
}
