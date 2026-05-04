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
    public class ES_ESHolidayStrategy : HolidayStrategyBase, IObservancesStrategy
    {
        public ES_ESHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(ChristianHolidays.Epiphany);
            this.InnerObservances.AddHoliday(ChristianHolidays.GoodFriday);
            this.InnerObservances.AddHoliday(ChristianHolidays.ImaculateConception);
            this.InnerObservances.AddHoliday(ChristianHolidays.Assumption);
            this.InnerObservances.AddHoliday(ChristianHolidays.AllSaints);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);

            this.InnerObservances.AddHoliday(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.AddHoliday(NationalDay);
            this.InnerObservances.AddHoliday(ConstitutionDay);
        }

        protected override IDictionary<DateTime, Observance> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Observance> holidayMap = new Dictionary<DateTime, Observance>();
            foreach (var innerHoliday in InnerObservances)
            {
                var date = innerHoliday.CalendarDay.GetInstance(year);
                if (date.HasValue)
                {
                    holidayMap.Add(date.Value, innerHoliday);
                    //if the holiday is a sunday, the holiday is observed on next monday
                    if (date.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        var observedDate = date.Value.AddDays(1);
                        holidayMap.Add(
                            observedDate,
                            new Observance(new NamedDay(innerHoliday.CalendarDay.Name, new FixedDayResolver(observedDate.Month, observedDate.Day)), true));
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
