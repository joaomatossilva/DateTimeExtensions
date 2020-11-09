using DateTimeExtensions.Common;
using System.Globalization;
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-IN")]
    public class IndianHolidayStrategy : HolidayStrategyBase
    {
        private static readonly Calendar IndianCalendar = new GregorianCalendar(GregorianCalendarTypes.Localized);

        public IndianHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.MayDay));
            this.InnerCalendarDays.Add(new Holiday(IndependenceDay));
            this.InnerCalendarDays.Add(new Holiday(RepublicDay));
            this.InnerCalendarDays.Add(new Holiday(GandhiBirthAnniversary));
        }

        public static NamedDayInitializer IndependenceDay { get; } = new NamedDayInitializer(() => 
            new NamedDay("Independence Day", new FixedDayStrategy(8, 15, IndianCalendar)));

        public static NamedDayInitializer RepublicDay { get; } = new NamedDayInitializer(() => 
            new NamedDay("Republic Day", new FixedDayStrategy(1, 26, IndianCalendar)));
        
        public static NamedDayInitializer GandhiBirthAnniversary { get; } = new NamedDayInitializer(() => 
            new NamedDay("Gandhi's Birth Anniversary", new FixedDayStrategy(10, 2, IndianCalendar)));
    }
}