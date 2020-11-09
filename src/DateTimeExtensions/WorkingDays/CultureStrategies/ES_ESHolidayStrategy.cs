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
    [Locale("es-ES")]
    public class ES_ESHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public ES_ESHolidayStrategy()
        {
            this.InnerCalendarDays.Add(GlobalHolidays.NewYear);
            this.InnerCalendarDays.Add(ChristianHolidays.Epiphany);
            this.InnerCalendarDays.Add(ChristianHolidays.GoodFriday);
            this.InnerCalendarDays.Add(ChristianHolidays.ImaculateConception);
            this.InnerCalendarDays.Add(ChristianHolidays.Assumption);
            this.InnerCalendarDays.Add(ChristianHolidays.AllSaints);
            this.InnerCalendarDays.Add(ChristianHolidays.Christmas);

            this.InnerCalendarDays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerCalendarDays.Add(NationalDay);
            this.InnerCalendarDays.Add(ConstitutionDay);
        }

        protected override IDictionary<DateTime, Holiday> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Holiday> holidayMap = new Dictionary<DateTime, Holiday>();
            foreach (var innerHoliday in InnerCalendarDays)
            {
                var date = innerHoliday.GetInstance(year);
                if (date.HasValue)
                {
                    holidayMap.Add(date.Value, innerHoliday);
                    //if the holiday is a sunday, the holiday is observed on next monday
                    if (date.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        holidayMap.Add(date.Value.AddDays(1), innerHoliday);
                    }
                }
            }
            return holidayMap;
        }

        private static Holiday nationalDay;

        public static Holiday NationalDay
        {
            get
            {
                if (nationalDay == null)
                {
                    nationalDay = new FixedHoliday("Espanha_NationalDay", 10, 12);
                }
                return nationalDay;
            }
        }

        private static Holiday constitutionDay;

        public static Holiday ConstitutionDay
        {
            get
            {
                if (constitutionDay == null)
                {
                    constitutionDay = new FixedHoliday("Espanha_ConstitutionDay", 12, 6);
                }
                return constitutionDay;
            }
        }
    }
}