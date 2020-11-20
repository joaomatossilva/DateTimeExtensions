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

        //Before refactoring, Credit to David Smith
        protected override IEnumerable<KeyValuePair<DateTime, CalendarDay>> GetYearObservances(int year)
        {
            foreach (var calendarDay in InnerCalendarDays)
            {
                var date = calendarDay.Day.GetInstance(year);
                if (date == null)
                {
                    continue;
                }
                
                yield return new KeyValuePair<DateTime, CalendarDay>(date.Value, calendarDay);

                // New Year, Day After New Year, Christmas and Boxing Days are 'Mondayised'
                // ie if these dates fall on a weekday then they are observed on the actual day.
                // If they fall on a weekend then they are observed on the following Monday/Tuesday
                if (IsMondayised(calendarDay, date.Value.DayOfWeek))
                {
                    var observation = new Holiday(new NamedDay(
                        calendarDay.Day.Name + " Observed", 
                        new NthDayOfWeekAfterDayStrategy(1, DayOfWeek.Monday, new NamedDayStrategy(calendarDay.Day))));
                    var observedInstance = observation.Day.GetInstance(year);
                    if (observedInstance != null)
                    {
                        yield return new KeyValuePair<DateTime, CalendarDay>(
                            observedInstance.Value,
                            observation);
                    }
                }
                else if (IsTuesdayised(calendarDay, date.Value.DayOfWeek))
                {
                    var observation = new Holiday(new NamedDay(
                        calendarDay.Day.Name + " Observed", 
                        new NthDayOfWeekAfterDayStrategy(1, DayOfWeek.Tuesday, new NamedDayStrategy(calendarDay.Day))));
                    var observedInstance = observation.Day.GetInstance(year);
                    if (observedInstance != null)
                    {
                        yield return new KeyValuePair<DateTime, CalendarDay>(
                            observedInstance.Value,
                            observation);
                    }
                }
            }
        }

        //TODO: improve this to be more behavioral instead of conjuntction of ors and ands
        private static bool IsMondayised(CalendarDay holiday, DayOfWeek occurenceDay)
        {
            return
                (holiday.Day == GlobalHolidays.NewYear && occurenceDay == DayOfWeek.Saturday) ||
                (holiday.Day == DayAfterNewYear && occurenceDay == DayOfWeek.Saturday) ||
                (holiday.Day == ChristianHolidays.Christmas && occurenceDay == DayOfWeek.Saturday) ||
                (holiday.Day == GlobalHolidays.BoxingDay && occurenceDay == DayOfWeek.Saturday);
        }

        private static bool IsTuesdayised(CalendarDay holiday, DayOfWeek occurenceDay)
        {
            return
                (holiday.Day == GlobalHolidays.NewYear && occurenceDay == DayOfWeek.Sunday) ||
                (holiday.Day == DayAfterNewYear && occurenceDay == DayOfWeek.Sunday) ||
                (holiday.Day == ChristianHolidays.Christmas && occurenceDay == DayOfWeek.Sunday) ||
                (holiday.Day == GlobalHolidays.BoxingDay && occurenceDay == DayOfWeek.Sunday);
        }


        // 2nd Janurary - Day after New Year's Day
        public static NamedDayInitializer DayAfterNewYear { get; } = new NamedDayInitializer(() =>
            new NamedDay("Day after New Year's Day", new FixedDayStrategy(Month.January, 2)));

        // 6th Feburary - Waitangi Day
        public static NamedDayInitializer WaitangiDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Waitangi Day", new FixedDayStrategy(Month.February, 6)));

        // 25th April - Anzac Day
        public static NamedDayInitializer AnzacDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Anzac Day", new FixedDayStrategy(Month.April, 25)));

        // 1st Monday in June - Queen's Birthday
        public static NamedDayInitializer QueensBirthday { get; } = new NamedDayInitializer(() =>
            new NamedDay("Queen's Birthday", new NthDayOfWeekInMonthDayStrategy(1, DayOfWeek.Monday, Month.July, 
                CountDirection.FromFirst)));
        
        // 4th Monday in October - Labour Day
        public static NamedDayInitializer LabourDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Labour Day", new NthDayOfWeekInMonthDayStrategy(1, DayOfWeek.Monday, Month.October, 
                CountDirection.FromFirst)));
        
        // Todo: Regional Holidays
    }
}