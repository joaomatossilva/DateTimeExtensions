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
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-GB")]
    public class EN_GBHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_GBHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.GoodFriday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.EasterMonday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));

            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.BoxingDay));
            this.InnerCalendarDays.Add(new Holiday(MayDayBank));
            this.InnerCalendarDays.Add(new Holiday(SpringBank));
            this.InnerCalendarDays.Add(new Holiday(LateSummerBank));
        }


        //1st Monday in May	- May Day Bank Holiday
        public static NamedDayInitializer MayDayBank { get; } = new NamedDayInitializer(() =>
            new NamedDay("May Day Bank", new NthDayOfWeekInMonthDayStrategy(1, DayOfWeek.Monday, Month.May, CountDirection.FromFirst)));

        //Last Monday in May - Spring Bank Holiday
        public static NamedDayInitializer SpringBank { get; } = new NamedDayInitializer(() =>
            new NamedDay("Spring Bank", new NthDayOfWeekInMonthDayStrategy(1, DayOfWeek.Monday, Month.May, CountDirection.FromLast)));

        //Last Monday in August	- Late Summer Bank Holiday
        public static NamedDayInitializer LateSummerBank { get; } = new NamedDayInitializer(() => 
            new NamedDay("Late Summer Bank", new NthDayOfWeekInMonthDayStrategy(1, DayOfWeek.Monday, Month.August, CountDirection.FromLast)));
    }
}