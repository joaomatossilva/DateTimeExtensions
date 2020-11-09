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

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("pt-BR")]
    public class PT_BRHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public PT_BRHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Carnival));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.GoodFriday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Easter));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.CorpusChristi));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.InternationalWorkersDay));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.DayOfTheDead));
            this.InnerCalendarDays.Add(new Holiday(TiradentesDay));
            this.InnerCalendarDays.Add(new Holiday(IndependanceDay));
            this.InnerCalendarDays.Add(new Holiday(OurLadyOfAparecida));
            this.InnerCalendarDays.Add(new Holiday(RepublicDay));
        }

        private static Holiday tiradentesDay;

        public static NamedDayInitializer TiradentesDay { get; } = new NamedDayInitializer(() => 
            new NamedDay("TiradentesDay", new FixedDayStrategy(Month.April, 21)));

        public static NamedDayInitializer IndependanceDay { get; } = new NamedDayInitializer(() => 
            new NamedDay("IndependanceDay", new FixedDayStrategy(Month.September, 7)));

        public static NamedDayInitializer OurLadyOfAparecida { get; } = new NamedDayInitializer(() => 
            new NamedDay("OurLadyOfAparecida", new FixedDayStrategy(Month.October, 12)));

        public static NamedDayInitializer RepublicDay { get; } = new NamedDayInitializer(() => 
            new NamedDay("RepublicDay", new FixedDayStrategy(Month.November, 15)));
    }
}