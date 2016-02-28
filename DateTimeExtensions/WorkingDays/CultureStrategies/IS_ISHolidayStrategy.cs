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
    [Locale("is-IS")]
    public class IS_ISHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public IS_ISHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.PalmSunday);
            this.InnerHolidays.Add(ChristianHolidays.MaundyThursday);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(ChristianHolidays.Easter);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(FirstDayOfSummer);
            this.InnerHolidays.Add(GlobalHolidays.MayDay);
            this.InnerHolidays.Add(ChristianHolidays.Ascension);
            this.InnerHolidays.Add(ChristianHolidays.Pentecost);
            this.InnerHolidays.Add(ChristianHolidays.PentecostMonday);
            this.InnerHolidays.Add(SeamensDay);
            this.InnerHolidays.Add(RepublicsDay);
            this.InnerHolidays.Add(CommerceDay);
            //Christmas Eve is usually half holiday observance
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(SecondDayOfChristmas);
            //New Year's Eve is usually half holiday observance
        }

        private static Holiday republicsDay;

        public static Holiday RepublicsDay
        {
            get
            {
                if (republicsDay == null)
                {
                    republicsDay = new FixedHoliday("Republic's Day", 6, 17);
                }
                return republicsDay;
            }
        }

        //Commerce Day - First Monday of August
        private static Holiday commerceDay;

        public static Holiday CommerceDay
        {
            get
            {
                if (commerceDay == null)
                {
                    commerceDay = new NthDayOfWeekInMonthHoliday("Commerce's Day", 1, DayOfWeek.Monday, 8,
                        CountDirection.FromFirst);
                }
                return commerceDay;
            }
        }

        //The Seamen's Day - First Sunday of June
        private static Holiday seamensDay;

        public static Holiday SeamensDay
        {
            get
            {
                if (seamensDay == null)
                {
                    seamensDay = new NthDayOfWeekInMonthHoliday("The Seamen's Day", 1, DayOfWeek.Sunday, 6,
                        CountDirection.FromFirst);
                }
                return seamensDay;
            }
        }

        //First Day of Summer - First Thursday after 18 April
        private static Holiday firstDayOfSummer;

        public static Holiday FirstDayOfSummer
        {
            get
            {
                if (firstDayOfSummer == null)
                {
                    //could not find any strong reference of the designated day of 18 April is inclusive or not
                    // if it is, then we should change it to 17 April, since NthDayOfWeekAfterDayHoliday don't count with the current day
                    firstDayOfSummer = new NthDayOfWeekAfterDayHoliday("First Day of Summer", 1, DayOfWeek.Thursday, 4,
                        18);
                }
                return firstDayOfSummer;
            }
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
    }
}