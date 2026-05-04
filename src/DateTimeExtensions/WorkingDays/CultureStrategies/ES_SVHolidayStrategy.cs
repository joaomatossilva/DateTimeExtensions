using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("es-SV")]
    public class ES_SVHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public ES_SVHolidayStrategy()
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(ChristianHolidays.MaundyThursday);
            this.InnerObservances.Add(ChristianHolidays.GoodFriday);
            this.InnerObservances.Add(ChristianHolidays.EasterSaturday);
            this.InnerObservances.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.Add(MothersDay);
            this.InnerObservances.Add(FathersDay);
            this.InnerObservances.Add(DivineSaviourOfTheWorld);
            this.InnerObservances.Add(ChristianHolidays.DayOfTheDead);
            this.InnerObservances.Add(ChristianHolidays.Christmas);
        }

        private static NamedDay _mothersDay;
        private static NamedDay _fathersDay;
        private static NamedDay _divineSaviourOfTheWorld;
        private static NamedDay _independenceDay;

        public static NamedDay MothersDay
        {
            get
            {
                if (_mothersDay == null)
                {
                    _mothersDay = new NamedDay("Mother's Day", new FixedDayResolver(5, 10));
                }

                return _mothersDay;
            }
        }
        public static NamedDay FathersDay
        {
            get
            {
                if (_fathersDay == null)
                {
                    _fathersDay = new NamedDay("Father's Day", new FixedDayResolver(6, 17));
                }

                return _fathersDay;
            }
        }

        public static NamedDay DivineSaviourOfTheWorld
        {
            get
            {
                if (_divineSaviourOfTheWorld == null)
                {
                    _divineSaviourOfTheWorld = new NamedDay("Divine Saviour of the World", new FixedDayResolver(8, 6));
                }

                return _divineSaviourOfTheWorld;
            }
        }

        public static NamedDay IndependenceDay
        {
            get
            {
                if (_independenceDay == null)
                {
                    _independenceDay = new NamedDay("Independence Day", new FixedDayResolver(9, 15));
                }

                return _independenceDay;
            }
        }
    }
}
