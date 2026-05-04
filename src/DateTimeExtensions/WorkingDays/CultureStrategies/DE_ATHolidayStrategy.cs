using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("de-AT")]
    public class DE_ATHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public DE_ATHolidayStrategy()
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(ChristianHolidays.Epiphany);
            this.InnerObservances.Add(ChristianHolidays.EasterMonday);
            this.InnerObservances.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.Add(ChristianHolidays.Ascension);
            this.InnerObservances.Add(ChristianHolidays.PentecostMonday);
            this.InnerObservances.Add(ChristianHolidays.CorpusChristi);
            this.InnerObservances.Add(ChristianHolidays.Assumption);
            this.InnerObservances.Add(AustrianNationalHoliday);
            this.InnerObservances.Add(ChristianHolidays.AllSaints);
            this.InnerObservances.Add(ChristianHolidays.ImaculateConception);
            this.InnerObservances.Add(ChristianHolidays.Christmas);
            this.InnerObservances.Add(ChristianHolidays.StStephansDay);
            this.InnerObservances.Add(GlobalHolidays.NewYearsEve);
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
