using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("es-SV")]
    public class ES_SVHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public ES_SVHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.MaundyThursday);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(ChristianHolidays.EasterSaturday);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(MothersDay);
            this.InnerHolidays.Add(FathersDay);
            this.InnerHolidays.Add(DivineSaviourOfTheWorld);
            this.InnerHolidays.Add(ChristianHolidays.DayOfTheDead);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
        }

        private static Holiday _mothersDay;
        private static Holiday _fathersDay;
        private static Holiday _divineSaviourOfTheWorld;
        private static Holiday _independenceDay;

        public static Holiday MothersDay
        {
            get
            {
                if (_mothersDay == null)
                {
                    _mothersDay = new FixedHoliday("Mother's Day", 5, 10);
                }

                return _mothersDay;
            }
        }
        public static Holiday FathersDay
        {
            get
            {
                if (_fathersDay == null)
                {
                    _fathersDay = new FixedHoliday("Father's Day", 6, 17);
                }

                return _fathersDay;
            }
        }

        public static Holiday DivineSaviourOfTheWorld
        {
            get
            {
                if (_divineSaviourOfTheWorld == null)
                {
                    _divineSaviourOfTheWorld = new FixedHoliday("Divine Saviour of the World", 8, 6);
                }

                return _divineSaviourOfTheWorld;
            }
        }

        public static Holiday IndependenceDay
        {
            get
            {
                if (_independenceDay == null)
                {
                    _independenceDay = new FixedHoliday("Independence Day", 9, 15);
                }

                return _independenceDay;
            }
        }
    }
}
