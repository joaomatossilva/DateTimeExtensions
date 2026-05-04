using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("pl-PL")]
    public class PL_PLHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public PL_PLHolidayStrategy()
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);

            this.InnerObservances.Add(ChristianHolidays.Epiphany);
            this.InnerObservances.Add(ChristianHolidays.Easter);
            this.InnerObservances.Add(ChristianHolidays.EasterMonday);

            this.InnerObservances.Add(GlobalHolidays.InternationalWorkersDay);

            this.InnerObservances.Add(May3rdConstitutionDay);

            this.InnerObservances.Add(ChristianHolidays.Pentecost);
            this.InnerObservances.Add(ChristianHolidays.CorpusChristi);
            this.InnerObservances.Add(ChristianHolidays.Assumption);
            this.InnerObservances.Add(ChristianHolidays.AllSaints);

            this.InnerObservances.Add(NationalIndependenceDay);

            this.InnerObservances.Add(ChristianHolidays.Christmas);
            this.InnerObservances.Add(ChristianHolidays.StStephansDay);
            this.InnerObservances.Add(ChristmasEveFrom2025);
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
