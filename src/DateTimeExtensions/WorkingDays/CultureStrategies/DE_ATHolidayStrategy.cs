using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("de-AT")]
    public class DE_ATHolidayStrategy : HolidayStrategyBase, IObservancesStrategy
    {
        public DE_ATHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(ChristianHolidays.Epiphany);
            this.InnerObservances.AddHoliday(ChristianHolidays.EasterMonday);
            this.InnerObservances.AddHoliday(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Ascension);
            this.InnerObservances.AddHoliday(ChristianHolidays.PentecostMonday);
            this.InnerObservances.AddHoliday(ChristianHolidays.CorpusChristi);
            this.InnerObservances.AddHoliday(ChristianHolidays.Assumption);
            this.InnerObservances.AddHoliday(AustrianNationalHoliday);
            this.InnerObservances.AddHoliday(ChristianHolidays.AllSaints);
            this.InnerObservances.AddHoliday(ChristianHolidays.ImaculateConception);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
            this.InnerObservances.AddHoliday(ChristianHolidays.StStephansDay);
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYearsEve);
        }

        private static NamedDay austrianNationalHoliday;

        public static NamedDay AustrianNationalHoliday
        {
            get
            {
                if (austrianNationalHoliday == null)
                {
                    austrianNationalHoliday = new NamedDay("Austrian National NamedDay", new FixedDayResolver(10, 26));
                }
                return austrianNationalHoliday;
            }
        }
    }
}
