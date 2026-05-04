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
    [Locale("en-GB")]
    public class EN_GBHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_GBHolidayStrategy()
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(ChristianHolidays.GoodFriday);
            this.InnerObservances.Add(ChristianHolidays.EasterMonday);
            this.InnerObservances.Add(ChristianHolidays.Christmas);

            this.InnerObservances.Add(GlobalHolidays.BoxingDay);
            this.InnerObservances.Add(MayDayBank);
            this.InnerObservances.Add(SpringBank);
            this.InnerObservances.Add(LateSummerBank);
        }

        private static NamedDay boxingDay;

        public static NamedDay BoxingDay
        {
            get
            {
                if (boxingDay == null)
                {
                    boxingDay = new NamedDay("Boxing Day", new FixedDayResolver(12, 26));
                }
                return boxingDay;
            }
        }

        //1st Monday in May	- May Day Bank NamedDay
        private static NamedDay mayDayBank;

        public static NamedDay MayDayBank
        {
            get
            {
                if (mayDayBank == null)
                {
                    mayDayBank = new NamedDay("May Day Bank", new NthDayOfWeekInMonthDayResolver(1, DayOfWeek.Monday, 5, CountDirection.FromFirst));
                }
                return mayDayBank;
            }
        }

        //Last Monday in May - Spring Bank NamedDay
        private static NamedDay springBank;

        public static NamedDay SpringBank
        {
            get
            {
                if (springBank == null)
                {
                    springBank = new NamedDay("Spring Bank", new NthDayOfWeekInMonthDayResolver(1, DayOfWeek.Monday, 5, CountDirection.FromLast));
                }
                return springBank;
            }
        }

        //Last Monday in August	- Late Summer Bank NamedDay
        private static NamedDay lateSummerBank;

        public static NamedDay LateSummerBank
        {
            get
            {
                if (lateSummerBank == null)
                {
                    lateSummerBank = new NamedDay("Late Summer Bank", new NthDayOfWeekInMonthDayResolver(1, DayOfWeek.Monday, 8, CountDirection.FromLast));
                }
                return lateSummerBank;
            }
        }
    }
}