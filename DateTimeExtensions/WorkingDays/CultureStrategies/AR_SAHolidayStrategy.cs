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
using System.Globalization;
using System.Linq;
using System.Text;
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("ar-SA")]
    public class AR_SAHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        private static readonly Calendar HirijiCalendar = new HijriCalendar();

        public AR_SAHolidayStrategy()
        {
            this.InnerHolidays.Add(EndOfRamadan);
            this.InnerHolidays.Add(EndOfHajj);
            this.InnerHolidays.Add(SaudiNationalDay);
        }

        protected override IDictionary<DateTime, Holiday> BuildObservancesMap(int year)
        {
            var observancesMap = new Dictionary<DateTime, Holiday>();
            observancesMap.AddIfInexistent(SaudiNationalDay.GetInstance(year).Value, SaudiNationalDay);

            var endOfRamadanObservance = EndOfRamadan.GetInstance(year);
            for (int i = 0; i <= 7; i++)
            {
                observancesMap.AddIfInexistent(endOfRamadanObservance.Value.AddDays(i), EndOfRamadan);
            }

            var endOfHajjObservance = EndOfHajj.GetInstance(year);
            for (int i = 0; i <= 6; i++)
            {
                observancesMap.AddIfInexistent(endOfHajjObservance.Value.AddDays(i), EndOfHajj);
            }

            return observancesMap;
        }

        //1 Shawwal
        private static Holiday endOfRamadan;

        public static Holiday EndOfRamadan
        {
            get
            {
                if (endOfRamadan == null)
                {
                    endOfRamadan = new FixedHoliday("Eid ul-Fitr", 10, 1, HirijiCalendar);
                }
                return endOfRamadan;
            }
        }

        //10 Dhul-Hijjah
        private static Holiday endOfHajj;

        public static Holiday EndOfHajj
        {
            get
            {
                if (endOfHajj == null)
                {
                    endOfHajj = new FixedHoliday("Eid ul-Adha", 12, 10, HirijiCalendar);
                }
                return endOfHajj;
            }
        }

        //23 September - Saudi National Day
        private static Holiday saudiNationalDay;

        public static Holiday SaudiNationalDay
        {
            get
            {
                if (saudiNationalDay == null)
                {
                    saudiNationalDay = new FixedHoliday("Saudi National Day", 9, 23);
                }
                return saudiNationalDay;
            }
        }
    }
}