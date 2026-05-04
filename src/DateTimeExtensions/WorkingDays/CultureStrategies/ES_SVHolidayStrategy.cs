using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("es-SV")]
    public class ES_SVHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public ES_SVHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(ChristianHolidays.MaundyThursday);
            this.InnerObservances.AddHoliday(ChristianHolidays.GoodFriday);
            this.InnerObservances.AddHoliday(ChristianHolidays.EasterSaturday);
            this.InnerObservances.AddHoliday(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.AddHoliday(MothersDay);
            this.InnerObservances.AddHoliday(FathersDay);
            this.InnerObservances.AddHoliday(DivineSaviourOfTheWorld);
            this.InnerObservances.AddHoliday(ChristianHolidays.DayOfTheDead);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
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
