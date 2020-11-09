#region License

// 
// Copyright (c) 2011-2016, João Matos Silva <kappy@acydburne.com.pt>
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
using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("zh-CN")]
    public class ChineseHolidayStrategy : HolidayStrategyBase
    {
        private static readonly Calendar ChineseCalendar = new ChineseLunisolarCalendar();

        public ChineseHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(SpringFestival));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.InternationalWorkersDay));
            this.InnerCalendarDays.Add(new Holiday(DragonBoatFestival));
            this.InnerCalendarDays.Add(new Holiday(MidAutumnFestival));
            this.InnerCalendarDays.Add(new Holiday(NationalDay));
        }

        public static NamedDayInitializer SpringFestival { get; } = new NamedDayInitializer(() =>
            new NamedDay("Spring Festival", new FixedDayStrategy(1, 1, ChineseCalendar)));
        
        public static NamedDayInitializer TombSweepingDay { get; } = new NamedDayInitializer(() =>
        {
            //temporary maps based on https://en.wikipedia.org/wiki/Public_holidays_in_China
            var knownTombSweepingDayOccurrences = new Dictionary<int, DayInYear>
            {
                {2014, new DayInYear(4, 7)},
                {2015, new DayInYear(4, 5)},
                {2016, new DayInYear(4, 2)},
                {2017, new DayInYear(4, 5)},
                {2018, new DayInYear(4, 5)}
            };

            return new NamedDay("Tomb-Sweeping Day", new YearMapDayStrategy(knownTombSweepingDayOccurrences));
        });
        
        public static NamedDayInitializer DragonBoatFestival { get; } = new NamedDayInitializer(() =>
            new NamedDay("Dragon Boat Festival", new FixedDayStrategy(5, 5, ChineseCalendar)));

        //Mid-Autumn Festival
        public static NamedDayInitializer MidAutumnFestival { get; } = new NamedDayInitializer(() =>
            new NamedDay("Mid-Autumn Festival", new FixedDayStrategy(8, 15, ChineseCalendar)));
        
        //National Day
        public static NamedDayInitializer NationalDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("National Day", new FixedDayStrategy(10, 1)));
    }
}
