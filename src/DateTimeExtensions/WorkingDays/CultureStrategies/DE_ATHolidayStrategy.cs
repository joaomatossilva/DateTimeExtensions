using System;
using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("de-AT")]
    public class DE_ATHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public DE_ATHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Epiphany));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.GoodFriday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.EasterMonday));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.InternationalWorkersDay));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Ascension));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.PentecostMonday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.CorpusChristi));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Assumption));
            this.InnerCalendarDays.Add(new Holiday(AustrianNationalHoliday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.AllSaints));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.ImaculateConception));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.StStephansDay));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYearsEve));
        }
            
        public static NamedDayInitializer AustrianNationalHoliday { get; } = new NamedDayInitializer(() =>
            new NamedDay("Austrian National Holiday", new FixedDayStrategy(Month.October, 26)));
    }
}
