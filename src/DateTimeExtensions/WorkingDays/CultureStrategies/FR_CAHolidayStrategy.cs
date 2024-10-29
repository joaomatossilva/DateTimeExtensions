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

        protected override IDictionary<DateTime, Holiday> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Holiday> holidayMap = new Dictionary<DateTime, Holiday>();

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

        private static Holiday canadaDay;

        /// <summary>
        /// July 1 - Canada Day
        /// </summary>
        public static Holiday CanadaDay
        {
            get
            {
                if (canadaDay == null)
                {
                    canadaDay = new FixedHoliday("Canada Day", 7, 1);
                }
                return canadaDay;
            }
        }

        private static Holiday labourDay;

        /// <summary>
        /// First Monday in September - Labour Day
        /// </summary>
        public static Holiday LabourDay
        {
            get
            {
                if (labourDay == null)
                {
                    labourDay = new NthDayOfWeekInMonthHoliday("Labour Day", 1, DayOfWeek.Monday, 9,
                        CountDirection.FromFirst);
                }
                return labourDay;
            }
        }

        private static Holiday thanksgiving;

        /// <summary>
        /// Second Monday in October - Thanksgiving
        /// </summary>
        public static Holiday Thanksgiving
        {
            get
            {
                if (thanksgiving == null)
                {
                    thanksgiving = new NthDayOfWeekInMonthHoliday("Thanksgiving", 2, DayOfWeek.Monday, 10,
                        CountDirection.FromFirst);
                }
                return thanksgiving;
            }
        }

        private static Holiday remembranceDay;

        /// <summary>
        /// November 11 - Remembrance Day
        /// </summary>
        public static Holiday RemembranceDay
        {
            get
            {
                if (remembranceDay == null)
                {
                    remembranceDay = new FixedHoliday("Remembrance Day", 11, 11);
                }
                return remembranceDay;
            }
        }
    }
}