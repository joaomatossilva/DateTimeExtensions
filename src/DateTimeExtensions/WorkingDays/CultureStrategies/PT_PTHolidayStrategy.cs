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
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;
using DateTimeExtensions.WorkingDays.RegionIdentifiers;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("pt-PT")]
    public class PT_PTHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public PT_PTHolidayStrategy(string region)
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.GoodFriday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Easter));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.ImaculateConception));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Assumption));
            this.InnerCalendarDays.Add(new Holiday(CorpusChristi));
            this.InnerCalendarDays.Add(new Holiday(AllSaints));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));

            this.InnerCalendarDays.Add(new Holiday(FreedomDay));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.InternationalWorkersDay));
            this.InnerCalendarDays.Add(new Holiday(PortugalDay));
            this.InnerCalendarDays.Add(new Holiday(RepublicDay));
            this.InnerCalendarDays.Add(new Holiday(RestorationOfIndependance));

            if (string.IsNullOrEmpty(region))
            {
                return;
            }

            switch (region)
            {
                case PortugalRegion.Lisboa:
                   this.InnerCalendarDays.Add(new Holiday(StAntonio));
                    break;
                case PortugalRegion.Porto:
                    this.InnerCalendarDays.Add(new Holiday(StJoao));
                    break;
                case PortugalRegion.CasteloBranco:
                    this.InnerCalendarDays.Add(new Holiday(SraMercules));
                    break;
            }
        }

        private static readonly Func<int, bool> YearsHolidaysNotSuspended = year => year < 2013 || year >= 2016;
        
        public static NamedDayInitializer CorpusChristi { get; } = new NamedDayInitializer(() => 
            new NamedDay(
                ChristianHolidays.CorpusChristi.Value.Name,
                new YearDependantDayStrategy(
                    YearsHolidaysNotSuspended,
                    new NamedDayStrategy(ChristianHolidays.CorpusChristi))));
        
        public static NamedDayInitializer AllSaints { get; } = new NamedDayInitializer(() => 
            new NamedDay(
                ChristianHolidays.AllSaints.Value.Name,
                new YearDependantDayStrategy(
                    YearsHolidaysNotSuspended,
                    new NamedDayStrategy(ChristianHolidays.AllSaints))));
        
        public static NamedDayInitializer FreedomDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Portugal_FreedomDay", new FixedDayStrategy(Month.April, 25)));
        
        public static NamedDayInitializer PortugalDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Portugal_PortugalDay", new FixedDayStrategy(Month.June, 10)));

        public static NamedDayInitializer RepublicDay { get; } = new NamedDayInitializer(() =>
            new NamedDay(
                "Portugal_RepublicDay",
                new YearDependantDayStrategy(
                    YearsHolidaysNotSuspended,
                    new FixedDayStrategy(Month.October, 5))));

        public static NamedDayInitializer RestorationOfIndependance { get; } = new NamedDayInitializer(() =>
            new NamedDay(
                "Portugal_RestorationIndependance",
                new YearDependantDayStrategy(
                    YearsHolidaysNotSuspended,
                    new FixedDayStrategy(Month.December, 1))));

        public static NamedDayInitializer StAntonio { get; } = new NamedDayInitializer(() => 
            new NamedDay("Portugal_SantoAntonio", new FixedDayStrategy(Month.June, 13)));

        public static NamedDayInitializer StJoao { get; } = new NamedDayInitializer(() => 
            new NamedDay("Portugal_SaoJoao", new FixedDayStrategy(Month.June, 24)));

        public static NamedDayInitializer SraMercules { get; } = new NamedDayInitializer(() =>
            new NamedDay("Portugal_SraMercules", new NthDayAfterDayStrategy(9, new NamedDayStrategy(ChristianHolidays.Easter))));
    }
}