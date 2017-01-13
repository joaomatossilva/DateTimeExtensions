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
    [Locale("da-DK")]
    public class DA_DKHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public DA_DKHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.MaundyThursday);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(ChristianHolidays.Easter);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(GeneralPrayerDay);
            this.InnerHolidays.Add(ChristianHolidays.Ascension);
            this.InnerHolidays.Add(ChristianHolidays.Pentecost);
            this.InnerHolidays.Add(ChristianHolidays.PentecostMonday);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(SecondDayOfChristmas);
        }

        private static Holiday secondDayOfChristmas;

        public static Holiday SecondDayOfChristmas
        {
            get
            {
                if (secondDayOfChristmas == null)
                {
                    secondDayOfChristmas = new FixedHoliday("Christmas (2nd Day)", 12, 26);
                }
                return secondDayOfChristmas;
            }
        }

        //source: http://en.wikipedia.org/wiki/Store_Bededag
        // Store Bededag, translated literally as Great Prayer Day or more loosely as General Prayer Day, "All Prayers" Day, Great Day of Prayers or Common Prayer Day,
        //is a Danish holiday celebrated on the 4th Friday after Easter
        private static Holiday generalPrayerDay;

        public static Holiday GeneralPrayerDay
        {
            get
            {
                if (generalPrayerDay == null)
                {
                    generalPrayerDay = new NthDayOfWeekAfterDayHoliday("General Prayer Day", 4, DayOfWeek.Friday,
                        ChristianHolidays.Easter);
                }
                return generalPrayerDay;
            }
        }
    }
}