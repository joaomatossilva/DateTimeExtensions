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
        private static readonly Lazy<NamedDay> InternationalWorkersDayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("InternationalWorkersDay", new FixedDayStrategy(Month.May, 1)));
        public static NamedDay InternationalWorkersDay => InternationalWorkersDayLazy.Value;
        
        private static readonly Lazy<NamedDay> StPatricsDayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("StPatricsDay", new FixedDayStrategy(Month.March, 17)));
        public static NamedDay StPatricsDay => StPatricsDayLazy.Value;

        private static readonly Lazy<NamedDay> VeteransDayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("VeteransDay", new FixedDayStrategy(Month.November, 11)));
        public static NamedDay VeteransDay => VeteransDayLazy.Value;

        private static readonly Lazy<NamedDay> BoxingDayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("BoxingDay", new FixedDayStrategy(Month.December, 26)));
        public static NamedDay BoxingDay => BoxingDayLazy.Value;

        private static readonly Lazy<NamedDay> MayDayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("MayDay", new FixedDayStrategy(Month.May, 1)));
        public static NamedDay MayDay => MayDayLazy.Value;

        //MidSummer Day - Saturday between 20 June and 26 June
        private static readonly Lazy<NamedDay> MidsummerDayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("MidsummerDay", new NthDayOfWeekAfterDayStrategy(1, DayOfWeek.Saturday, new FixedDayStrategy(Month.June, 20))));
        public static NamedDay MidsummerDay => MidsummerDayLazy.Value;
        
        //Midsummer Eve - Friday between 19 June and 25 June
        private static readonly Lazy<NamedDay> MidsummerEveLazy = new Lazy<NamedDay>(() => 
            new NamedDay("MidsummerEve", new NthDayOfWeekAfterDayStrategy(-1, DayOfWeek.Friday, new FixedDayStrategy(Month.June, 19))));
        public static NamedDay MidsummerEve => MidsummerEveLazy.Value;
        
        //New Year's Eve - 31 December
        private static readonly Lazy<NamedDay> NewYearsEveLazy = new Lazy<NamedDay>(() => 
            new NamedDay("NewYearsEve", new FixedDayStrategy(Month.December, 31)));
        public static NamedDay NewYearsEve => NewYearsEveLazy.Value;
        
        private static readonly Lazy<NamedDay> NewYearLazy = new Lazy<NamedDay>(() => 
            new NamedDay("NewYear", new FixedDayStrategy(Month.January, 1)));
        public static NamedDay NewYear => NewYearLazy.Value;
    }
}