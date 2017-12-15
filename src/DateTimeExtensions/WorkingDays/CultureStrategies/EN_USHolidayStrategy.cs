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
    [Locale("en-US")]
    public class EN_USHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_USHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(NewYearsEve);
            this.InnerHolidays.Add(IndependenceDay);
            this.InnerHolidays.Add(GlobalHolidays.VeteransDay);
            this.InnerHolidays.Add(MartinLutherKing);
            this.InnerHolidays.Add(WashingtonsBirthday);
            this.InnerHolidays.Add(MemorialDay);
            this.InnerHolidays.Add(LaborDay);
            this.InnerHolidays.Add(ColumbusDay);
            this.InnerHolidays.Add(ThanksgivingDay);
        }

        protected override IDictionary<DateTime, Holiday> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Holiday> holidayMap = new Dictionary<DateTime, Holiday>();
            foreach (var innerHoliday in InnerHolidays)
            {
                var date = innerHoliday.GetInstance(year);
                if (date.HasValue)
                {
                    //if the holiday is a saturday, the holiday is observed on previous friday
                    switch (date.Value.DayOfWeek)
                    {
                        case DayOfWeek.Saturday:
                            holidayMap.Add(date.Value.AddDays(-1), innerHoliday);
                            break;
                        case DayOfWeek.Sunday:
                            holidayMap.Add(date.Value.AddDays(1), innerHoliday);
                            break;
                        default:
                            holidayMap.Add(date.Value, innerHoliday);
                            break;
                    }
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
                    independenceDay = new FixedHoliday("Independence Day", 7, 4);
                }
                return independenceDay;
            }
        }

        //Third Monday in January - Birthday of Martin Luther King, Jr.
        private static Holiday martinLutherKing;

        public static Holiday MartinLutherKing
        {
            get
            {
                if (martinLutherKing == null)
                {
                    martinLutherKing = new NthDayOfWeekInMonthHoliday("Birthday of Martin Luther King, Jr.", 3,
                        DayOfWeek.Monday, 1, CountDirection.FromFirst);
                }
                return martinLutherKing;
            }
        }

        //Inauguration Day
        //First January 20th following a Presidential election

        //Third Monday in February - Washington's Birthday
        private static Holiday washingtonsBirthday;

        public static Holiday WashingtonsBirthday
        {
            get
            {
                if (washingtonsBirthday == null)
                {
                    washingtonsBirthday = new NthDayOfWeekInMonthHoliday("Washington's Birthday", 3, DayOfWeek.Monday, 2,
                        CountDirection.FromFirst);
                }
                return washingtonsBirthday;
            }
        }

        //Last Monday in May - Memorial Day
        private static Holiday memorialDay;

        public static Holiday MemorialDay
        {
            get
            {
                if (memorialDay == null)
                {
                    memorialDay = new NthDayOfWeekInMonthHoliday("Memorial Day", 1, DayOfWeek.Monday, 5,
                        CountDirection.FromLast);
                }
                return memorialDay;
            }
        }

        //Third Monday in February - Washington's Birthday
        private static Holiday laborDay;

        public static Holiday LaborDay
        {
            get
            {
                if (laborDay == null)
                {
                    laborDay = new NthDayOfWeekInMonthHoliday("Labor Day", 1, DayOfWeek.Monday, 9,
                        CountDirection.FromFirst);
                }
                return laborDay;
            }
        }

        //Second Monday in October - Columbus Day
        private static Holiday columbusDay;

        public static Holiday ColumbusDay
        {
            get
            {
                if (columbusDay == null)
                {
                    columbusDay = new NthDayOfWeekInMonthHoliday("Columbus Day", 2, DayOfWeek.Monday, 10,
                        CountDirection.FromFirst);
                }
                return columbusDay;
            }
        }

        //Fourth Thursday in November - Thanksgiving Day
        private static Holiday thanksgivingDay;

        public static Holiday ThanksgivingDay
        {
            get
            {
                if (thanksgivingDay == null)
                {
                    thanksgivingDay = new NthDayOfWeekInMonthHoliday("Thanksgiving Day", 4, DayOfWeek.Thursday, 11,
                        CountDirection.FromFirst);
                }
                return thanksgivingDay;
            }
        }

        private static Holiday newYearsEve;

        public static Holiday NewYearsEve
        {
            get
            {
                if (newYearsEve == null)
                {
                    newYearsEve = new NewYearEveFridayOnly();
                }
                return newYearsEve;
            }
        }
    }
}