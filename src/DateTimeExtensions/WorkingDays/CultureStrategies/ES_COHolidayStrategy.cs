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

using DateTimeExtensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    using OccurrencesCalculators;

    [Locale("es-CO")]
    public class ES_COHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {


        public ES_COHolidayStrategy()
        {
            foreach (var celebratedInSameDayHoliday in CelebratedInSameDayHolidays)
            {
                InnerCalendarDays.Add(celebratedInSameDayHoliday);
            }

            foreach (var observedOnNextMondayHoliday in ObservedOnNextMondayHolidays)
            {
                InnerCalendarDays.Add(observedOnNextMondayHoliday);
            }
        }

        protected override IEnumerable<KeyValuePair<DateTime, CalendarDay>> GetYearObservances(int year)
        {
            foreach (var celebratedInSameDayHoliday in CelebratedInSameDayHolidays)
            {
                var day = celebratedInSameDayHoliday.Day.GetInstance(year);
                if (day != null)
                {
                    yield return new KeyValuePair<DateTime, CalendarDay>(day.Value, celebratedInSameDayHoliday);
                }
            }

            foreach (var observedOnNextMondayHoliday in ObservedOnNextMondayHolidays)
            {
                var day = observedOnNextMondayHoliday.Day.GetInstance(year);
                if (day == null)
                {
                    continue;
                }

                if (day.Value.DayOfWeek == DayOfWeek.Monday)
                {
                    yield return new KeyValuePair<DateTime, CalendarDay>(day.Value, observedOnNextMondayHoliday);
                }

                var observedHoliday = new Holiday(
                    new NamedDay(
                        observedOnNextMondayHoliday.Day.Name,
                        new NthDayOfWeekAfterDayStrategy(1, DayOfWeek.Monday, new NamedDayStrategy(observedOnNextMondayHoliday.Day))));
                var observedDate = observedHoliday.Day.GetInstance(year);
                if (observedDate != null)
                {
                    yield return new KeyValuePair<DateTime, CalendarDay>(observedDate.Value, observedHoliday);
                }
            }
        }

        public static NamedDayInitializer CartagenaIndependenceDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Cartagena Independence Day", new FixedDayStrategy(Month.November, 11)));

        public static NamedDayInitializer RaceDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Race Day", new FixedDayStrategy(Month.October, 12)));

        public static NamedDayInitializer IndependenceDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Independence Day", new FixedDayStrategy(Month.July, 20)));

        public static NamedDayInitializer BoyacaBattle { get; } = new NamedDayInitializer(() =>
            new NamedDay("BoyacaBattle", new FixedDayStrategy(Month.August, 7)));

        private static readonly IEnumerable<Holiday> CelebratedInSameDayHolidays =
            new Holiday[]
            {
                new Holiday(GlobalHolidays.NewYear),
                new Holiday(GlobalHolidays.InternationalWorkersDay),
                new Holiday(IndependenceDay),
                new Holiday(BoyacaBattle),
                new Holiday(ChristianHolidays.ImaculateConception),
                new Holiday(ChristianHolidays.Christmas),
                new Holiday(ChristianHolidays.PalmSunday),
                new Holiday(ChristianHolidays.MaundyThursday),
                new Holiday(ChristianHolidays.GoodFriday),
                new Holiday(ChristianHolidays.Easter),
            };

        private static readonly IEnumerable<Holiday> ObservedOnNextMondayHolidays =
            new Holiday[]
            {
                new Holiday(ChristianHolidays.Epiphany),
                new Holiday(ChristianHolidays.StJoseph),
                new Holiday(ChristianHolidays.StPeterStPaul),
                new Holiday(ChristianHolidays.Assumption),
                new Holiday(RaceDay),
                new Holiday(ChristianHolidays.AllSaints),
                new Holiday(CartagenaIndependenceDay),
                new Holiday(ChristianHolidays.Ascension),
                new Holiday(ChristianHolidays.CorpusChristi),
                new Holiday(ChristianHolidays.SacredHeart),
            };
    }
}
