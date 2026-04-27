using System;
using DateTimeExtensions.WorkingDays.DayInYearResolvers;

namespace DateTimeExtensions.WorkingDays
{
    public class ChristianOrthodoxHolidays
    {

        private static NamedDay goodFriday;

        public static NamedDay GoodFriday
        {
            get
            {
                if (goodFriday == null)
                {
                    goodFriday = new NamedDay("GoodFriday", new NthDayOfWeekAfterDayResolver(-1, DayOfWeek.Friday, Easter.Resolver));
                }
                return goodFriday;
            }
        }

        private static NamedDay easter;

        public static NamedDay Easter
        {
            get
            {
                if (easter == null)
                {
                    easter = new NamedDay("Easter", new OrthodoxEasterBasedDayResolver(0));
                }
                return easter;
            }
        }


        private static NamedDay easterMonday;

        public static NamedDay EasterMonday
        {
            get
            {
                if (easterMonday == null)
                {
                    easterMonday = new NamedDay("EasterMonday", new OrthodoxEasterBasedDayResolver(1));
                }
                return easterMonday;
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

        private static NamedDay pentecostMonday;

        public static NamedDay PentecostMonday
        {
            get
            {
                if (pentecostMonday == null)
                {
                    pentecostMonday = new NamedDay("PentecostMonday", new NthDayOfWeekAfterDayResolver(8, DayOfWeek.Monday, Easter.Resolver));
                }
                return pentecostMonday;
            }
        }
    }
}
