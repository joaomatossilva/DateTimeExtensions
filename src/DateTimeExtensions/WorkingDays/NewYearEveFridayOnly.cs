using System;

namespace DateTimeExtensions.WorkingDays
{
    public class NewYearEveFridayOnly : FixedHoliday
    {
        public NewYearEveFridayOnly() : base(GlobalHolidays.NewYearsEve.Name, 12, 31)
        {
        }

        public override DateTime? GetInstance(int year)
        {
            DateTime? date = base.GetInstance(year);
            if (date.HasValue && date.Value.DayOfWeek == DayOfWeek.Friday)
            {
                return date;
            }
            return null;
        }
    }
}