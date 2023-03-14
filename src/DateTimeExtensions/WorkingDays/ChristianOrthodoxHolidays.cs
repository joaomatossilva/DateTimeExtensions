using System;

namespace DateTimeExtensions.WorkingDays
{
    public class ChristianOrthodoxHolidays
    {

        private static Holiday goodFriday;

        public static Holiday GoodFriday
        {
            get
            {
                if (goodFriday == null)
                {
                    goodFriday = new NthDayOfWeekAfterDayHoliday("GoodFriday", -1, DayOfWeek.Friday, Easter);
                }
                return goodFriday;
            }
        }

        private static Holiday easter;

        public static Holiday Easter
        {
            get
            {
                if (easter == null)
                {
                    easter = new EasterOrthodoxBasedHoliday("Easter", 0);
                }
                return easter;
            }
        }


        private static Holiday easterMonday;

        public static Holiday EasterMonday
        {
            get
            {
                if (easterMonday == null)
                {
                    easterMonday = new EasterOrthodoxBasedHoliday("EasterMonday", 1);
                }
                return easterMonday;
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

        private static Holiday pentecostMonday;

        public static Holiday PentecostMonday
        {
            get
            {
                if (pentecostMonday == null)
                {
                    pentecostMonday = new NthDayOfWeekAfterDayHoliday("PentecostMonday", 8, DayOfWeek.Monday, Easter);
                }
                return pentecostMonday;
            }
        }
    }
}