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
        protected override IDictionary<DateTime,Holiday> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Holiday> holidayMap = new Dictionary<DateTime, Holiday>();
            foreach(var innerHoliday in InnerHolidays)
            {
                var date = innerHoliday.GetInstance(year);
                if (date.HasValue)
                {
                    if (date.Value.DayOfWeek == DayOfWeek.Sunday)
                        holidayMap.Add(date.Value.AddDays(1), innerHoliday);
                    else
                        holidayMap.Add(date.Value, innerHoliday);

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
        public Holiday EmancipationDay {
            get
            {
                if (emancipationDay == null)
                    emancipationDay = new FixedHoliday("Emancipation Day", 8, 1);
                return emancipationDay;
            }
        }
        private Holiday independenceDay;
        public Holiday IndependenceDay {
            get
            {
                if (independenceDay == null)
                    independenceDay = new FixedHoliday("Independence Day", 8, 6);
                return independenceDay;
            }
        }
        private Holiday nationalHeroesDay;
        public Holiday NationalHeroesDay {
            get
            {
                if (nationalHeroesDay == null)
                    nationalHeroesDay = new FixedHoliday("National Heroes Day", 10, 16);
                return nationalHeroesDay;
            }
        }
    }
}