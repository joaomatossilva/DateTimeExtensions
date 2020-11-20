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
using System.Globalization;
using System.Linq;
using System.Text;
using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("ko-KR")]
    public class KO_KRHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        private static readonly Calendar KoreanLunisolarCalendar = new KoreanLunisolarCalendar();

        public KO_KRHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(Samiljeol));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.InternationalWorkersDay));
            this.InnerCalendarDays.Add(new Holiday(SeokgaTansinil));
            this.InnerCalendarDays.Add(new Holiday(Hyeonchungil));
            this.InnerCalendarDays.Add(new Holiday(Gwangbokjeol));
            this.InnerCalendarDays.Add(new Holiday(Gaecheonjeol));
            this.InnerCalendarDays.Add(new Holiday(Hangulnal));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));

            // Add these later for substitute holiday rule application when overlapped with other holidays.
            this.InnerCalendarDays.Add(new Holiday(Seolnal));
            this.InnerCalendarDays.Add(new Holiday(Chuseok));
            this.InnerCalendarDays.Add(new Holiday(Eorininal));
        }

        //refactored. initial credit to jaeseonc
        protected override IEnumerable<KeyValuePair<DateTime, CalendarDay>> GetYearObservances(int year)
        {
            var listOfDays = new HashSet<DateTime>();
            foreach (var calendarDay in InnerCalendarDays)
            {
                var date = calendarDay.Day.GetInstance(year);
                if (date == null)
                {
                    continue;
                }
                
                //we'll handle Eorininal after all others in order to check for overlaps
                if (calendarDay.Day == Eorininal)
                {
                    continue;
                }

                if (calendarDay.Day == Seolnal || calendarDay.Day == Chuseok)
                {
                    DateTime[] observedDates = new DateTime[] { 
                        date.Value.AddDays(-1),
                        date.Value, 
                        date.Value.AddDays(1)
                    };

                    foreach (var observedDate in observedDates)
                    {
                        yield return new KeyValuePair<DateTime, CalendarDay>(
                            observedDate,
                            new Holiday(calendarDay.Day));
                        
                        //TODO: validate special cases => If any of days fall on sunday, add Extra day
                        //Original code wasn't very clear
                        if (observedDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            var extraDate = observedDates.Last().AddDays(1);
                            yield return new KeyValuePair<DateTime, CalendarDay>(
                                extraDate,
                                new Holiday(calendarDay.Day));
                        }
                    }
                }
                else if (calendarDay.Day == Eorininal)
                {
                    yield return new KeyValuePair<DateTime, CalendarDay>(
                        date.Value,
                        new Holiday(Eorininal));

                    if (date.Value.DayOfWeek == DayOfWeek.Saturday ||
                        date.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        var observance = new Holiday(
                            new NamedDay(
                                Eorininal.Value.Name,
                                new NthDayOfWeekAfterDayStrategy(1, DayOfWeek.Monday, new NamedDayStrategy(Eorininal))
                            ));
                        var observanceDay = observance.Day.GetInstance(year);
                        if (observanceDay != null)
                        {
                            yield return new KeyValuePair<DateTime, CalendarDay>(
                                observanceDay.Value,
                                observance);
                        }
                    }
                }
                else
                {
                    listOfDays.Add(date.Value);
                    yield return new KeyValuePair<DateTime, CalendarDay>(
                        date.Value,
                        calendarDay);
                }
            }
        }
        
        /*
         * Original Code kept to help enhance the refactoring rules
         */
        
        // protected override IDictionary<DateTime, CalendarDay> BuildObservancesMap(int year)
        // {
        //     IDictionary<DateTime, CalendarDay> holidayMap = new Dictionary<DateTime, CalendarDay>();
        //     foreach (var innerHoliday in InnerCalendarDays)
        //     {
        //         var date = innerHoliday.Day.GetInstance(year);
        //         if (date.HasValue)
        //         {
        //             if (innerHoliday.Day == Seolnal || innerHoliday.Day == Chuseok) {
        //                 DateTime[] holidays = new DateTime[] { 
        //                     date.Value.AddDays(-1),
        //                     date.Value, 
        //                     date.Value.AddDays(1)
        //                 };
        //                 AddSubstituteHoliday(holidayMap, holidays, innerHoliday);
        //                 foreach (DateTime holiday in holidays)
        //                 {
        //                     holidayMap.Add(holiday, innerHoliday);
        //                 }
        //             }
        //             else if (innerHoliday.Day == Eorininal)
        //             {
        //                 // Special substitute holiday rule for Eorininal(May 5, children's day)
        //                 // effective since Oct. 29, 2013.
        //                 DateTime childrensDay = date.Value;
        //                 CalendarDay overlappedHoliday = null;
        //                 while (childrensDay.DayOfWeek == DayOfWeek.Saturday ||
        //                         childrensDay.DayOfWeek == DayOfWeek.Sunday ||
        //                         holidayMap.TryGetValue(childrensDay, out overlappedHoliday))
        //                 {
        //                     childrensDay = childrensDay.AddDays(1);
        //                 }
        //                 holidayMap.Add(childrensDay, innerHoliday);
        //             }
        //             else
        //             {
        //                 holidayMap.Add(date.Value, innerHoliday);
        //             }
        //         }
        //     }
        //     return holidayMap;
        // }
        //
        // // Special substitute holiday rule for Seol(lunisolar new year) and Chuseok(15th of 8th lunisolar month)
        // // effective since Oct. 29, 2013.
        // private void AddSubstituteHoliday(IDictionary<DateTime, CalendarDay> holidayMap, DateTime[] dates, CalendarDay holiday)
        // {
        //     foreach (DateTime date in dates)
        //     {
        //         CalendarDay overlappedHoliday = null;
        //         if (date.DayOfWeek == DayOfWeek.Sunday || 
        //             holidayMap.TryGetValue(date, out overlappedHoliday) && overlappedHoliday != holiday)
        //         {
        //             DateTime substituteDay = dates.Last().AddDays(1);
        //             while (substituteDay.DayOfWeek == DayOfWeek.Sunday ||
        //                     holidayMap.TryGetValue(date, out overlappedHoliday) && overlappedHoliday != holiday)
        //             {
        //                 substituteDay = substituteDay.AddDays(1);
        //             }
        //             holidayMap.Add(substituteDay, holiday);
        //         }
        //     }
        // }

        public static NamedDayInitializer Seolnal { get; } = new NamedDayInitializer(() => 
            new NamedDay("Seolnal", new FixedDayStrategy(1, 1, KoreanLunisolarCalendar)));

        public static NamedDayInitializer Samiljeol { get; } = new NamedDayInitializer(() => 
            new NamedDay("Samiljeol", new FixedDayStrategy(3, 1)));

        public static NamedDayInitializer Eorininal { get; } = new NamedDayInitializer(() => 
            new NamedDay("Eorininal", new FixedDayStrategy(5, 5)));

        public static NamedDayInitializer SeokgaTansinil { get; } = new NamedDayInitializer(() => 
            new NamedDay("SeokgaTansinil", new FixedDayStrategy(4, 8, KoreanLunisolarCalendar)));

        public static NamedDayInitializer Hyeonchungil { get; } = new NamedDayInitializer(() => 
            new NamedDay("Hyeonchungil", new FixedDayStrategy(6, 6)));

        public static NamedDayInitializer Gwangbokjeol { get; } = new NamedDayInitializer(() => 
            new NamedDay("Gwangbokjeol", new FixedDayStrategy(8, 15)));

        public static NamedDayInitializer Chuseok { get; } = new NamedDayInitializer(() => 
            new NamedDay("Chuseok", new FixedDayStrategy(8, 15, KoreanLunisolarCalendar)));

        public static NamedDayInitializer Gaecheonjeol { get; } = new NamedDayInitializer(() => 
            new NamedDay("Gaecheonjeol", new FixedDayStrategy(10, 3)));

        public static NamedDayInitializer Hangulnal { get; } = new NamedDayInitializer(() => 
            new NamedDay("Hangulnal", new FixedDayStrategy(10, 9)));
    }
}