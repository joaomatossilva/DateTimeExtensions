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
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("ar-SA")]
    public class AR_SAHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        private static readonly Calendar HirijiCalendar = new HijriCalendar();

        public AR_SAHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(EndOfRamadan));
            this.InnerCalendarDays.Add(new Holiday(EndOfHajj));
            this.InnerCalendarDays.Add(new Holiday(SaudiNationalDay));
        }

        protected override IDictionary<DateTime, CalendarDay> BuildObservancesMap(int year)
        {
            var observancesMap = new Dictionary<DateTime, CalendarDay>();
            observancesMap.AddIfInexistent(SaudiNationalDay.GetInstance(year).Value, new Holiday(SaudiNationalDay));

            var endOfRamadanObservance = EndOfRamadan.GetInstance(year);
            for (int i = 0; i <= 7; i++)
            {
                observancesMap.AddIfInexistent(endOfRamadanObservance.Value.AddDays(i), new Holiday(EndOfRamadan));
            }

            var endOfHajjObservance = EndOfHajj.GetInstance(year);
            for (int i = 0; i <= 6; i++)
            {
                observancesMap.AddIfInexistent(endOfHajjObservance.Value.AddDays(i), new Holiday(EndOfHajj));
            }

            return observancesMap;
        }

        //1 Shawwal
        private static readonly Lazy<NamedDay> EndOfRamadanLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Eid ul-Fitr", new FixedDayStrategy(10, 1, HirijiCalendar)));
        public static NamedDay EndOfRamadan => EndOfRamadanLazy.Value;

        //10 Dhul-Hijjah
        private static readonly Lazy<NamedDay> EndOfHajjLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Eid ul-Adha", new FixedDayStrategy(12, 10, HirijiCalendar)));
        public static NamedDay EndOfHajj => EndOfHajjLazy.Value;

        //23 September - Saudi National Day
        private static readonly Lazy<NamedDay> SaudiNationalDayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Saudi National Day", new FixedDayStrategy(Month.September, 23)));
        public static NamedDay SaudiNationalDay => SaudiNationalDayLazy.Value;
    }
}