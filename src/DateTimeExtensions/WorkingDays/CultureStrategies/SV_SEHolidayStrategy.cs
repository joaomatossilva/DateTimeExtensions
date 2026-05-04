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
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("sv-SE")]
    public class SV_SEHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public SV_SEHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(ChristianHolidays.Epiphany);
            this.InnerObservances.AddHoliday(ChristianHolidays.GoodFriday);
            this.InnerObservances.AddHoliday(ChristianHolidays.Easter);
            this.InnerObservances.AddHoliday(ChristianHolidays.EasterMonday);
            this.InnerObservances.AddHoliday(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Ascension);
            this.InnerObservances.AddHoliday(ChristianHolidays.Pentecost);
            this.InnerObservances.AddHoliday(NationalDay);
            this.InnerObservances.AddHoliday(GlobalHolidays.MidsummerEve);
            this.InnerObservances.AddHoliday(GlobalHolidays.MidsummerDay);
            this.InnerObservances.AddHoliday(AllSaintsDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.ChristmasEve);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
            this.InnerObservances.AddHoliday(GlobalHolidays.BoxingDay);
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYearsEve);
        }

        private static NamedDay nationalDay;

        public static NamedDay NationalDay
        {
            get
            {
                if (nationalDay == null)
                {
                    nationalDay = new NamedDay("National Day", new FixedDayResolver(6, 6));
                }
                return nationalDay;
            }
        }

        //All Saints' Day - Saturday between 31 October and 6 November
        // - Same as ChristianHolidays.AllSaints but has diferent ocurrence
        private static NamedDay allSaintsDay;

        public static NamedDay AllSaintsDay
        {
            get
            {
                if (allSaintsDay == null)
                {
                    allSaintsDay = new NamedDay("All Saint's Day", new NthDayOfWeekAfterDayResolver(1, DayOfWeek.Saturday, 10, 31));
                }
                return allSaintsDay;
            }
        }
    }
}
