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
    [Locale("es-ES")]
    public class ES_ESHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public ES_ESHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Epiphany));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.GoodFriday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.ImaculateConception));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Assumption));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.AllSaints));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));

            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.InternationalWorkersDay));
            this.InnerCalendarDays.Add(new Holiday(NationalDay));
            this.InnerCalendarDays.Add(new Holiday(ConstitutionDay));
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
                
                //if the holiday is a sunday, the holiday is observed on next monday
                if (date.Value.DayOfWeek == DayOfWeek.Sunday)
                {
                    yield return new KeyValuePair<DateTime, CalendarDay>(
                        date.Value.AddDays(1),
                        new Holiday(
                            new NamedDay(
                                calendarDay.Day.Name + " Observed",
                                new NthDayAfterDayStrategy(1, new NamedDayStrategy(calendarDay.Day)))));
                }
            }
        }

        public static NamedDayInitializer NationalDay { get; } = new NamedDayInitializer(() => 
            new NamedDay("Espanha_NationalDay", new FixedDayStrategy(Month.October, 12)));

        public static NamedDayInitializer ConstitutionDay { get; } = new NamedDayInitializer(() => 
            new NamedDay("Espanha_ConstitutionDay", new FixedDayStrategy(Month.December, 6)));
    }
}