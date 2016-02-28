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
    [Locale("en-AU")]
    public class EN_AUHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_AUHolidayStrategy()
        {
            // Australian public holidays vary on a state-by-state basis. These rules are based
            // holidays that are observed in at least half of Australian states and territories
            // according to https://en.wikipedia.org/wiki/Public_holidays_in_Australia

            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(AustraliaDay);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(ChristianHolidays.EasterSaturday);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(AnzacDay);
            this.InnerHolidays.Add(QueensBirthday);
            this.InnerHolidays.Add(LabourDay);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(GlobalHolidays.BoxingDay);
        }

        protected override IDictionary<DateTime, Holiday> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Holiday> holidayMap = new Dictionary<DateTime, Holiday>();
            foreach (var innerHoliday in InnerHolidays)
            {
                var date = innerHoliday.GetInstance(year);
                if (date.HasValue)
                {
                    holidayMap[date.Value] = innerHoliday;
                }
            }

            var existingHolidayMap = new Dictionary<DateTime, Holiday>(holidayMap);
            foreach (var existingHoliday in existingHolidayMap)
            {
                var date = existingHoliday.Key;
                var innerHoliday = existingHoliday.Value;

                // don't move the holiday if it is easter based since it's already observated
                if (innerHoliday.GetType() != typeof(EasterBasedHoliday) && innerHoliday != AnzacDay)
                {
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        AddHolidayOnNextAvailableDay(holidayMap, date, innerHoliday);
                    }
                }
            }

            return holidayMap;
        }

        private void AddHolidayOnNextAvailableDay(IDictionary<DateTime, Holiday> holidayMap, DateTime date, Holiday holiday)
        {
            if (!holidayMap.ContainsKey(date) && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                holidayMap.Add(date, holiday);
            }
            else
            {
                AddHolidayOnNextAvailableDay(holidayMap, date.AddDays(1), holiday);
            }
        }

        //Last Monday in May - Spring Bank Holiday
        private static Holiday australiaDay;

        public static Holiday AustraliaDay
        {
            get
            {
                if (australiaDay == null)
                {
                    australiaDay = new FixedHoliday("Australia Day", 1, 26);
                }
                return australiaDay;
            }
        }

        //1st Monday in May	- May Day Bank Holiday (not an national holiday, but observed on some regions)
        private static Holiday mayDay;

        public static Holiday MayDay
        {
            get
            {
                if (mayDay == null)
                {
                    mayDay = new NthDayOfWeekInMonthHoliday("May Day", 1, DayOfWeek.Monday, 5, CountDirection.FromFirst);
                }
                return mayDay;
            }
        }

        //25th April - Anzac Day
        private static Holiday anzacDay;

        public static Holiday AnzacDay
        {
            get
            {
                if (anzacDay == null)
                {
                    anzacDay = new FixedHoliday("Anzac Day", 4, 25);
                }
                return anzacDay;
            }
        }

        //2nd Monday in June - Queen's Birthday
        private static Holiday queensBirthday;

        public static Holiday QueensBirthday
        {
            get
            {
                if (queensBirthday == null)
                {
                    queensBirthday = new NthDayOfWeekInMonthHoliday("Queen's Birthday", 2, DayOfWeek.Monday, 6,
                        CountDirection.FromFirst);
                }
                return queensBirthday;
            }
        }

        //1nd Monday in October - Labour Day
        private static Holiday labourDay;

        public static Holiday LabourDay
        {
            get
            {
                if (labourDay == null)
                {
                    labourDay = new NthDayOfWeekInMonthHoliday("Labour Day", 1, DayOfWeek.Monday, 10,
                        CountDirection.FromFirst);
                }
                return labourDay;
            }
        }
    }
}