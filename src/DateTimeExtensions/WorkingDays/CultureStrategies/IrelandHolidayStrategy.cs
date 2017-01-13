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
            this.InnerHolidays.Add(new NthDayOfWeekAfterDayHoliday("May Day", 1, DayOfWeek.Monday, GlobalHolidays.MayDay));
            this.InnerHolidays.Add(JuneHoliday);
            this.InnerHolidays.Add(AugustHoliday);
            this.InnerHolidays.Add(OctoberHoliday);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(ChristianHolidays.StStephansDay);
        }

        // 1st Monday in June - June Holiday
        private static Holiday juneHoliday;

        public static Holiday JuneHoliday
        {
            get
            {
                return juneHoliday ??
                       (juneHoliday =
                           new NthDayOfWeekInMonthHoliday("June Holiday", 1, DayOfWeek.Monday, 6,
                               CountDirection.FromFirst));
            }
        }

        // 1st Monday in August - August Holiday
        private static Holiday augustHoliday;

        public static Holiday AugustHoliday
        {
            get
            {
                return augustHoliday ??
                       (augustHoliday =
                           new NthDayOfWeekInMonthHoliday("August Holiday", 1, DayOfWeek.Monday, 8,
                               CountDirection.FromFirst));
            }
        }

        // lasy Monday in October - October Holiday
        private static Holiday octoberHoliday;

        public static Holiday OctoberHoliday
        {
            get
            {
                return octoberHoliday ??
                       (octoberHoliday =
                           new NthDayOfWeekInMonthHoliday("October Holiday", 1, DayOfWeek.Monday, 10,
                               CountDirection.FromLast));
            }
        }
    }
}