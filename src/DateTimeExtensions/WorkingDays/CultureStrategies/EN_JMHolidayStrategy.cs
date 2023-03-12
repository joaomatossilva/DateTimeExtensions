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
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.AshWednesday);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);

            this.InnerHolidays.Add(LaborDay);
            this.InnerHolidays.Add(EmancipationDay);
            this.InnerHolidays.Add(IndependenceDay);
            this.InnerHolidays.Add(NationalHeroesDay);

            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(GlobalHolidays.BoxingDay);
        }
        protected override IDictionary<DateTime, Holiday> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Holiday> holidayMap = 
            this.InnerHolidays.Select(h => new { Date = h.GetInstance(year), Holiday = h })
                .Where(h => h.Date.HasValue)
                .GroupBy(h => h.Date).Select(g => new { Date = g.Key, g.First().Holiday })
                .ToDictionary(k => k.Date.Value, v => v.Holiday);
            
            foreach(var h in holidayMap)
            {
                if (h.Key.DayOfWeek == DayOfWeek.Sunday)
                {
                    var sundayHoliday = h;
                    var dateObserved = h.Key.AddDays(1);

                    if (holidayMap.ContainsKey(dateObserved))
                    {//if a holiday is already observed on the new date, remove from map and find new date of observance
                        var existingMondayHoliday = holidayMap.First(m => m.Key == dateObserved);
                        holidayMap.Remove(dateObserved);
                        var observedOn = dateObserved.AddDays(1);
                        while (holidayMap.ContainsKey(observedOn) && observedOn.DayOfWeek != DayOfWeek.Sunday)
                            observedOn.AddDays(1);
                        holidayMap.Add(observedOn, existingMondayHoliday.Value);
                    }
                    holidayMap.Add(sundayHoliday.Key.AddDays(1), h.Value);
                   
                }
               
            }
            return holidayMap;
        }

        private Holiday laborDay;
        public Holiday LaborDay
        {
            get
            {
                if (laborDay == null)
                    laborDay = new FixedHoliday("Labor Day", 5, 23);
                return laborDay;
            }
        }
        private Holiday emancipationDay;
        public Holiday EmancipationDay
        {
            get
            {
                if (emancipationDay == null)
                    emancipationDay = new FixedHoliday("Emancipation Day", 8, 1);
                return emancipationDay;
            }
        }
        private Holiday independenceDay;
        public Holiday IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                    independenceDay = new FixedHoliday("Independence Day", 8, 6);
                return independenceDay;
            }
        }
        private Holiday nationalHeroesDay;
        public Holiday NationalHeroesDay
        {
            get
            {
                if (nationalHeroesDay == null)
                    nationalHeroesDay = new FixedHoliday("National Heroes Day", 10, 16);
                return nationalHeroesDay;
            }
        }
    }
}