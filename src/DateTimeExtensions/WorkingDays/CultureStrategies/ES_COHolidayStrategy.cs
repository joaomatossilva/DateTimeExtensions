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
    [Locale("es-CO")]
    public class ES_COHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        private static Holiday[] fixedDayHolidays =
            new Holiday[]
            {
                GlobalHolidays.NewYear,
                GlobalHolidays.InternationalWorkersDay,
                IndependenceDay,
                BoyacaBattle,
                ChristianHolidays.ImaculateConception,
                ChristianHolidays.Christmas,

                ChristianHolidays.PalmSunday,
                ChristianHolidays.MaundyThursday,
                ChristianHolidays.GoodFriday,
                ChristianHolidays.Easter,
                Ascension,
                CorpusChristi,
                SacredHeart,
            };

        private static Holiday[] nextMondayHolidays =
            new Holiday[]
            {
                new FixedHoliday("Epiphany", new DayInYear(1, 6)),
                new FixedHoliday("Saint Joseph", new DayInYear(3, 19)),
                new FixedHoliday("Saint Peter and saint Paul", new DayInYear(6, 29)),
                new FixedHoliday("Virgin Assumption",          new DayInYear(8, 15)),
                new FixedHoliday("Race day",        new DayInYear(10, 12)),
                new FixedHoliday("All saints' day", new DayInYear(11, 1)),
                new FixedHoliday("Independence of Cartagena", new DayInYear(11, 11))
            };

        public ES_COHolidayStrategy()
        {
            var all = fixedDayHolidays.Concat(nextMondayHolidays);
            foreach (var h in all)
            {
                this.InnerHolidays.Add(h);
            }
        }

        protected override IDictionary<DateTime, Holiday> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Holiday> holidayMap = new Dictionary<DateTime, Holiday>();
            foreach (var innerHoliday in fixedDayHolidays)
            {
                var date = innerHoliday.GetInstance(year);
                if (date.HasValue)
                {
                    holidayMap.Add(date.Value, innerHoliday);
                }
            }

            foreach (var h in nextMondayHolidays)
            {
                var date = h.GetInstance(year);
                if (date.HasValue)
                {
                    var d = (date.Value.DayOfWeek == DayOfWeek.Monday)
                                ? date.Value
                                : date.Value.NextDayOfWeek(DayOfWeek.Monday);

                    holidayMap[d] = h;
                }
            }

            return holidayMap;
        }

        private static Holiday independenceDay;

        public static Holiday IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new FixedHoliday("Independence Day", 7, 20);
                }
                return independenceDay;
            }
        }

        private static Holiday boyacaBattle;

        public static Holiday BoyacaBattle
        {
            get
            {
                if (boyacaBattle == null)
                {
                    boyacaBattle = new FixedHoliday("Boyaca battle", 8, 7);
                }
                return boyacaBattle;
            }
        }

        private static Holiday ascension;

        public static Holiday Ascension
        {
            get
            {
                if (ascension == null)
                {
                    ascension = new EasterBasedHoliday("Ascension", 43);
                }
                return ascension;
            }
        }

        private static Holiday corpusChristi;

        public static Holiday CorpusChristi
        {
            get
            {
                if (corpusChristi == null)
                {
                    corpusChristi = new EasterBasedHoliday("CorpusChristi", 64);
                }
                return corpusChristi;
            }
        }

        private static Holiday sacredHeartDay;

        public static Holiday SacredHeart
        {
            get
            {
                if (sacredHeartDay == null)
                {
                    sacredHeartDay = new EasterBasedHoliday("CorpusChristi", 71);
                }
                return sacredHeartDay;
            }
        }
    }
}
