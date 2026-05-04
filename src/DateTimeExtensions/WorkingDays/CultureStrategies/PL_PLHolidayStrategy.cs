using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("pl-PL")]
    public class PL_PLHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public PL_PLHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);

            this.InnerObservances.AddHoliday(ChristianHolidays.Epiphany);
            this.InnerObservances.AddHoliday(ChristianHolidays.Easter);
            this.InnerObservances.AddHoliday(ChristianHolidays.EasterMonday);

            this.InnerObservances.AddHoliday(GlobalHolidays.InternationalWorkersDay);

            this.InnerObservances.AddHoliday(May3rdConstitutionDay);

            this.InnerObservances.AddHoliday(ChristianHolidays.Pentecost);
            this.InnerObservances.AddHoliday(ChristianHolidays.CorpusChristi);
            this.InnerObservances.AddHoliday(ChristianHolidays.Assumption);
            this.InnerObservances.AddHoliday(ChristianHolidays.AllSaints);

            this.InnerObservances.AddHoliday(NationalIndependenceDay);

            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
            this.InnerObservances.AddHoliday(ChristianHolidays.StStephansDay);
            this.InnerObservances.AddHoliday(ChristmasEveFrom2025);
        }

        private static NamedDay may3rdConstitutionDay;

        public static NamedDay May3rdConstitutionDay
        {
            get
            {
                if (may3rdConstitutionDay == null)
                {
                    may3rdConstitutionDay = new NamedDay("May 3rd Constitution Day", new FixedDayResolver(5, 3));
                }
                return may3rdConstitutionDay;
            }
        }

        private static NamedDay nationalIndependenceDay;

        public static NamedDay NationalIndependenceDay
        {
            get
            {
                if (nationalIndependenceDay == null)
                {
                    nationalIndependenceDay = new NamedDay("National Independence Day", new FixedDayResolver(11, 11));
                }
                return nationalIndependenceDay;
            }
        }

        private static NamedDay christmasEveFrom2025;
        public static NamedDay ChristmasEveFrom2025
        {
            get
            {
                if (christmasEveFrom2025 == null)
                {
                    christmasEveFrom2025 = new NamedDay(
                        "Christmas Eve",
                        new YearDependantDayResolver(year => year >= 2025, new FixedDayResolver(12, 24)));
                }
                return christmasEveFrom2025;
            }
        }
    }
}
