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
        private static NamedDay[] fixedDayHolidays =
            new NamedDay[]
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

        private static NamedDay[] nextMondayHolidays =
            new NamedDay[]
            {
                new NamedDay("Epiphany", new FixedDayResolver(new DayInYear(1, 6))),
                new NamedDay("Saint Joseph", new FixedDayResolver(new DayInYear(3, 19))),
                new NamedDay("Saint Peter and saint Paul", new FixedDayResolver(new DayInYear(6, 29))),
                new NamedDay("Virgin Assumption", new FixedDayResolver(new DayInYear(8, 15))),
                new NamedDay("Race day", new FixedDayResolver(new DayInYear(10, 12))),
                new NamedDay("All saints' day", new FixedDayResolver(new DayInYear(11, 1))),
                new NamedDay("Independence of Cartagena", new FixedDayResolver(new DayInYear(11, 11)))
            };

        public ES_COHolidayStrategy()
        {
            var all = fixedDayHolidays.Concat(nextMondayHolidays);
            foreach (var h in all)
            {
                this.InnerObservances.AddHoliday(h);
            }
        }

        protected override IDictionary<DateTime, Observance> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Observance> holidayMap = new Dictionary<DateTime, Observance>();
            foreach (var innerHoliday in fixedDayHolidays)
            {
                var date = innerHoliday.GetInstance(year);
                if (date.HasValue)
                {
                    holidayMap.Add(date.Value, new Observance(innerHoliday, true));
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

                    holidayMap[d] = d == date.Value
                        ? new Observance(h, true)
                        : new Observance(new NamedDay(h.Name, new FixedDayResolver(d.Month, d.Day)), true);
                }
            }

            return holidayMap;
        }

        private static NamedDay independenceDay;

        public static NamedDay IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new NamedDay("Independence Day", new FixedDayResolver(7, 20));
                }
                return independenceDay;
            }
        }

        private static NamedDay boyacaBattle;

        public static NamedDay BoyacaBattle
        {
            get
            {
                if (boyacaBattle == null)
                {
                    boyacaBattle = new NamedDay("Boyaca battle", new FixedDayResolver(8, 7));
                }
                return boyacaBattle;
            }
        }

        private static NamedDay ascension;

        public static NamedDay Ascension
        {
            get
            {
                if (ascension == null)
                {
                    ascension = new NamedDay("Ascension", new EasterBasedDayResolver(43));
                }
                return ascension;
            }
        }

        private static NamedDay corpusChristi;

        public static NamedDay CorpusChristi
        {
            get
            {
                if (corpusChristi == null)
                {
                    corpusChristi = new NamedDay("CorpusChristi", new EasterBasedDayResolver(64));
                }
                return corpusChristi;
            }
        }

        private static NamedDay sacredHeartDay;

        public static NamedDay SacredHeart
        {
            get
            {
                if (sacredHeartDay == null)
                {
                    sacredHeartDay = new NamedDay("CorpusChristi", new EasterBasedDayResolver(71));
                }
                return sacredHeartDay;
            }
        }
    }
}
