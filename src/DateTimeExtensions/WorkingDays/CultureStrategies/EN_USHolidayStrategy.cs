#region License

// 
// Copyright (c) 2011-2012, João Matos Silva <kappy@acydburne.com.pt>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-US")]
    public class EN_USHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_USHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));
            this.InnerCalendarDays.Add(new Holiday(NewYearsEve));
            this.InnerCalendarDays.Add(new Holiday(IndependenceDay));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.VeteransDay));
            this.InnerCalendarDays.Add(new Holiday(MartinLutherKing));
            this.InnerCalendarDays.Add(new Holiday(WashingtonsBirthday));
            this.InnerCalendarDays.Add(new Holiday(MemorialDay));
            this.InnerCalendarDays.Add(new Holiday(LaborDay));
            this.InnerCalendarDays.Add(new Holiday(ColumbusDay));
            this.InnerCalendarDays.Add(new Holiday(ThanksgivingDay));
        }

        protected override IEnumerable<KeyValuePair<DateTime, CalendarDay>> GetYearObservances(int year)
        {
            foreach (var calendarDay in InnerCalendarDays)
            {
                var date = calendarDay.Day.GetInstance(year);
                if (date == null)
                {
                    continue;
                }
                
                //if the holiday is a saturday, the holiday is observed on previous friday
                switch (date.Value.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        yield return new KeyValuePair<DateTime, CalendarDay>(
                            date.Value.AddDays(-1),
                            new Holiday(
                                new NamedDay(
                                    calendarDay.Day.Name + " Observed", 
                                    new NthDayAfterDayStrategy(-1, new NamedDayStrategy(calendarDay.Day)))));
                        break;
                    case DayOfWeek.Sunday:
                        yield return new KeyValuePair<DateTime, CalendarDay>(
                            date.Value.AddDays(1),
                            new Holiday(
                                new NamedDay(
                                    calendarDay.Day.Name + " Observed", 
                                    new NthDayAfterDayStrategy(1, new NamedDayStrategy(calendarDay.Day)))));
                        break;
                    default:
                        yield return new KeyValuePair<DateTime, CalendarDay>(
                            date.Value,
                            calendarDay);
                        break;
                }
            }
        }
        
        public static NamedDayInitializer IndependenceDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Independence Day", new FixedDayStrategy(Month.July, 4)));


        //Third Monday in January - Birthday of Martin Luther King, Jr.
        public static NamedDayInitializer MartinLutherKing { get; } = new NamedDayInitializer(() =>
            new NamedDay("Birthday of Martin Luther King, Jr.",
                new NthDayOfWeekInMonthDayStrategy(3, DayOfWeek.Monday, Month.January, CountDirection.FromFirst)));

        //Inauguration Day
        //First January 20th following a Presidential election

        //Third Monday in February - Washington's Birthday
        public static NamedDayInitializer WashingtonsBirthday { get; } = new NamedDayInitializer(() =>
            new NamedDay("Washington's Birthday",
                new NthDayOfWeekInMonthDayStrategy(3, DayOfWeek.Monday, Month.February, CountDirection.FromFirst)));

        //Last Monday in May - Memorial Day
        public static NamedDayInitializer MemorialDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Memorial Day",
                new NthDayOfWeekInMonthDayStrategy(1, DayOfWeek.Monday, Month.May, CountDirection.FromLast)));

        //Third Monday in February - Washington's Birthday
        public static NamedDayInitializer LaborDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Labor Day",
                new NthDayOfWeekInMonthDayStrategy(1, DayOfWeek.Monday, Month.September, CountDirection.FromFirst)));

        //Second Monday in October - Columbus Day
        public static NamedDayInitializer ColumbusDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Columbus Day",
                new NthDayOfWeekInMonthDayStrategy(2, DayOfWeek.Monday, Month.October, CountDirection.FromFirst)));

        //Fourth Thursday in November - Thanksgiving Day
        public static NamedDayInitializer ThanksgivingDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Thanksgiving Day",
                new NthDayOfWeekInMonthDayStrategy(1, DayOfWeek.Thursday, Month.October, CountDirection.FromFirst)));

        public static NamedDayInitializer NewYearsEve { get; } = new NamedDayInitializer(() =>
            new NamedDay(GlobalHolidays.NewYearsEve.Value.Name,
                new YearDependantDayStrategy((year) =>
                {
                    var instanceInYear = GlobalHolidays.NewYearsEve.Value.GetInstance(year);
                    return instanceInYear?.DayOfWeek == DayOfWeek.Friday;
                }, new NamedDayStrategy(GlobalHolidays.NewYearsEve))));
    }
}