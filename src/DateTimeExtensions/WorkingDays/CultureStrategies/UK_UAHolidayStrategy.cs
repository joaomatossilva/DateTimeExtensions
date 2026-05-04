using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("uk-UA")]
    public class UK_UAHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public UK_UAHolidayStrategy()
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(WomensDay);
            this.InnerObservances.Add(ChristianHolidays.Easter);
            this.InnerObservances.Add(WorkersDay);
            this.InnerObservances.Add(VictoryInEuropeDay);
            this.InnerObservances.Add(ChristianHolidays.Pentecost);
            this.InnerObservances.Add(ConstitutionDay);
            this.InnerObservances.Add(StatehoodDay);
            this.InnerObservances.Add(IndependenceDayOfUkraine);
            this.InnerObservances.Add(DefendersDay);
            this.InnerObservances.Add(ChristianHolidays.Christmas);
        }

        private static NamedDay womensDay;

        public static NamedDay WomensDay
        {
            get
            {
                if (womensDay == null)
                {
                    womensDay = new NamedDay("International Women's Day", new FixedDayResolver(3, 8));
                }
                return womensDay;
            }
        }

        private static NamedDay workersDay;

        public static NamedDay WorkersDay
        {
            get
            {
                if (workersDay == null)
                {
                    workersDay = new NamedDay("International Workers' Day", new FixedDayResolver(5, 1));
                }
                return workersDay;
            }
        }

        private static NamedDay victoryInEuropeDay;

        public static NamedDay VictoryInEuropeDay
        {
            get
            {
                if (victoryInEuropeDay == null)
                {
                    victoryInEuropeDay = new NamedDay("Victory in Europe Day", new FixedDayResolver(5, 8));
                }
                return victoryInEuropeDay;
            }
        }

        private static NamedDay constitutionDay;

        public static NamedDay ConstitutionDay
        {
            get
            {
                if (constitutionDay == null)
                {
                    constitutionDay = new NamedDay("Constitution Day", new FixedDayResolver(6, 28));
                }
                return constitutionDay;
            }
        }

        private static NamedDay statehoodDay;

        public static NamedDay StatehoodDay
        {
            get
            {
                if (statehoodDay == null)
                {
                    statehoodDay = new NamedDay("Statehood Day", new FixedDayResolver(7, 15));
                }
                return statehoodDay;
            }
        }

        private static NamedDay independenceDayOfUkraine;

        public static NamedDay IndependenceDayOfUkraine
        {
            get
            {
                if (independenceDayOfUkraine == null)
                {
                    independenceDayOfUkraine = new NamedDay("Independence Day of Ukraine", new FixedDayResolver(8, 24));
                }
                return independenceDayOfUkraine;
            }
        }

        private static NamedDay defendersDay;

        public static NamedDay DefendersDay
        {
            get
            {
                if (defendersDay == null)
                {
                    defendersDay = new NamedDay("Defenders Day", new FixedDayResolver(10, 1));
                }
                return defendersDay;
            }
        }
    }
}