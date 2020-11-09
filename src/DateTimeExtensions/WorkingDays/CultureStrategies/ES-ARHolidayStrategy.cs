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
    [Locale("es-AR")]
    public class ES_ARHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
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

        public ES_ARHolidayStrategy()
        {
            foreach (var turisticHoliday in TuristicHolidays)
            {
                this.InnerCalendarDays.Add(turisticHoliday);
            }
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.MaundyThursday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.GoodFriday));
            this.InnerCalendarDays.Add(new Holiday(AnniversaryOfDeathGeneralJoseSanMartin));
            this.InnerCalendarDays.Add(new Holiday(DayOfRespectForCulturalDiversity));
            this.InnerCalendarDays.Add(new Holiday(DayOfNationalSovereignity));
        }

        protected override IDictionary<DateTime, CalendarDay> BuildObservancesMap(int year)
        {
            var observancesMap = new Dictionary<DateTime, CalendarDay>();
            this.BuildMoveableObservanceMap(year, new Holiday(DayOfRespectForCulturalDiversity), observancesMap);
            this.BuildMoveableObservanceMap(year, new Holiday(DayOfNationalSovereignity), observancesMap);
            foreach (var turisticHoliday in TuristicHolidays)
            {
                this.BuildTuristicObservanceMap(year, turisticHoliday, observancesMap);
            }
            this.BuildNormalObservanceMap(year, new Holiday(ChristianHolidays.MaundyThursday), observancesMap);
            this.BuildNormalObservanceMap(year, new Holiday(ChristianHolidays.GoodFriday), observancesMap);
            this.BuildNormalObservanceMap(year, new Holiday(AnniversaryOfDeathGeneralJoseSanMartin), observancesMap);
            return observancesMap;
        }

        private void BuildNormalObservanceMap(int year, Holiday holiday, Dictionary<DateTime, CalendarDay> map)
        {
            var holidayInstance = holiday.Day.GetInstance(year);
            if (!holidayInstance.HasValue)
            {
                return;
            }
            map.AddIfInexistent(holidayInstance.Value, holiday);
        }

        private void BuildTuristicObservanceMap(int year, Holiday holiday, Dictionary<DateTime, CalendarDay> map)
        {
            var holidayInstance = holiday.Day.GetInstance(year);
            if (!holidayInstance.HasValue)
            {
                return;
            }
            map.AddIfInexistent(holidayInstance.Value, holiday);
            //if holiday falls on tuesday, the holiday is also observed on the last monday
            if (holidayInstance.Value.DayOfWeek == DayOfWeek.Tuesday)
            {
                map.AddIfInexistent(holidayInstance.Value.LastDayOfWeek(DayOfWeek.Monday), holiday);
            }
            //if holiday falls on thursday, the holiday is also observed on the next friday
            if (holidayInstance.Value.DayOfWeek == DayOfWeek.Thursday)
            {
                map.AddIfInexistent(holidayInstance.Value.NextDayOfWeek(DayOfWeek.Friday), holiday);
            }
        }

        private void BuildMoveableObservanceMap(int year, Holiday holiday, Dictionary<DateTime, CalendarDay> map)
        {
            var holidayInstance = holiday.Day.GetInstance(year);
            if (!holidayInstance.HasValue)
            {
                return;
            }
            switch (holidayInstance.Value.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    map.AddIfInexistent(holidayInstance.Value, holiday);
                    break;
                    //if holiday falls on tuesday or wednesday, the holiday is observed on the last monday
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                    map.AddIfInexistent(holidayInstance.Value.LastDayOfWeek(DayOfWeek.Monday), holiday);
                    break;
                    //if holiday falls on thu, fri, sat, sun, the holiday is observed on the next monday
                default:
                    map.AddIfInexistent(holidayInstance.Value.NextDayOfWeek(DayOfWeek.Monday), holiday);
                    break;
            }
        }

        private bool IsNormalHoliday(DateTime day)
        {
            if (ChristianHolidays.MaundyThursday.Value.IsInstanceOf(day))
            {
                return true;
            }
            if (ChristianHolidays.GoodFriday.Value.IsInstanceOf(day))
            {
                return true;
            }
            if (AnniversaryOfDeathGeneralJoseSanMartin.Value.IsInstanceOf(day))
            {
                return true;
            }
            return false;
        }

        private bool IsTuristicHoliday(DateTime day)
        {
            return TuristicHolidays.Any(h => h.Day.IsInstanceOf(day));
        }

        private bool IsMoveableHoliday(DateTime day)
        {
            if (DayOfRespectForCulturalDiversity.Value.IsInstanceOf(day))
            {
                return true;
            }
            if (DayOfNationalSovereignity.Value.IsInstanceOf(day))
            {
                return true;
            }
            return false;
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
    }
}