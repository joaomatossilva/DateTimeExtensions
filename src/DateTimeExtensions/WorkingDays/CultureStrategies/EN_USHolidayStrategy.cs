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
            this.InnerHolidays.Add(Juneteenth);
        }

        protected override IDictionary<DateTime, NamedDay> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, NamedDay> holidayMap = new Dictionary<DateTime, NamedDay>();
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
        
        //Juneteenth - new as of 2021
        private static NamedDay juneteenth;
        
        public static NamedDay Juneteenth
        {
            get
            {
                if (juneteenth == null)
                {
                    juneteenth = new NamedDay(
                        "Juneteenth",
                        new YearDependantDayResolver(year => year >= 2021, new FixedDayResolver(6, 19)));
                }
                return juneteenth;
            }
        }
        
        private static NamedDay independenceDay;

        public static NamedDay IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new NamedDay("Independence Day", new FixedDayResolver(7, 4));
                }
                return independenceDay;
            }
        }

        //Third Monday in January - Birthday of Martin Luther King, Jr.
        private static NamedDay martinLutherKing;

        public static NamedDay MartinLutherKing
        {
            get
            {
                if (martinLutherKing == null)
                {
                    martinLutherKing = new NamedDay(
                        "Birthday of Martin Luther King, Jr.",
                        new NthDayOfWeekInMonthDayResolver(3, DayOfWeek.Monday, 1, CountDirection.FromFirst));
                }
                return martinLutherKing;
            }
        }

        //Inauguration Day
        //First January 20th following a Presidential election

        //Third Monday in February - Washington's Birthday
        private static NamedDay washingtonsBirthday;

        public static NamedDay WashingtonsBirthday
        {
            get
            {
                if (washingtonsBirthday == null)
                {
                    washingtonsBirthday = new NamedDay("Washington's Birthday", new NthDayOfWeekInMonthDayResolver(3, DayOfWeek.Monday, 2, CountDirection.FromFirst));
                }
                return washingtonsBirthday;
            }
        }

        //Last Monday in May - Memorial Day
        private static NamedDay memorialDay;

        public static NamedDay MemorialDay
        {
            get
            {
                if (memorialDay == null)
                {
                    memorialDay = new NamedDay("Memorial Day", new NthDayOfWeekInMonthDayResolver(1, DayOfWeek.Monday, 5, CountDirection.FromLast));
                }
                return memorialDay;
            }
        }

        //Third Monday in February - Washington's Birthday
        private static NamedDay laborDay;

        public static NamedDay LaborDay
        {
            get
            {
                if (laborDay == null)
                {
                    laborDay = new NamedDay("Labor Day", new NthDayOfWeekInMonthDayResolver(1, DayOfWeek.Monday, 9, CountDirection.FromFirst));
                }
                return laborDay;
            }
        }

        //Second Monday in October - Columbus Day
        private static NamedDay columbusDay;

        public static NamedDay ColumbusDay
        {
            get
            {
                if (columbusDay == null)
                {
                    columbusDay = new NamedDay("Columbus Day", new NthDayOfWeekInMonthDayResolver(2, DayOfWeek.Monday, 10, CountDirection.FromFirst));
                }
                return columbusDay;
            }
        }

        //Fourth Thursday in November - Thanksgiving Day
        private static NamedDay thanksgivingDay;

        public static NamedDay ThanksgivingDay
        {
            get
            {
                if (thanksgivingDay == null)
                {
                    thanksgivingDay = new NamedDay("Thanksgiving Day", new NthDayOfWeekInMonthDayResolver(4, DayOfWeek.Thursday, 11, CountDirection.FromFirst));
                }
                return thanksgivingDay;
            }
        }

        private static NamedDay newYearsEve;

        public static NamedDay NewYearsEve
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
