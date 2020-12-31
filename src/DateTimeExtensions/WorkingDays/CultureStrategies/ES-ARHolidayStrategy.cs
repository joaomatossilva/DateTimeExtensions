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
using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("es-AR")]
    public class ES_ARHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public ES_ARHolidayStrategy()
        {
            foreach (var holiday in TuristicHolidays)
            {
                this.InnerCalendarDays.Add(holiday);
            }
            foreach (var holiday in MoveableHolidays)
            {
                this.InnerCalendarDays.Add(holiday);
            }
            foreach (var holiday in NormalHolidays)
            {
                this.InnerCalendarDays.Add(holiday);
            }
        }

        protected override IEnumerable<KeyValuePair<DateTime, CalendarDay>> GetYearObservances(int year)
        {
            foreach (var turisticHoliday in BuildTuristicObservanceMap(year))
            {
                yield return turisticHoliday;
            }
            foreach (var moveableHoliday in BuildMoveableObservanceMap(year))
            {
                yield return moveableHoliday;
            }
            foreach (var normalHoliday in BuildNormalObservanceMap(year))
            {
                yield return normalHoliday;
            }
        }

        private IEnumerable<KeyValuePair<DateTime, CalendarDay>> BuildNormalObservanceMap(int year)
        {
            foreach (var holiday in NormalHolidays)
            {
                var date = holiday.Day.GetInstance(year);
                if (date == null)
                {
                    continue;
                }

                yield return new KeyValuePair<DateTime, CalendarDay>(
                    date.Value,
                    holiday);
            }
        }

        private IEnumerable<KeyValuePair<DateTime, CalendarDay>> BuildTuristicObservanceMap(int year)
        {
            foreach (var turisticHoliday in TuristicHolidays)
            {
                var date = turisticHoliday.Day.GetInstance(year);
                if (date == null)
                {
                    continue;
                }

                yield return new KeyValuePair<DateTime, CalendarDay>(
                    date.Value,
                    turisticHoliday);

                //if holiday falls on tuesday, the holiday is also observed on the last monday
                if (date.Value.DayOfWeek == DayOfWeek.Tuesday)
                {
                    yield return new KeyValuePair<DateTime, CalendarDay>(
                        date.Value.LastDayOfWeek(DayOfWeek.Monday),
                        turisticHoliday);
                }
                //if holiday falls on thursday, the holiday is also observed on the next friday
                if (date.Value.DayOfWeek == DayOfWeek.Thursday)
                {
                    yield return new KeyValuePair<DateTime, CalendarDay>(
                        date.Value.NextDayOfWeek(DayOfWeek.Friday),
                        turisticHoliday);
                }
            }
        }

        private IEnumerable<KeyValuePair<DateTime, CalendarDay>> BuildMoveableObservanceMap(int year)
        {
            foreach (var moveableHoliday in MoveableHolidays)
            {
                var date = moveableHoliday.Day.GetInstance(year);
                if (date == null)
                {
                    continue;
                }

                switch (date.Value.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        yield return new KeyValuePair<DateTime, CalendarDay>(
                            date.Value,
                            moveableHoliday);
                        break;
                    //if holiday falls on tuesday or wednesday, the holiday is observed on the last monday
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                        yield return new KeyValuePair<DateTime, CalendarDay>(
                            date.Value.LastDayOfWeek(DayOfWeek.Monday),
                            moveableHoliday);
                        break;
                    //if holiday falls on thu, fri, sat, sun, the holiday is observed on the next monday
                    default:
                        yield return new KeyValuePair<DateTime, CalendarDay>(
                            date.Value.NextDayOfWeek(DayOfWeek.Monday),
                            moveableHoliday);
                        break;
                }
            }
        }

        //24 March - Day of Remembrance for Truth and Justice
        public static NamedDayInitializer DayOfRemembrenceForTruthAndJustice { get; } = new NamedDayInitializer(() =>
            new NamedDay("Day of Remembrance for Truth and Justice", new FixedDayStrategy(Month.March, 24)));

        //2 April - Day of The Veterans
        public static NamedDayInitializer DayOfTheVeterans { get; } = new NamedDayInitializer(() =>
            new NamedDay("Day of The Veterans", new FixedDayStrategy(Month.April, 2)));

        //25 May - Day of the First National Government
        public static NamedDayInitializer DayOfTheFirstNationalGovernment { get; } = new NamedDayInitializer(() =>
            new NamedDay("Day of the First National Government", new FixedDayStrategy(Month.May, 25)));


        //20 June - National Flag Day
        public static NamedDayInitializer NationalFlagDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("National Flag Day", new FixedDayStrategy(Month.June, 20)));

        //9 July - Independence Day
        public static NamedDayInitializer IndependenceDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Independence Day", new FixedDayStrategy(Month.July, 9)));

        //3rd Monday Of August - Anniversary Of Death of General José San Martin
        public static NamedDayInitializer AnniversaryOfDeathGeneralJoseSanMartin { get; } = new NamedDayInitializer(() =>
            new NamedDay("Anniversary Of Death of General José San Martin",
                new NthDayOfWeekInMonthDayStrategy(3, DayOfWeek.Monday, Month.July, CountDirection.FromFirst)));

        //second Monday of October - Day of Respect for Cultural Diversity
        public static NamedDayInitializer DayOfRespectForCulturalDiversity { get; } = new NamedDayInitializer(() =>
            new NamedDay("Day of Respect for Cultural Diversity",
                new NthDayOfWeekInMonthDayStrategy(2, DayOfWeek.Monday, Month.October, CountDirection.FromFirst)));

        //fourth monday of November - Day of National Sovereignty
        public static NamedDayInitializer DayOfNationalSovereignity { get; } = new NamedDayInitializer(() =>
            new NamedDay("Day of National Sovereignty",
                new NthDayOfWeekInMonthDayStrategy(4, DayOfWeek.Monday, Month.November, CountDirection.FromFirst)));

        private static readonly IEnumerable<Holiday> TuristicHolidays =
            new Holiday[]
            {
                new Holiday(GlobalHolidays.NewYear),
                //The day before the carnival is an holiday also but since Carnival is always a tuesday,
                //it can be included on the Turistic holiday bridge policy
                new Holiday(ChristianHolidays.Carnival),
                new Holiday(DayOfRemembrenceForTruthAndJustice),
                new Holiday(DayOfTheVeterans),
                new Holiday(GlobalHolidays.InternationalWorkersDay),
                new Holiday(DayOfTheFirstNationalGovernment),
                new Holiday(NationalFlagDay),
                new Holiday(IndependenceDay),
                new Holiday(ChristianHolidays.ImaculateConception),
                //TODO: only half day. should it be included?
                //this.InnerHolidays.Add(new Holiday(ChristianHolidays.ChristmasEve));
                new Holiday(ChristianHolidays.Christmas),
                //TODO: only half day. should it be included?
                //this.InnerHolidays.Add(new Holiday(GlobalHolidays.NewYearsEve));
            };

        private static readonly IEnumerable<Holiday> MoveableHolidays =
            new Holiday[]
            {
                new Holiday(DayOfRespectForCulturalDiversity),
                new Holiday(DayOfNationalSovereignity)
            };

        private static readonly IEnumerable<Holiday> NormalHolidays =
            new Holiday[]
            {
                new Holiday(ChristianHolidays.MaundyThursday),
                new Holiday(ChristianHolidays.GoodFriday),
                new Holiday(AnniversaryOfDeathGeneralJoseSanMartin)
            };
    }
}