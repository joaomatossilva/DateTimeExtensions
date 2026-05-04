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

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("es-AR")]
    public class ES_ARHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        private static readonly IEnumerable<NamedDay> TuristicHolidays =
            new NamedDay[]
            {
                GlobalHolidays.NewYear, 
                //The day before the carnival is an holiday also but since Carnival is allways a tuesday,
                //it can be included on the Turistic holiday bridge policy
                ChristianHolidays.Carnival,
                DayOfRemembrenceForTruthAndJustice,
                DayOfTheVeterans,
                GlobalHolidays.InternationalWorkersDay,
                DayOfTheFirstNationalGovernment,
                NationalFlagDay,
                IndependenceDay,
                ChristianHolidays.ImaculateConception,
                //TODO: only half day. should it be included?
                //this.InnerHolidays.Add(ChristianHolidays.ChristmasEve);
                ChristianHolidays.Christmas,
                //TODO: only half day. should it be included?
                //this.InnerHolidays.Add(GlobalHolidays.NewYearsEve);
            };

        public ES_ARHolidayStrategy()
        {
            foreach (var turisticHoliday in TuristicHolidays)
            {
                this.InnerObservances.Add(turisticHoliday);
            }
            this.InnerObservances.Add(ChristianHolidays.MaundyThursday);
            this.InnerObservances.Add(ChristianHolidays.GoodFriday);
            this.InnerObservances.Add(AnniversaryOfDeathGeneralJoseSanMartin);
            this.InnerObservances.Add(DayOfRespectForCulturalDiversity);
            this.InnerObservances.Add(DayOfNationalSovereignity);
        }

        protected override IDictionary<DateTime, NamedDay> BuildObservancesMap(int year)
        {
            var observancesMap = new Dictionary<DateTime, NamedDay>();
            this.BuildMoveableObservanceMap(year, DayOfRespectForCulturalDiversity, observancesMap);
            this.BuildMoveableObservanceMap(year, DayOfNationalSovereignity, observancesMap);
            foreach (var turisticHoliday in TuristicHolidays)
            {
                this.BuildTuristicObservanceMap(year, turisticHoliday, observancesMap);
            }
            this.BuildNormalObservanceMap(year, ChristianHolidays.MaundyThursday, observancesMap);
            this.BuildNormalObservanceMap(year, ChristianHolidays.GoodFriday, observancesMap);
            this.BuildNormalObservanceMap(year, AnniversaryOfDeathGeneralJoseSanMartin, observancesMap);
            return observancesMap;
        }

        private void BuildNormalObservanceMap(int year, NamedDay holiday, Dictionary<DateTime, NamedDay> map)
        {
            var holidayInstance = holiday.GetInstance(year);
            if (!holidayInstance.HasValue)
            {
                return;
            }
            map.AddIfInexistent(holidayInstance.Value, DayOfRespectForCulturalDiversity);
        }

        private void BuildTuristicObservanceMap(int year, NamedDay holiday, Dictionary<DateTime, NamedDay> map)
        {
            var holidayInstance = holiday.GetInstance(year);
            if (!holidayInstance.HasValue)
            {
                return;
            }
            map.AddIfInexistent(holidayInstance.Value, DayOfRespectForCulturalDiversity);
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

        private void BuildMoveableObservanceMap(int year, NamedDay holiday, Dictionary<DateTime, NamedDay> map)
        {
            var holidayInstance = holiday.GetInstance(year);
            if (!holidayInstance.HasValue)
            {
                return;
            }
            switch (holidayInstance.Value.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    map.AddIfInexistent(holidayInstance.Value, DayOfRespectForCulturalDiversity);
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
            if (ChristianHolidays.MaundyThursday.IsInstanceOf(day))
            {
                return true;
            }
            if (ChristianHolidays.GoodFriday.IsInstanceOf(day))
            {
                return true;
            }
            if (AnniversaryOfDeathGeneralJoseSanMartin.IsInstanceOf(day))
            {
                return true;
            }
            return false;
        }

        private bool IsTuristicHoliday(DateTime day)
        {
            return TuristicHolidays.Any(h => h.IsInstanceOf(day));
        }

        private bool IsMoveableHoliday(DateTime day)
        {
            if (DayOfRespectForCulturalDiversity.IsInstanceOf(day))
            {
                return true;
            }
            if (DayOfNationalSovereignity.IsInstanceOf(day))
            {
                return true;
            }
            return false;
        }

        //24 March - Day of Remembrance for Truth and Justice
        private static NamedDay dayOfRemembrenceForTruthAndJustice;

        public static NamedDay DayOfRemembrenceForTruthAndJustice
        {
            get
            {
                if (dayOfRemembrenceForTruthAndJustice == null)
                {
                    dayOfRemembrenceForTruthAndJustice = new NamedDay("Day of Remembrance for Truth and Justice", new FixedDayResolver(3, 24));
                }
                return dayOfRemembrenceForTruthAndJustice;
            }
        }

        //2 April - Day of The Veterans
        private static NamedDay dayOfTheVeterans;

        public static NamedDay DayOfTheVeterans
        {
            get
            {
                if (dayOfTheVeterans == null)
                {
                    dayOfTheVeterans = new NamedDay("Day of The Veterans", new FixedDayResolver(4, 2));
                }
                return dayOfTheVeterans;
            }
        }

        //25 May - Day of the First National Government
        private static NamedDay dayOfTheFirstNationalGovernment;

        public static NamedDay DayOfTheFirstNationalGovernment
        {
            get
            {
                if (dayOfTheFirstNationalGovernment == null)
                {
                    dayOfTheFirstNationalGovernment = new NamedDay("Day of the First National Government", new FixedDayResolver(5, 25));
                }
                return dayOfTheFirstNationalGovernment;
            }
        }

        //20 June - National Flag Day 
        private static NamedDay nationalFlagDay;

        public static NamedDay NationalFlagDay
        {
            get
            {
                if (nationalFlagDay == null)
                {
                    nationalFlagDay = new NamedDay("National Flag Day", new FixedDayResolver(6, 20));
                }
                return nationalFlagDay;
            }
        }

        //9 July - Independence Day
        private static NamedDay independenceDay;

        public static NamedDay IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new NamedDay("Independence Day", new FixedDayResolver(7, 9));
                }
                return independenceDay;
            }
        }

        //3rd Monday Of August - Anniversary Of Death of General José San Martin
        private static NamedDay anniversaryOfDeathGeneralJoseSanMartin;

        public static NamedDay AnniversaryOfDeathGeneralJoseSanMartin
        {
            get
            {
                if (anniversaryOfDeathGeneralJoseSanMartin == null)
                {
                    anniversaryOfDeathGeneralJoseSanMartin =
                        new NamedDay("Anniversary Of Death of General José San Martin", new NthDayOfWeekInMonthDayResolver(3, DayOfWeek.Monday, 8, CountDirection.FromFirst));
                }
                return anniversaryOfDeathGeneralJoseSanMartin;
            }
        }

        //second Monday of October - Day of Respect for Cultural Diversity
        private static NamedDay dayOfRespectForCulturalDiversity;

        public static NamedDay DayOfRespectForCulturalDiversity
        {
            get
            {
                if (dayOfRespectForCulturalDiversity == null)
                {
                    dayOfRespectForCulturalDiversity =
                        new NamedDay("Day of Respect for Cultural Diversity", new NthDayOfWeekInMonthDayResolver(2, DayOfWeek.Monday, 10, CountDirection.FromFirst));
                }
                return dayOfRespectForCulturalDiversity;
            }
        }

        //fourth monday of November - Day of National Sovereignty
        private static NamedDay dayOfNationalSovereignity;

        public static NamedDay DayOfNationalSovereignity
        {
            get
            {
                if (dayOfNationalSovereignity == null)
                {
                    dayOfNationalSovereignity = new NamedDay("Day of National Sovereignty", new NthDayOfWeekInMonthDayResolver(4, DayOfWeek.Monday, 11, CountDirection.FromFirst));
                }
                return dayOfNationalSovereignity;
            }
        }
    }
}