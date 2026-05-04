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
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-NG")] 
    public class EN_NGHolidayStrategy : HolidayStrategyBase, IObservancesStrategy
    {
        public EN_NGHolidayStrategy()
        {
            InnerObservances.AddHoliday(GlobalHolidays.NewYear);

            InnerObservances.AddHoliday(ChristianHolidays.GoodFriday);
            InnerObservances.AddHoliday(ChristianHolidays.EasterMonday);
            InnerObservances.AddHoliday(ChristianHolidays.Christmas);

            InnerObservances.AddHoliday(IndependenceDay);
            InnerObservances.AddHoliday(DemocracyDay);

            InnerObservances.AddHoliday(GlobalHolidays.InternationalWorkersDay);
            InnerObservances.AddHoliday(GlobalHolidays.BoxingDay);
        }

        protected override IDictionary<DateTime, Observance> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Observance> holidayMap = new Dictionary<DateTime, Observance>();
            foreach (var innerHoliday in InnerObservances)
            {
                var date = innerHoliday.CalendarDay.GetInstance(year);
                if (date.HasValue)
                {
                    if (holidayMap.ContainsKey(date.Value))
                    {
                        // Check to see if holiday falling on the Sunday then moves to the monday, and there is another holiday scheduled for the monday
                        // Update the NamedDay Name of the Monday
                        holidayMap[date.Value] = innerHoliday;
                    }

                    else
                    {
                        holidayMap.Add(date.Value, innerHoliday);
                    }

                    //if the holiday is a sunday, the holiday is observed on next monday
                    if (date.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        var observedDate = date.Value.AddDays(1);
                        holidayMap.AddIfInexistent(
                            observedDate,
                            new Observance(new NamedDay(innerHoliday.CalendarDay.Name, new FixedDayResolver(observedDate.Month, observedDate.Day)), true));
                    }
                }
            }
            return holidayMap;
        }

        // 12 June - Democracy Day
        private static NamedDay democracyDay;
        public static NamedDay DemocracyDay
        {
            get
            {
                if (democracyDay == null)
                {
                    democracyDay = new NamedDay("Democracy Day", new FixedDayResolver(6, 12));
                }
                return democracyDay;
            }
        }

        // 1st October - Independence Day
        private static NamedDay independenceDay;
        public static NamedDay IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new NamedDay("IndependenceDay Day", new FixedDayResolver(10, 1));
                }
                return independenceDay;
            }
        }
    }
}
