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

        protected override IEnumerable<KeyValuePair<DateTime, CalendarDay>> GetYearObservances(int year)
        {
            var nationalDayObservance = SaudiNationalDay.Value.GetInstance(year);
            if (nationalDayObservance != null)
            {
                yield return new KeyValuePair<DateTime, CalendarDay>(nationalDayObservance.Value, new Holiday(SaudiNationalDay));
            }
            
            var endOfRamadanObservance = EndOfRamadan.Value.GetInstance(year);
            if (endOfRamadanObservance != null)
            {
                for (var i = 0; i <= 7; i++)
                {
                    yield return new KeyValuePair<DateTime, CalendarDay>(endOfRamadanObservance.Value.AddDays(i), new Holiday(EndOfRamadan));
                }
            }
            
            var endOfHajjObservance = EndOfHajj.Value.GetInstance(year);
            if (endOfHajjObservance != null)
            {
                for (var i = 0; i <= 6; i++)
                {
                    yield return new KeyValuePair<DateTime, CalendarDay>(endOfHajjObservance.Value.AddDays(i), new Holiday(EndOfHajj));
                }
            }
        }

        //1 Shawwal
        public static NamedDayInitializer EndOfRamadan { get; } = new NamedDayInitializer(() =>
            new NamedDay("Eid ul-Fitr", new FixedDayStrategy(10, 1, HirijiCalendar)));

        //10 Dhul-Hijjah
        public static NamedDayInitializer EndOfHajj { get; } = new NamedDayInitializer(() =>
            new NamedDay("Eid ul-Adha", new FixedDayStrategy(12, 10, HirijiCalendar)));

        //23 September - Saudi National Day
        public static NamedDayInitializer SaudiNationalDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Saudi National Day", new FixedDayStrategy(Month.September, 23)));
    }
}