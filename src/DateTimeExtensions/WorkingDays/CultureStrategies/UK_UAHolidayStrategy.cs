using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("uk-UA")]
    public class UK_UAHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public UK_UAHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(WomensDay);
            this.InnerHolidays.Add(ChristianHolidays.Easter);
            this.InnerHolidays.Add(WorkersDay);
            this.InnerHolidays.Add(VictoryInEuropeDay);
            this.InnerHolidays.Add(ChristianHolidays.Pentecost);
            this.InnerHolidays.Add(ConstitutionDay);
            this.InnerHolidays.Add(StatehoodDay);
            this.InnerHolidays.Add(IndependenceDayOfUkraine);
            this.InnerHolidays.Add(DefendersDay);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
        }

        private static Holiday womensDay;

        public static Holiday WomensDay
        {
            get
            {
                if (womensDay == null)
                {
                    womensDay = new FixedHoliday("International Women's Day", 3, 8);
                }
                return womensDay;
            }
        }

        private static Holiday workersDay;

        public static Holiday WorkersDay
        {
            get
            {
                if (workersDay == null)
                {
                    workersDay = new FixedHoliday("International Workers' Day", 5, 1);
                }
                return workersDay;
            }
        }

        private static Holiday victoryInEuropeDay;

        public static Holiday VictoryInEuropeDay
        {
            get
            {
                if (victoryInEuropeDay == null)
                {
                    victoryInEuropeDay = new FixedHoliday("Victory in Europe Day", 5, 8);
                }
                return victoryInEuropeDay;
            }
        }

        private static Holiday constitutionDay;

        public static Holiday ConstitutionDay
        {
            get
            {
                if (constitutionDay == null)
                {
                    constitutionDay = new FixedHoliday("Constitution Day", 6, 28);
                }
                return constitutionDay;
            }
        }

        private static Holiday statehoodDay;

        public static Holiday StatehoodDay
        {
            get
            {
                if (statehoodDay == null)
                {
                    statehoodDay = new FixedHoliday("Statehood Day", 7, 15);
                }
                return statehoodDay;
            }
        }

        private static Holiday independenceDayOfUkraine;

        public static Holiday IndependenceDayOfUkraine
        {
            get
            {
                if (independenceDayOfUkraine == null)
                {
                    independenceDayOfUkraine = new FixedHoliday("Independence Day of Ukraine", 8, 24);
                }
                return independenceDayOfUkraine;
            }
        }

        private static Holiday defendersDay;

        public static Holiday DefendersDay
        {
            get
            {
                if (defendersDay == null)
                {
                    defendersDay = new FixedHoliday("Defenders Day", 10, 1);
                }
                return defendersDay;
            }
        }
    }
}