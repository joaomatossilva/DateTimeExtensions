using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-GD")]
    [Locale("gd-GD")]
    public class ScotlandHolidayStrategy : HolidayStrategyBase
    {
        public ScotlandHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(NewYearHoliday);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(EN_GBHolidayStrategy.MayDayBank);
            this.InnerHolidays.Add(EN_GBHolidayStrategy.SpringBank);
            this.InnerHolidays.Add(EN_GBHolidayStrategy.LateSummerBank);
            this.InnerHolidays.Add(StAndrewsDay);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(EN_GBHolidayStrategy.BoxingDay);
        }

        // 2nd January - New Year Holiday
        private static Holiday newYearHoliday;

        public static Holiday NewYearHoliday
        {
            get { return newYearHoliday ?? (newYearHoliday = new FixedHoliday("New Year Holiday", 1, 2)); }
        }

        // 30 November - St. Andrew's Day
        private static Holiday stAndrewsDay;

        public static Holiday StAndrewsDay
        {
            get { return stAndrewsDay ?? (stAndrewsDay = new FixedHoliday("St. Andrew's Day", 11, 30)); }
        }
    }
}