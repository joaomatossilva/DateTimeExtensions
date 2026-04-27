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

        // 2nd January - New Year NamedDay
        private static NamedDay newYearHoliday;

        public static NamedDay NewYearHoliday
        {
            get { return newYearHoliday ?? (newYearHoliday = new NamedDay("New Year NamedDay", new FixedDayResolver(1, 2))); }
        }

        // 30 November - St. Andrew's Day
        private static NamedDay stAndrewsDay;

        public static NamedDay StAndrewsDay
        {
            get { return stAndrewsDay ?? (stAndrewsDay = new NamedDay("St. Andrew's Day", new FixedDayResolver(11, 30))); }
        }
    }
}