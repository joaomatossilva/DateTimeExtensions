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

namespace DateTimeExtensions.WorkingDays
{
    public static class ChristianHolidays
    {
        private static Holiday christmas;

        public static Holiday Christmas
        {
            get
            {
                if (christmas == null)
                {
                    christmas = new FixedHoliday("Christmas", 12, 25);
                }
                return christmas;
            }
        }

        private static Holiday epiphany;

        public static Holiday Epiphany
        {
            get
            {
                if (epiphany == null)
                {
                    epiphany = new FixedHoliday("Epiphany", 1, 6);
                }
                return epiphany;
            }
        }

        private static Holiday assumption;

        public static Holiday Assumption
        {
            get
            {
                if (assumption == null)
                {
                    assumption = new FixedHoliday("Assumption", 8, 15);
                }
                return assumption;
            }
        }

        private static Holiday allSaints;

        public static Holiday AllSaints
        {
            get
            {
                if (allSaints == null)
                {
                    allSaints = new FixedHoliday("AllSaints", 11, 1);
                }
                return allSaints;
            }
        }

        private static Holiday dayOfTheDead;

        public static Holiday DayOfTheDead
        {
            get
            {
                if (dayOfTheDead == null)
                {
                    dayOfTheDead = new FixedHoliday("DayOfTheDead", 11, 2);
                }
                return dayOfTheDead;
            }
        }

        private static Holiday imaculateConception;

        public static Holiday ImaculateConception
        {
            get
            {
                if (imaculateConception == null)
                {
                    imaculateConception = new FixedHoliday("ImaculateConception", 12, 8);
                }
                return imaculateConception;
            }
        }

        private static Holiday easter;

        public static Holiday Easter
        {
            get
            {
                if (easter == null)
                {
                    easter = new EasterBasedHoliday("Easter", 0);
                }
                return easter;
            }
        }

        private static Holiday carnival;

        public static Holiday Carnival
        {
            get
            {
                if (carnival == null)
                {
                    carnival = new EasterBasedHoliday("Carnival", -47);
                }
                return carnival;
            }
        }

        //source: http://en.wikipedia.org/wiki/Palm_Sunday
        //Palm Sunday is a Christian moveable feast that falls on the Sunday before Easter
        private static Holiday palmSunday;

        public static Holiday PalmSunday
        {
            get
            {
                if (palmSunday == null)
                {
                    palmSunday = new NthDayOfWeekAfterDayHoliday("PalmSunday", -1, DayOfWeek.Sunday, Easter);
                }
                return palmSunday;
            }
        }

        private static Holiday maundyThursday;

        public static Holiday MaundyThursday
        {
            get
            {
                if (maundyThursday == null)
                {
                    maundyThursday = new EasterBasedHoliday("MaundyThursday", -3);
                }
                return maundyThursday;
            }
        }

        private static Holiday goodFriday;

        public static Holiday GoodFriday
        {
            get
            {
                if (goodFriday == null)
                {
                    goodFriday = new EasterBasedHoliday("GoodFriday", -2);
                }
                return goodFriday;
            }
        }

        private static Holiday easterMonday;

        public static Holiday EasterMonday
        {
            get
            {
                if (easterMonday == null)
                {
                    easterMonday = new EasterBasedHoliday("EasterMonday", 1);
                }
                return easterMonday;
            }
        }

        private static Holiday easterSaturday;

        public static Holiday EasterSaturday
        {
            get
            {
                if (easterSaturday == null)
                {
                    easterSaturday = new EasterBasedHoliday("EasterSaturday", -1);
                }
                return easterSaturday;
            }
        }

        private static Holiday corpusChristi;

        public static Holiday CorpusChristi
        {
            get
            {
                if (corpusChristi == null)
                {
                    corpusChristi = new EasterBasedHoliday("CorpusChristi", 60);
                }
                return corpusChristi;
            }
        }

        //source: http://en.wikipedia.org/wiki/Pentecost
        //50 days after Easter (inclusive of Easter Day). In other words, it falls on the eighth Sunday, counting Easter Day 
        //Also know as Whit Sunday, Whitsun, Whit
        private static Holiday pentecost;

        public static Holiday Pentecost
        {
            get
            {
                if (pentecost == null)
                {
                    //count offset is 7 because we aren't counting with the easter day inclusive
                    pentecost = new NthDayOfWeekAfterDayHoliday("Pentecost", 7, DayOfWeek.Sunday, Easter);
                }
                return pentecost;
            }
        }

        //Also known as Whit monday
        private static Holiday pentecostMonday;

        public static Holiday PentecostMonday
        {
            get
            {
                if (pentecostMonday == null)
                {
                    pentecostMonday = new EasterBasedHoliday("PentecostMonday", 50);
                }
                return pentecostMonday;
            }
        }

        //source: http://en.wikipedia.org/wiki/Ascension_Day
        // Ascension Day is traditionally celebrated on a Thursday, the fortieth day of Easter
        // again, easter day is included
        private static Holiday ascension;

        public static Holiday Ascension
        {
            get
            {
                if (ascension == null)
                {
                    ascension = new EasterBasedHoliday("Ascension", 39);
                }
                return ascension;
            }
        }

        private static Holiday christmasEve;

        public static Holiday ChristmasEve
        {
            get
            {
                if (christmasEve == null)
                {
                    christmasEve = new FixedHoliday("ChristmasEve", 12, 24);
                }
                return christmasEve;
            }
        }

        private static Holiday stStephensDay;

        public static Holiday StStephansDay
        {
            get
            {
                if (stStephensDay == null)
                {
                    stStephensDay = new FixedHoliday("StStephenDay", 12, 26);
                }
                return stStephensDay;
            }
        }
    }
}