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
    public class EN_NGHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_NGHolidayStrategy()
        {
            InnerHolidays.Add(GlobalHolidays.NewYear);

            InnerHolidays.Add(ChristianHolidays.GoodFriday);
            InnerHolidays.Add(ChristianHolidays.EasterMonday);
            InnerHolidays.Add(ChristianHolidays.Christmas);

            InnerHolidays.Add(IndependenceDay);
            InnerHolidays.Add(DemocracyDay);

            InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            InnerHolidays.Add(GlobalHolidays.BoxingDay);
        }

        protected override IDictionary<DateTime, NamedDay> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, NamedDay> holidayMap = new Dictionary<DateTime, NamedDay>();
            foreach (var innerHoliday in InnerHolidays)
            {
                var date = innerHoliday.GetInstance(year);
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
                        holidayMap.AddIfInexistent(date.Value.AddDays(1), innerHoliday);
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
