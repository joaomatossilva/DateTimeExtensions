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

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    using OccurrencesCalculators;

    [Locale("nl-BE")]
    public class NL_BEHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public NL_BEHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Easter));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.EasterMonday));
            this.InnerCalendarDays.Add(new Holiday(LabourDay));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Ascension));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Pentecost));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.PentecostMonday));
            this.InnerCalendarDays.Add(new Holiday(NationalHoliday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Assumption));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.AllSaints));
            this.InnerCalendarDays.Add(new Holiday(Armistice));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));
        }

        public static NamedDayInitializer LabourDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("LabourDay", new FixedDayStrategy(Month.May, 1)));

        public static NamedDayInitializer NationalHoliday { get; } = new NamedDayInitializer(() =>
            new NamedDay("Belgium_NationalHoliday", new FixedDayStrategy(Month.July, 21)));

        public static NamedDayInitializer Armistice { get; } = new NamedDayInitializer(() =>
            new NamedDay("Armistice", new FixedDayStrategy(Month.November, 11)));
    }
}