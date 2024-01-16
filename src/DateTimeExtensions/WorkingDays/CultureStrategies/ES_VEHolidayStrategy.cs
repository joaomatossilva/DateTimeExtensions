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
    [Locale("es-VE")]
    public class ES_VEHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public ES_VEHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(KingsDay);
            this.InnerHolidays.Add(ConstitutionDay);
            this.InnerHolidays.Add(SimonBolivarBirthDay);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(IndependenceDay);
            this.InnerHolidays.Add(JoseGregorioHernandezDay);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
        }


        // 6 January - Kings Day
        private static Holiday kingsDay;
        public static Holiday KingsDay
        {
            get
            {
                if (kingsDay == null)
                {
                    kingsDay = new FixedHoliday("Kings Day", 6, 1);
                }
                return kingsDay;
            }
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

        //24 July - Simon Bolivar Birthday
        private static Holiday benitoJuarezBirthDay;

        public static Holiday SimonBolivarBirthDay
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


        //5 July - Independence Day
        private static Holiday independenceDay;

        public static Holiday IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new FixedHoliday("Independence Day", 7, 5);
                }
                return independenceDay;
            }
        }

        private static Holiday joseGregorioHernandezDay;
        public static Holiday JoseGregorioHernandezDay
        {
            get
            {
                if (joseGregorioHernandezDay == null)
                {
                    joseGregorioHernandezDay = new FixedHoliday("José Gregorio Hernández's  Day ", 26, 10);
                }
                return joseGregorioHernandezDay;
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
                        new YearDependantHoliday(year => year >= 2000 && Math.Abs(year - 2000) % 6 == 0,
                            new FixedHoliday("National Day", 12, 1));
                }
                return changeOfFederalGovernment;
            }
        }
    }
}