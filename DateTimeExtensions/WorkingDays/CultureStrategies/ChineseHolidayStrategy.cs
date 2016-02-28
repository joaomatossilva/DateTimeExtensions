#region License

// 
// Copyright (c) 2011-2016, João Matos Silva <kappy@acydburne.com.pt>
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

using System.Collections.Generic;
using System.Globalization;
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("zh-CN")]
    public class ChineseHolidayStrategy : HolidayStrategyBase
    {
        private static readonly Calendar ChineseCalendar = new ChineseLunisolarCalendar();

        public ChineseHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(SpringFestival);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(DragonBoatFestival);
            this.InnerHolidays.Add(MidAutumnFestival);
            this.InnerHolidays.Add(NationalDay);
        }

        private static Holiday springFestival;
        public static Holiday SpringFestival
        {
            get
            {
                if (springFestival == null)
                {
                    springFestival = new FixedHoliday("Spring Festival", 1, 1, ChineseCalendar);
                }
                return springFestival;
            }
        }

        private static Holiday tombSweepingDay;

        public static Holiday TombSweepingDay
        {
            get
            {
                if (tombSweepingDay == null)
                {
                    //temporary maps based on https://en.wikipedia.org/wiki/Public_holidays_in_China
                    var knownTombSweepingDayOccurences = new Dictionary<int, DayInYear>
                    {
                        {2014, new DayInYear(4, 7)},
                        {2015, new DayInYear(4, 5)},
                        {2016, new DayInYear(4, 2)},
                        {2017, new DayInYear(4, 5)},
                        {2018, new DayInYear(4, 5)}

                    };

                    tombSweepingDay = new YearMapHoliday("Tomb-Sweeping Day", knownTombSweepingDayOccurences);
                }
                return tombSweepingDay;
            }
        }

        private static Holiday dragonBoatFestival;
        public static Holiday DragonBoatFestival
        {
            get
            {
                if (dragonBoatFestival == null)
                {
                    dragonBoatFestival = new FixedHoliday("Dragon Boat Festival", 5, 5, ChineseCalendar);
                }
                return dragonBoatFestival;
            }
        }

        //Mid-Autumn Festival
        private static Holiday midAutumnFestival;
        public static Holiday MidAutumnFestival
        {
            get
            {
                if (midAutumnFestival == null)
                {
                    midAutumnFestival = new FixedHoliday("Mid-Autumn Festival", 8, 15, ChineseCalendar);
                }
                return midAutumnFestival;
            }
        }

        //National Day
        private static Holiday nationalDay;
        public static Holiday NationalDay
        {
            get
            {
                if (nationalDay == null)
                {
                    nationalDay = new FixedHoliday("National Day", 10, 1);
                }
                return nationalDay;
            }
        }
    }
}
