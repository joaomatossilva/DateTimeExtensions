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
using DateTimeExtensions.WorkingDays.DayInYearResolvers;

namespace DateTimeExtensions.WorkingDays
{
    public static class ChristianHolidays
    {
        private static NamedDay christmas;

        public static NamedDay Christmas
        {
            get
            {
                if (christmas == null)
                {
                    christmas = new NamedDay("Christmas", new FixedDayResolver(12, 25));
                }
                return christmas;
            }
        }

        private static NamedDay epiphany;

        public static NamedDay Epiphany
        {
            get
            {
                if (epiphany == null)
                {
                    epiphany = new NamedDay("Epiphany", new FixedDayResolver(1, 6));
                }
                return epiphany;
            }
        }

        private static NamedDay assumption;

        public static NamedDay Assumption
        {
            get
            {
                if (assumption == null)
                {
                    assumption = new NamedDay("Assumption", new FixedDayResolver(8, 15));
                }
                return assumption;
            }
        }

        private static NamedDay allSaints;

        public static NamedDay AllSaints
        {
            get
            {
                if (allSaints == null)
                {
                    allSaints = new NamedDay("AllSaints", new FixedDayResolver(11, 1));
                }
                return allSaints;
            }
        }

        private static NamedDay dayOfTheDead;

        public static NamedDay DayOfTheDead
        {
            get
            {
                if (dayOfTheDead == null)
                {
                    dayOfTheDead = new NamedDay("DayOfTheDead", new FixedDayResolver(11, 2));
                }
                return dayOfTheDead;
            }
        }

        private static NamedDay imaculateConception;

        public static NamedDay ImaculateConception
        {
            get
            {
                if (imaculateConception == null)
                {
                    imaculateConception = new NamedDay("ImaculateConception", new FixedDayResolver(12, 8));
                }
                return imaculateConception;
            }
        }

        private static NamedDay easter;

        public static NamedDay Easter
        {
            get
            {
                if (easter == null)
                {
                    easter = new NamedDay("Easter", new EasterBasedDayResolver(0));
                }
                return easter;
            }
        }

        //source: https://en.wikipedia.org/wiki/Ash_Wednesday
        //
        private static NamedDay ashWednesday;
        public static NamedDay AshWednesday
        {
            get
            {
                if (ashWednesday == null)
                {
                    ashWednesday = new NamedDay("AshWednesday", new EasterBasedDayResolver(-46));
                }
                return ashWednesday;
            }
        }


        private static NamedDay carnival;

        public static NamedDay Carnival
        {
            get
            {
                if (carnival == null)
                {
                    carnival = new NamedDay("Carnival", new EasterBasedDayResolver(-47));
                }
                return carnival;
            }
        }

        //source: http://en.wikipedia.org/wiki/Palm_Sunday
        //Palm Sunday is a Christian moveable feast that falls on the Sunday before Easter
        private static NamedDay palmSunday;

        public static NamedDay PalmSunday
        {
            get
            {
                if (palmSunday == null)
                {
                    palmSunday = new NamedDay("PalmSunday", new NthDayOfWeekAfterDayResolver(-1, DayOfWeek.Sunday, Easter.Resolver));
                }
                return palmSunday;
            }
        }

        private static NamedDay maundyThursday;

        public static NamedDay MaundyThursday
        {
            get
            {
                if (maundyThursday == null)
                {
                    maundyThursday = new NamedDay("MaundyThursday", new EasterBasedDayResolver(-3));
                }
                return maundyThursday;
            }
        }

        private static NamedDay goodFriday;

        public static NamedDay GoodFriday
        {
            get
            {
                if (goodFriday == null)
                {
                    goodFriday = new NamedDay("GoodFriday", new EasterBasedDayResolver(-2));
                }
                return goodFriday;
            }
        }

        private static NamedDay easterMonday;

        public static NamedDay EasterMonday
        {
            get
            {
                if (easterMonday == null)
                {
                    easterMonday = new NamedDay("EasterMonday", new EasterBasedDayResolver(1));
                }
                return easterMonday;
            }
        }

        private static NamedDay easterSaturday;

        public static NamedDay EasterSaturday
        {
            get
            {
                if (easterSaturday == null)
                {
                    easterSaturday = new NamedDay("EasterSaturday", new EasterBasedDayResolver(-1));
                }
                return easterSaturday;
            }
        }

        private static NamedDay corpusChristi;

        public static NamedDay CorpusChristi
        {
            get
            {
                if (corpusChristi == null)
                {
                    corpusChristi = new NamedDay("CorpusChristi", new EasterBasedDayResolver(60));
                }
                return corpusChristi;
            }
        }

        //source: http://en.wikipedia.org/wiki/Pentecost
        //50 days after Easter (inclusive of Easter Day). In other words, it falls on the eighth Sunday, counting Easter Day 
        //Also know as Whit Sunday, Whitsun, Whit
        private static NamedDay pentecost;

        public static NamedDay Pentecost
        {
            get
            {
                if (pentecost == null)
                {
                    //count offset is 7 because we aren't counting with the easter day inclusive
                    pentecost = new NamedDay("Pentecost", new NthDayOfWeekAfterDayResolver(7, DayOfWeek.Sunday, Easter.Resolver));
                }
                return pentecost;
            }
        }

        //Also known as Whit monday
        private static NamedDay pentecostMonday;

        public static NamedDay PentecostMonday
        {
            get
            {
                if (pentecostMonday == null)
                {
                    pentecostMonday = new NamedDay("PentecostMonday", new EasterBasedDayResolver(50));
                }
                return pentecostMonday;
            }
        }

        //source: http://en.wikipedia.org/wiki/Ascension_Day
        // Ascension Day is traditionally celebrated on a Thursday, the fortieth day of Easter
        // again, easter day is included
        private static NamedDay ascension;

        public static NamedDay Ascension
        {
            get
            {
                if (ascension == null)
                {
                    ascension = new NamedDay("Ascension", new EasterBasedDayResolver(39));
                }
                return ascension;
            }
        }

        private static NamedDay christmasEve;

        public static NamedDay ChristmasEve
        {
            get
            {
                if (christmasEve == null)
                {
                    christmasEve = new NamedDay("ChristmasEve", new FixedDayResolver(12, 24));
                }
                return christmasEve;
            }
        }

        private static NamedDay stStephensDay;

        public static NamedDay StStephansDay
        {
            get
            {
                if (stStephensDay == null)
                {
                    stStephensDay = new NamedDay("StStephenDay", new FixedDayResolver(12, 26));
                }
                return stStephensDay;
            }
        }

        private static NamedDay stsPeterAndPaul;

        public static NamedDay StsPeterAndPaul
        {
            get
            {
                if(stsPeterAndPaul == null)
                {
                    stsPeterAndPaul = new NamedDay("StsPeterAndPaul", new FixedDayResolver(6, 29));
                }
                return stsPeterAndPaul;
            }
        }

        private static NamedDay stRoseofLima;

        public static NamedDay StRoseOfLima
        {
            get
            {
                if(stRoseofLima == null)
                {
                    stRoseofLima = new NamedDay("St. Rose of Lima", new FixedDayResolver(8, 23));
                }
                return stRoseofLima;
            }
        }
    }
}