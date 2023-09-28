#region License

// 
// Copyright (c) 2011-2012, Onur Özten <onur301@gmail.com>
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

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("ro-RO")]
    public class RomanianHolidayStrategy : HolidayStrategyBase
    {
        public RomanianHolidayStrategy()
        {
            //1-2 January
            //Anul Nou
            //New Year's Day
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(NewYearSecondDay);

            //6 Boboteaza
            //7 Sf. Ioan Botezatorul

            //24 January
            //Ziua Unirii Principatelor Române
            //Day of the Unification of the Romanian Principalities
            //It celebrates the unification of the Romanian Principalities of Moldavia and Wallachia in 1859 and the foundation of the Romanian modern state.[2] A non-working day since 2016. 
            this.InnerHolidays.Add(DayOfTheUnification);

            //Vinerea Mare
            this.InnerHolidays.Add(ChristianOrthodoxHolidays.GoodFriday);

            //Paștele 	Easter, Easter Monday
            //The official holiday is the Orthodox Easter.
            //The holiday is three days long, Good Friday,[3] Easter Sunday and Monday are non-working, Tuesday is not a public holiday. 
            this.InnerHolidays.Add(ChristianOrthodoxHolidays.Easter);
            this.InnerHolidays.Add(ChristianOrthodoxHolidays.EasterMonday);

            //1 May
            //Ziua Muncii
            //Labour Day
            //International Labour Day 
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);

            //1 June
            //Ziua Copilului
            //Children's Day
            //Public holiday starting with 2017[4]
            this.InnerHolidays.Add(ChildrensDay);

            //Rusaliile
            //Pentecost, Whit Monday
            //The 50th and 51st day after the Orthodox Easter. 
            this.InnerHolidays.Add(ChristianOrthodoxHolidays.Pentecost);
            this.InnerHolidays.Add(ChristianOrthodoxHolidays.PentecostMonday);

            //15 August
            //Adormirea Maicii Domnului/Sfânta Maria Mare
            //Dormition of the Mother of God
            //Also the Day of the Romanian Naval Forces since St. Mary is the patron saint of the Navy. 
            this.InnerHolidays.Add(Assumption);

            //30 November
            //Sfântul Andrei
            //Saint Andrew's Day
            //Saint Andrew is the patron saint of Romania. 
            this.InnerHolidays.Add(SaintAndrewDay);

            //1 December
            //Ziua Națională a României
            //National Day of Romania
            //It celebrates the unification of Transylvania, Bessarabia and Bukovina with the Kingdom of Romania. 
            this.InnerHolidays.Add(NationalDayOfRomania);

            //25-26 December
            //Crăciunul
            //Christmas Day
            //Both first and second Christmas Day are holidays. Third Christmas Day is not a public holiday. 
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(ChristmasSecondDay);
            
            this.InnerHolidays.Add(GlobalHolidays.NewYearsEve);
        }

        private static Holiday newYearSecondDay;
        public static Holiday NewYearSecondDay
        {
            get
            {
                if (newYearSecondDay == null)
                {
                    newYearSecondDay = new FixedHoliday("NewYearSecondDay", 1, 2);
                }
                return newYearSecondDay;
            }
        }

        private static Holiday dayOfTheUnification;
        public static Holiday DayOfTheUnification
        {
            get
            {
                if (dayOfTheUnification == null)
                {
                    dayOfTheUnification = new YearDependantHoliday(year => year >= 2016, new FixedHoliday("DayOfTheUnification", 1, 24));
                }
                return dayOfTheUnification;
            }
        }

        private static Holiday childrensDay;
        public static Holiday ChildrensDay
        {
            get
            {
                if (childrensDay == null)
                {
                    childrensDay = new YearDependantHoliday(year => year >= 2017, new FixedHoliday("ChildrensDay", 6, 1));
                }
                return childrensDay;
            }
        }
        
        private static Holiday assumption;
        public static Holiday Assumption
        {
            get
            {
                if (assumption == null)
                {
                    assumption = new YearDependantHoliday(year => year >= 2008, ChristianHolidays.Assumption);
                }
                return assumption;
            }
        }

        private static Holiday saintAndrewDay;
        public static Holiday SaintAndrewDay
        {
            get
            {
                if (saintAndrewDay == null)
                {
                    saintAndrewDay = new YearDependantHoliday(year => year >= 2012, new FixedHoliday("SaintAndrewDay", 11, 30));
                }
                return saintAndrewDay;
            }
        }

        private static Holiday nationalDayOfRomania;
        public static Holiday NationalDayOfRomania
        {
            get
            {
                if (nationalDayOfRomania == null)
                {
                    nationalDayOfRomania = new YearDependantHoliday(year => year >= 1990, new FixedHoliday("NationalDayOfRomania", 12, 1));
                }
                return nationalDayOfRomania;
            }
        }

        private static Holiday christmasSecondDay;
        public static Holiday ChristmasSecondDay
        {
            get
            {
                if (christmasSecondDay == null)
                {
                    christmasSecondDay = new FixedHoliday("ChristmasSecondDay", 12, 26);
                }
                return christmasSecondDay;
            }
        }
    }
}