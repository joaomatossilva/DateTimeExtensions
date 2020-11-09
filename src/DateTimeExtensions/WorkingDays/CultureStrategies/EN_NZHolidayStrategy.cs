using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-NZ")]
    public class EN_NZHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        // Rules / Dates sourced from
        //		http://www.dol.govt.nz/er/holidaysandleave/publicholidays/publicholidaydates/future-dates.asp
        //		http://www.whatdate.co.nz/

        public EN_NZHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(DayAfterNewYear));
            this.InnerCalendarDays.Add(new Holiday(WaitangiDay));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.GoodFriday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Easter));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.EasterMonday));
            this.InnerCalendarDays.Add(new Holiday(AnzacDay));
            this.InnerCalendarDays.Add(new Holiday(QueensBirthday));
            this.InnerCalendarDays.Add(new Holiday(LabourDay));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.BoxingDay));
        }

        protected override IDictionary<DateTime, CalendarDay> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, CalendarDay> holidayMap = new Dictionary<DateTime, CalendarDay>();
            foreach (var innerHoliday in InnerCalendarDays)
            {
                var date = innerHoliday.Day.GetInstance(year);
                if (date.HasValue)
                {
                    holidayMap.Add(date.Value, innerHoliday);

                    // New Year, Day After New Year, Christmas and Boxing Days are 'Mondayised'
                    // ie if these dates fall on a weekday then they are observed on the actual day.
                    // If they fall on a weekend then they are observed on the following Monday/Tuesday

                    if (IsMondayised(innerHoliday, date.Value.DayOfWeek))
                    {
                        var observation = new Holiday(new NamedDay(
                            innerHoliday.Day.Name + " Observed", 
                            new NthDayOfWeekAfterDayStrategy(1, DayOfWeek.Monday, new NamedDayStrategy(innerHoliday.Day))));
                        var observedIntance = observation.Day.GetInstance(year);
                        if (observedIntance != null)
                        {
                            holidayMap.Add(observedIntance.Value, observation);
                        }
                    }
                    if (IsTuesdayised(innerHoliday, date.Value.DayOfWeek))
                    {
                        var observation = new Holiday(new NamedDay(
                            innerHoliday.Day.Name + " Observed", 
                            new NthDayOfWeekAfterDayStrategy(1, DayOfWeek.Tuesday, new NamedDayStrategy(innerHoliday.Day))));
                        var observedIntance = observation.Day.GetInstance(year);
                        if (observedIntance != null)
                        {
                            holidayMap.Add(observedIntance.Value, observation);
                        }
                    }
                }
            }
            return holidayMap;
        }


        private static bool IsMondayised(CalendarDay holiday, DayOfWeek occurenceDay)
        {
            return
                (holiday.Equals(GlobalHolidays.NewYear) && occurenceDay == DayOfWeek.Saturday) ||
                (holiday.Equals(DayAfterNewYear) && occurenceDay == DayOfWeek.Saturday) ||
                (holiday.Equals(ChristianHolidays.Christmas) && occurenceDay == DayOfWeek.Saturday) ||
                (holiday.Equals(GlobalHolidays.BoxingDay) && occurenceDay == DayOfWeek.Saturday);
        }

        private static bool IsTuesdayised(CalendarDay holiday, DayOfWeek occurenceDay)
        {
            return
                (holiday.Equals(GlobalHolidays.NewYear) && occurenceDay == DayOfWeek.Sunday) ||
                (holiday.Equals(DayAfterNewYear) && occurenceDay == DayOfWeek.Sunday) ||
                (holiday.Equals(ChristianHolidays.Christmas) && occurenceDay == DayOfWeek.Sunday) ||
                (holiday.Equals(GlobalHolidays.BoxingDay) && occurenceDay == DayOfWeek.Sunday);
        }


        // 2nd Janurary - Day after New Year's Day
        private static readonly Lazy<NamedDay> DayAfterNewYearLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Day after New Year's Day", new FixedDayStrategy(Month.January, 2)));
        public static NamedDay DayAfterNewYear => DayAfterNewYearLazy.Value;

        // 6th Feburary - Waitangi Day
        private static readonly Lazy<NamedDay> WaitangiDayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Waitangi Day", new FixedDayStrategy(Month.February, 6)));
        public static NamedDay WaitangiDay => WaitangiDayLazy.Value;

        // 25th April - Anzac Day
        private static readonly Lazy<NamedDay> AnzacDayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Anzac Day", new FixedDayStrategy(Month.April, 25)));
        public static NamedDay AnzacDay => AnzacDayLazy.Value;

        // 1st Monday in June - Queen's Birthday
        private static readonly Lazy<NamedDay> QueensBirthdayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Queen's Birthday", new NthDayOfWeekInMonthDayStrategy(1, DayOfWeek.Monday, Month.July, CountDirection.FromFirst)));
        public static NamedDay QueensBirthday => QueensBirthdayLazy.Value;
        
        // 4th Monday in October - Labour Day
        private static readonly Lazy<NamedDay> LabourDayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Labour Day", new NthDayOfWeekInMonthDayStrategy(1, DayOfWeek.Monday, Month.October, CountDirection.FromFirst)));
        public static NamedDay LabourDay => LabourDayLazy.Value;
        
        // Todo: Regional Holidays
    }
}