using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-IE")]
    public class IrelandHolidayStrategy : HolidayStrategyBase
    {
        public IrelandHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(GlobalHolidays.StPatricsDay);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(new NamedDay("May Day", new NthDayOfWeekAfterDayResolver(1, DayOfWeek.Monday, GlobalHolidays.MayDay.Resolver)));
            this.InnerHolidays.Add(JuneHoliday);
            this.InnerHolidays.Add(AugustHoliday);
            this.InnerHolidays.Add(OctoberHoliday);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(ChristianHolidays.StStephansDay);
        }

        // 1st Monday in June - June NamedDay
        private static NamedDay juneHoliday;

        public static NamedDay JuneHoliday
        {
            get
            {
                return juneHoliday ??
                        (juneHoliday =
                            new NamedDay("June NamedDay", new NthDayOfWeekInMonthDayResolver(1, DayOfWeek.Monday, 6, CountDirection.FromFirst)));
            }
        }

        // 1st Monday in August - August NamedDay
        private static NamedDay augustHoliday;

        public static NamedDay AugustHoliday
        {
            get
            {
                return augustHoliday ??
                       (augustHoliday =
                           new NamedDay("August NamedDay", new NthDayOfWeekInMonthDayResolver(1, DayOfWeek.Monday, 8, CountDirection.FromFirst)));
            }
        }

        // lasy Monday in October - October NamedDay
        private static NamedDay octoberHoliday;

        public static NamedDay OctoberHoliday
        {
            get
            {
                return octoberHoliday ??
                       (octoberHoliday =
                           new NamedDay("October NamedDay", new NthDayOfWeekInMonthDayResolver(1, DayOfWeek.Monday, 10, CountDirection.FromLast)));
            }
        }
    }
}
