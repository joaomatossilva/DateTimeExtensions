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

namespace DateTimeExtensions.WorkingDays
{
    public static class GlobalHolidays
    {
        public static NamedDayInitializer InternationalWorkersDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("InternationalWorkersDay", new FixedDayStrategy(Month.May, 1)));
        
        public static NamedDayInitializer StPatricsDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("StPatricsDay", new FixedDayStrategy(Month.March, 17)));

        public static NamedDayInitializer VeteransDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("VeteransDay", new FixedDayStrategy(Month.November, 11)));

        public static NamedDayInitializer BoxingDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("BoxingDay", new FixedDayStrategy(Month.December, 26)));

        public static NamedDayInitializer MayDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("MayDay", new FixedDayStrategy(Month.May, 1)));

        //MidSummer Day - Saturday between 20 June and 26 June
        public static NamedDayInitializer MidsummerDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("MidsummerDay", new NthDayOfWeekAfterDayStrategy(1, DayOfWeek.Saturday, new FixedDayStrategy(Month.June, 20))));
        
        //Midsummer Eve - Friday between 19 June and 25 June
        public static NamedDayInitializer MidsummerEve { get; } = new NamedDayInitializer(() =>
            new NamedDay("MidsummerEve", new NthDayOfWeekAfterDayStrategy(-1, DayOfWeek.Friday, new FixedDayStrategy(Month.June, 19))));
        
        //New Year's Eve - 31 December
        public static NamedDayInitializer NewYearsEve { get; } = new NamedDayInitializer(() =>
            new NamedDay("NewYearsEve", new FixedDayStrategy(Month.December, 31)));
        
        public static NamedDayInitializer NewYear { get; } = new NamedDayInitializer(() =>
            new NamedDay("NewYear", new FixedDayStrategy(Month.January, 1)));
    }
}