using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-GD")]
    [Locale("gd-GD")]
    public class ScotlandHolidayStrategy : HolidayStrategyBase
    {
        public ScotlandHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(NewYearHoliday);
            this.InnerObservances.AddHoliday(ChristianHolidays.GoodFriday);
            this.InnerObservances.AddHoliday(EN_GBHolidayStrategy.MayDayBank);
            this.InnerObservances.AddHoliday(EN_GBHolidayStrategy.SpringBank);
            this.InnerObservances.AddHoliday(EN_GBHolidayStrategy.LateSummerBank);
            this.InnerObservances.AddHoliday(StAndrewsDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
            this.InnerObservances.AddHoliday(EN_GBHolidayStrategy.BoxingDay);
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
