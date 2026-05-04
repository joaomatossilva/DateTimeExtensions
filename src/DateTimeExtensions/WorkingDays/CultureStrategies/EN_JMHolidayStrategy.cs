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

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-JM")]
    public class EN_JMHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_JMHolidayStrategy()
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(ChristianHolidays.AshWednesday);
            this.InnerObservances.Add(ChristianHolidays.GoodFriday);
            this.InnerObservances.Add(ChristianHolidays.EasterMonday);

            this.InnerObservances.Add(LaborDay);
            this.InnerObservances.Add(EmancipationDay);
            this.InnerObservances.Add(IndependenceDay);
            this.InnerObservances.Add(NationalHeroesDay);

            this.InnerObservances.Add(ChristianHolidays.Christmas);
            this.InnerObservances.Add(GlobalHolidays.BoxingDay);
        }
        protected override IDictionary<DateTime, NamedDay> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, NamedDay> holidayMap =
            this.InnerObservances.Select(h => new { Date = h.GetInstance(year), NamedDay = h })
                .Where(h => h.Date.HasValue)
                .GroupBy(h => h.Date).Select(g => new { Date = g.Key, g.First().NamedDay })
                .ToDictionary(k => k.Date.Value, v => v.NamedDay);


            if (holidayMap.Any(h => h.Key.DayOfWeek == DayOfWeek.Sunday))
            {//Holidays falling on Sunday is observed on Monday
                var sundayHolidays = holidayMap.OrderBy(d => d.Key).Where(s => s.Key.DayOfWeek == DayOfWeek.Sunday);
                foreach (var h in sundayHolidays)
                {
                    var sundayHoliday = h;

                    var observation = new NamedDay(
                        sundayHoliday.Value.Name + " Observed",
                        new NthDayOfWeekAfterDayResolver(1, DayOfWeek.Monday, sundayHoliday.Value.Resolver));
                    var dateObserved = observation.GetInstance(year);

                    if (holidayMap.ContainsKey(dateObserved.Value))
                    {//if a holiday is already observed on the new date, remove from map and find new date of observance
                        var existingMondayHoliday = holidayMap.First(m => m.Key == dateObserved.Value);
                        holidayMap.Remove(dateObserved.Value);

                        var observedOn = dateObserved.Value.AddDays(1);//New Date for removed holiday
                        while (holidayMap.ContainsKey(observedOn) && observedOn.DayOfWeek != DayOfWeek.Sunday)
                            observedOn.AddDays(1);//check for all existing holidays to find free date

                        var daysAfter = existingMondayHoliday.Key.GetDiff(observedOn).Days;
                        var holidayMoved = new NamedDay(
                            existingMondayHoliday.Value.Name + " Observed",
                            new NthDayOfWeekAfterDayResolver(daysAfter, observedOn.DayOfWeek, existingMondayHoliday.Value.Resolver));

                        var newObservedDate = holidayMoved.GetInstance(year);

                        holidayMap.Add(newObservedDate.Value, holidayMoved);
                    }
                    holidayMap.Remove(sundayHoliday.Key);
                    holidayMap.Add(dateObserved.Value, observation);
                }


            }
            return holidayMap;
        }

        private NamedDay laborDay;
        public NamedDay LaborDay
        {
            get
            {
                if (laborDay == null)
                    laborDay = new NamedDay("Labor Day", new FixedDayResolver(5, 23));
                return laborDay;
            }
        }
        private NamedDay emancipationDay;
        public NamedDay EmancipationDay
        {
            get
            {
                if (emancipationDay == null)
                    emancipationDay = new NamedDay("Emancipation Day", new FixedDayResolver(8, 1));
                return emancipationDay;
            }
        }
        private NamedDay independenceDay;
        public NamedDay IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                    independenceDay = new NamedDay("Independence Day", new FixedDayResolver(8, 6));
                return independenceDay;
            }
        }
        private NamedDay nationalHeroesDay;
        public NamedDay NationalHeroesDay
        {
            get
            {
                if (nationalHeroesDay == null)
                    nationalHeroesDay = new NamedDay("National Heroes Day", new NthDayOfWeekInMonthDayResolver(3, DayOfWeek.Monday, 10, CountDirection.FromFirst));
                return nationalHeroesDay;
            }
        }
    }
}
