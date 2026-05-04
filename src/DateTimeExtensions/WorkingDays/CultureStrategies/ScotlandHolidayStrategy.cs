using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-GD")]
    [Locale("gd-GD")]
    public class ScotlandHolidayStrategy : HolidayStrategyBase
    {
        public ScotlandHolidayStrategy()
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(NewYearHoliday);
            this.InnerObservances.Add(ChristianHolidays.GoodFriday);
            this.InnerObservances.Add(EN_GBHolidayStrategy.MayDayBank);
            this.InnerObservances.Add(EN_GBHolidayStrategy.SpringBank);
            this.InnerObservances.Add(EN_GBHolidayStrategy.LateSummerBank);
            this.InnerObservances.Add(StAndrewsDay);
            this.InnerObservances.Add(ChristianHolidays.Christmas);
            this.InnerObservances.Add(EN_GBHolidayStrategy.BoxingDay);
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