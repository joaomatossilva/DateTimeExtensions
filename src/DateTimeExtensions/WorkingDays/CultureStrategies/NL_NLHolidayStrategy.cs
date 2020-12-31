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

    [Locale("nl-NL")]
    public class NL_NLHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public NL_NLHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.GoodFriday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Easter));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.EasterMonday));
            this.InnerCalendarDays.Add(new Holiday(Kingsday));
            this.InnerCalendarDays.Add(new Holiday(LiberationDay));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Ascension));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Pentecost));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.PentecostMonday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.BoxingDay));
        }

        // 1885-1948: 31 August
        // 1949-2013: 30 April
        // 2014-    : 27 April
        public static NamedDayInitializer Kingsday { get; } = new NamedDayInitializer(() =>
            new NamedDay(
                "Kingsday",
                new FixedDayStrategy(year =>
                {
                    if (year >= 2014)
                    {
                        return new DateTime(year, Month.April, 27);
                    }

                    if (year >= 1949)
                    {
                        return new DateTime(year, Month.April, 30);
                    }

                    if (year >= 1885)
                    {
                        return new DateTime(year, Month.August, 31);
                    }

                    return null;
                })));

        //after 2000, Liberation Day only ocours 5 in 5 years
        public static NamedDayInitializer LiberationDay { get; } = new NamedDayInitializer(() =>
            new NamedDay(
                "Liberation Day",
                new YearDependantDayStrategy(
                    year => year <= 2000 || year % 5 == 0,
                    new FixedDayStrategy(Month.May, 5))));
    }
}