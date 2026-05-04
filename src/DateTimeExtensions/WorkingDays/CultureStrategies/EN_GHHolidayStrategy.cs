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
    [Locale("en-GH")]
    public class EN_GHHolidayStrategy : HolidayStrategyBase, IObservancesStrategy
    {
        public EN_GHHolidayStrategy()
        {
            InnerObservances.AddHoliday(GlobalHolidays.NewYear);

            InnerObservances.AddHoliday(ChristianHolidays.GoodFriday);
            InnerObservances.AddHoliday(ChristianHolidays.EasterMonday);
            InnerObservances.AddHoliday(ChristianHolidays.Christmas);

            InnerObservances.AddHoliday(IndependenceDay);
            InnerObservances.AddHoliday(LabourDay);
            InnerObservances.AddHoliday(RepublicDay);
            InnerObservances.AddHoliday(AfricaDay);
            InnerObservances.AddHoliday(KwameNkrumahMemorialDay);

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

        // 6th March - Independence Day
        private static NamedDay independenceDay;
        public static NamedDay IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new NamedDay("Independence Day", new FixedDayResolver(3, 6));
                }
                return independenceDay;
            }
        }

        // 1 May - Labour Day
        private static NamedDay labourDay;
        public static NamedDay LabourDay
        {
            get
            {
                if (labourDay == null)
                {
                    labourDay = new NamedDay("Labour Day", new FixedDayResolver(5, 1));
                }
                return labourDay;
            }
        }

        // 25 May - Africa Day
        private static NamedDay africaDay;
        public static NamedDay AfricaDay
        {
            get
            {
                if (africaDay == null)
                {
                    africaDay = new NamedDay("Africa Day", new FixedDayResolver(5, 25));
                }
                return africaDay;
            }
        }

        // 1 July - Republic Day
        private static NamedDay republicDay;
        public static NamedDay RepublicDay
        {
            get
            {
                if (republicDay == null)
                {
                    republicDay = new NamedDay("Republic Day", new FixedDayResolver(7, 1));
                }
                return republicDay;
            }
        }

        // 21 September - Kwame Nkrumah Memorial Day
        private static NamedDay kwameNkrumahMemorialDay;
        public static NamedDay KwameNkrumahMemorialDay
        {
            get
            {
                if (kwameNkrumahMemorialDay == null)
                {
                    kwameNkrumahMemorialDay = new NamedDay("Kwame Nkrumah Memorial Day", new FixedDayResolver(9, 21));
                }
                return kwameNkrumahMemorialDay;
            }
        }
    }
}
