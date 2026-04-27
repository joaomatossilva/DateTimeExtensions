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
    [Locale("fr-CA")]
    [Locale("en-CA")]
    public class FR_CAHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public FR_CAHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(CanadaDay);
            this.InnerHolidays.Add(LabourDay);
            this.InnerHolidays.Add(Thanksgiving);
            this.InnerHolidays.Add(RemembranceDay);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
        }

        protected override IDictionary<DateTime, NamedDay> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, NamedDay> holidayMap = new Dictionary<DateTime, NamedDay>();

            foreach (var innerHoliday in InnerHolidays)
            {
                var date = innerHoliday.GetInstance(year);

                if (date.HasValue)
                {
                    holidayMap.AddIfInexistent(date.Value, innerHoliday);

                    if (date.Value.DayOfWeek == DayOfWeek.Saturday)
                    {
                        //if the holiday is a saturday, the holiday is observed on previous friday
                        holidayMap.AddIfInexistent(date.Value.AddDays(-1), innerHoliday);
                    }

                    if (date.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        //if the holiday is a sunday, the holiday is observed on next monday
                        holidayMap.AddIfInexistent(date.Value.AddDays(1), innerHoliday);
                    }
                }
            }
            return holidayMap;
        }

        private static NamedDay canadaDay;

        /// <summary>
        /// July 1 - Canada Day
        /// </summary>
        public static NamedDay CanadaDay
        {
            get
            {
                if (canadaDay == null)
                {
                    canadaDay = new NamedDay("Canada Day", new FixedDayResolver(7, 1));
                }
                return canadaDay;
            }
        }

        private static NamedDay labourDay;

        /// <summary>
        /// First Monday in September - Labour Day
        /// </summary>
        public static NamedDay LabourDay
        {
            get
            {
                if (labourDay == null)
                {
                    labourDay = new NamedDay("Labour Day", new NthDayOfWeekInMonthDayResolver(1, DayOfWeek.Monday, 9, CountDirection.FromFirst));
                }
                return labourDay;
            }
        }

        private static NamedDay thanksgiving;

        /// <summary>
        /// Second Monday in October - Thanksgiving
        /// </summary>
        public static NamedDay Thanksgiving
        {
            get
            {
                if (thanksgiving == null)
                {
                    thanksgiving = new NamedDay("Thanksgiving", new NthDayOfWeekInMonthDayResolver(2, DayOfWeek.Monday, 10, CountDirection.FromFirst));
                }
                return thanksgiving;
            }
        }

        private static NamedDay remembranceDay;

        /// <summary>
        /// November 11 - Remembrance Day
        /// </summary>
        public static NamedDay RemembranceDay
        {
            get
            {
                if (remembranceDay == null)
                {
                    remembranceDay = new NamedDay("Remembrance Day", new FixedDayResolver(11, 11));
                }
                return remembranceDay;
            }
        }
    }
}