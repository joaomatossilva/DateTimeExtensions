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
    [Locale("es-MX")]
    public class ES_MXHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public ES_MXHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ConstitutionDay);
            this.InnerHolidays.Add(BenitoJuarezBirthDay);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(IndependenceDay);
            this.InnerHolidays.Add(RevolutionDay);
            this.InnerHolidays.Add(ChangeOfFederalGovernment);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
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
                    if (date.Value.DayOfWeek == DayOfWeek.Saturday)
                    {
                        holidayMap.Add(date.Value.AddDays(-1), innerHoliday);
                    }
                    holidayMap.Add(date.Value, innerHoliday);
                    //if the holiday is a sunday, the holiday is observed on next monday
                    if (date.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        holidayMap.Add(date.Value.AddDays(1), innerHoliday);
                    }
                }
            }
            return holidayMap;
        }

        //First Monday of February - Constitution Day
        private static Holiday constitutionDay;

        public static Holiday ConstitutionDay
        {
            get
            {
                if (constitutionDay == null)
                {
                    constitutionDay = new NthDayOfWeekInMonthHoliday("Constitution Day", 1, DayOfWeek.Monday, 2,
                        CountDirection.FromFirst);
                }
                return constitutionDay;
            }
        }

        //Third Monday of March - Benito Juarez Birthday
        private static Holiday benitoJuarezBirthDay;

        public static Holiday BenitoJuarezBirthDay
        {
            get
            {
                if (benitoJuarezBirthDay == null)
                {
                    benitoJuarezBirthDay = new NthDayOfWeekInMonthHoliday("Benito Juarez Birthday", 3, DayOfWeek.Monday,
                        3, CountDirection.FromFirst);
                }
                return benitoJuarezBirthDay;
            }
        }

        //16 September - Independence Day
        private static Holiday independenceDay;

        public static Holiday IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new FixedHoliday("Independence Day", 9, 16);
                }
                return independenceDay;
            }
        }

        //Third Monday of November - Revolution Day
        private static Holiday revolutionDay;

        public static Holiday RevolutionDay
        {
            get
            {
                if (revolutionDay == null)
                {
                    revolutionDay = new NthDayOfWeekInMonthHoliday("Revolution Day", 3, DayOfWeek.Monday, 11,
                        CountDirection.FromFirst);
                }
                return revolutionDay;
            }
        }

        //1 December (Every 6 years from year 2000 and on)- Change of Federal Government
        private static Holiday changeOfFederalGovernment;

        public static Holiday ChangeOfFederalGovernment
        {
            get
            {
                if (changeOfFederalGovernment == null)
                {
                    changeOfFederalGovernment =
                        new YearDependantHoliday(year => year >= 2000 && Math.Abs(year - 2000)%6 == 0,
                            new FixedHoliday("National Day", 12, 1));
                }
                return changeOfFederalGovernment;
            }
        }
    }
}