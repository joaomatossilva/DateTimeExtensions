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
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(ChristianHolidays.Epiphany);
            this.InnerObservances.Add(ChristianHolidays.GoodFriday);
            this.InnerObservances.Add(ChristianHolidays.ImaculateConception);
            this.InnerObservances.Add(ChristianHolidays.Assumption);
            this.InnerObservances.Add(ChristianHolidays.AllSaints);
            this.InnerObservances.Add(ChristianHolidays.Christmas);

            this.InnerObservances.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.Add(NationalDay);
            this.InnerObservances.Add(ConstitutionDay);
        }

        protected override IDictionary<DateTime, NamedDay> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, NamedDay> holidayMap = new Dictionary<DateTime, NamedDay>();
            foreach (var innerHoliday in InnerObservances)
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

        private static NamedDay nationalDay;

        public static NamedDay NationalDay
        {
            get
            {
                if (nationalDay == null)
                {
                    nationalDay = new NamedDay("Espanha_NationalDay", new FixedDayResolver(10, 12));
                }
                return nationalDay;
            }
        }

        private static NamedDay constitutionDay;

        public static NamedDay ConstitutionDay
        {
            get
            {
                if (constitutionDay == null)
                {
                    constitutionDay = new NamedDay("Espanha_ConstitutionDay", new FixedDayResolver(12, 6));
                }
                return constitutionDay;
            }
        }
    }
}