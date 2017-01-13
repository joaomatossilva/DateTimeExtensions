using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("de-AT")]
    public class DE_ATHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public DE_ATHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.Epiphany);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(ChristianHolidays.Ascension);
            this.InnerHolidays.Add(ChristianHolidays.PentecostMonday);
            this.InnerHolidays.Add(ChristianHolidays.CorpusChristi);
            this.InnerHolidays.Add(ChristianHolidays.Assumption);
            this.InnerHolidays.Add(AustrianNationalHoliday);
            this.InnerHolidays.Add(ChristianHolidays.AllSaints);
            this.InnerHolidays.Add(ChristianHolidays.ImaculateConception);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(ChristianHolidays.StStephansDay);
            this.InnerHolidays.Add(GlobalHolidays.NewYearsEve);
        }

        private static Holiday austrianNationalHoliday;

        public static Holiday AustrianNationalHoliday
        {
            get
            {
                if (austrianNationalHoliday == null)
                {
                    austrianNationalHoliday = new FixedHoliday("Austrian National Holiday", 10, 26);
                }
                return austrianNationalHoliday;
            }
        }
    }
}
