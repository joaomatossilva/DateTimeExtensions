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
    [Locale("en-ZA")]
    public class EN_ZAHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_ZAHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(HumanRightsDay));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.GoodFriday));
            this.InnerCalendarDays.Add(new Holiday(FamilyDay));
            this.InnerCalendarDays.Add(new Holiday(FreedomDay));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.InternationalWorkersDay));
            this.InnerCalendarDays.Add(new Holiday(YouthDay));
            this.InnerCalendarDays.Add(new Holiday(NationalWomansDay));
            this.InnerCalendarDays.Add(new Holiday(HeritageDay));
            this.InnerCalendarDays.Add(new Holiday(DayOfReconciliation));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));
            this.InnerCalendarDays.Add(new Holiday(DayOfGoodwill));
        }

        protected override IEnumerable<KeyValuePair<DateTime, CalendarDay>> GetYearObservances(int year)
        {
            foreach (var calendarDay in InnerCalendarDays)
            {
                var date = calendarDay.Day.GetInstance(year);
                if (date == null)
                {
                    continue;
                }
                
                //if the holiday is a sunday, the holiday is observed on next monday
                if (date.Value.DayOfWeek == DayOfWeek.Sunday)
                {
                    yield return new KeyValuePair<DateTime, CalendarDay>(
                        date.Value.AddDays(1),
                        new Holiday(
                            new NamedDay(
                                calendarDay.Day.Name + " Observed",
                                new NthDayAfterDayStrategy(1, new NamedDayStrategy(calendarDay.Day)))));
                }
            }
        }

        //21 March - Human Right's Day		
        public static NamedDayInitializer HumanRightsDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Human Right's Day", new FixedDayStrategy(Month.March, 21)));

        //First Monday after Easter Sunday - Family Day
        public static NamedDayInitializer FamilyDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Family Day", new NthDayAfterDayStrategy(1, EasterDayStrategy.Instance)));

        //27th April - Freedom Day
        public static NamedDayInitializer FreedomDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Freedom Day", new FixedDayStrategy(Month.April, 27)));

        //16th June - Youth Day
        public static NamedDayInitializer YouthDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Youth Day", new FixedDayStrategy(Month.June, 16)));

        //9 August - National Woman's Day
        public static NamedDayInitializer NationalWomansDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("National Woman's Day", new FixedDayStrategy(Month.August, 9)));

        //24 September - Heritage Day
        public static NamedDayInitializer HeritageDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Heritage Day", new FixedDayStrategy(Month.September, 24)));

        //16 December - Day of Reconciliation
        public static NamedDayInitializer DayOfReconciliation { get; } = new NamedDayInitializer(() =>
            new NamedDay("Day of Reconciliation", new FixedDayStrategy(Month.December, 16)));

        //26 December - Day of Goodwill
        public static NamedDayInitializer DayOfGoodwill { get; } = new NamedDayInitializer(() =>
            new NamedDay("Day of Goodwill", new FixedDayStrategy(Month.December, 26)));
    }
}