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
    [Locale("nl-NL")]
    public class NL_NLHolidayStrategy : HolidayStrategyBase, IObservancesStrategy
    {
        public NL_NLHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(ChristianHolidays.GoodFriday);
            this.InnerObservances.AddHoliday(ChristianHolidays.Easter);
            this.InnerObservances.AddHoliday(ChristianHolidays.EasterMonday);
            this.InnerObservances.AddHoliday(Kingsday);
            this.InnerObservances.AddHoliday(LiberationDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Ascension);
            this.InnerObservances.AddHoliday(ChristianHolidays.Pentecost);
            this.InnerObservances.AddHoliday(ChristianHolidays.PentecostMonday);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
            this.InnerObservances.AddHoliday(GlobalHolidays.BoxingDay);
        }

        // 1885-1948: 31 August
        // 1949-2013: 30 April
        // 2014-    : 27 April
        private static NamedDay kingsday;

        public static NamedDay Kingsday
        {
            get
            {
                if (kingsday == null)
                {
                    kingsday = new NamedDay("Kingsday", new FixedDayResolver(year =>
                    {
                        if (year >= 2014)
                        {
                            return new DateTime(year, 4, 27);
                        }

                        if (year >= 1949)
                        {
                            return new DateTime(year, 4, 30);
                        }

                        if (year >= 1885)
                        {
                            return new DateTime(year, 8, 31);
                        }

                        return null;
                    }));
                }
                return kingsday;
            }
        }

        private static NamedDay liberationDay;

        public static NamedDay LiberationDay
        {
            get
            {
                if (liberationDay == null)
                {
                    liberationDay = new NamedDay(
                        "Liberation Day",
                        new YearDependantDayResolver(
                            year => year >= 1990 || (year % 5 == 0 && year >= 1945),
                            new FixedDayResolver(5, 5)));
                }
                return liberationDay;
            }
        }
    }
}
