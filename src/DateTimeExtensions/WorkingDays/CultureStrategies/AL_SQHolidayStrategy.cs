using System.Collections.Generic;
using DateTimeExtensions.Common;

// Albanian Holidays 

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("sq-AL")]

    public class SQ_ALHolidayStrategy : HolidayStrategyBase, IObservancesStrategy
    {
        public SQ_ALHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(SummerDay); // Dita e Veres in Albanian
            this.InnerObservances.AddHoliday(ChristianHolidays.Easter);
            this.InnerObservances.AddHoliday(ChristianOrthodoxHolidays.Easter);
            this.InnerObservances.AddHoliday(NewruzDay); // Dita e Nevruzit Shia Muslim
            this.InnerObservances.AddHoliday(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.AddHoliday(MotherTheresaDay); // St. Theresa Day
            this.InnerObservances.AddHoliday(AlphabetDay);
            this.InnerObservances.AddHoliday(IndependenceDay);
            this.InnerObservances.AddHoliday(LiberationDay);
            this.InnerObservances.AddHoliday(NationalYouthDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
            this.InnerObservances.AddHoliday(NewYearHoliday2); // second day of new year is a holiday in Albanian

        }
        private static NamedDay newYearHoliday2;
        public static NamedDay NewYearHoliday2
        {
            get
            {
                if (newYearHoliday2 == null)
                {
                    newYearHoliday2 = new NamedDay("NewYearHoliday2", new FixedDayResolver(1, 2));
                }
                return newYearHoliday2;
            }
        }

        private static NamedDay summerDay;
        public static NamedDay SummerDay
        {
            get
            {
                if (summerDay == null)
                {
                    summerDay = new NamedDay("SummerDay", new FixedDayResolver(3, 14));
                }
                return summerDay;
            }


        }

        // This is a Shia Muslim NamedDay 
        private static NamedDay newruzDay;
        public static NamedDay NewruzDay
        {
            get
            {
                if (newruzDay == null)
                {
                    newruzDay = new NamedDay("NevruzDay", new FixedDayResolver(3, 22));
                }
                return newruzDay;
            }
        }

        // Saint Theresa or known as Mother Theresa
        private static NamedDay motherTheresaDay;
        public static NamedDay MotherTheresaDay
        {
            get
            {
                if (motherTheresaDay == null)
                {
                    motherTheresaDay = new NamedDay("MotherTheresaDay", new FixedDayResolver(9, 5));
                }
                return motherTheresaDay;
            }
        }

        private static NamedDay alphabetDay;
        public static NamedDay AlphabetDay
        {
            get
            {
                if (alphabetDay == null)
                {
                    alphabetDay = new NamedDay("AlphabetDay", new FixedDayResolver(11, 22));
                }
                return alphabetDay;
            }


        }

        private static NamedDay independenceDay;
        public static NamedDay IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new NamedDay("IndipedenceDay", new FixedDayResolver(11, 28));

                }
                return independenceDay;
            }
        }

        private static NamedDay liberationDay;
        public static NamedDay LiberationDay
        {
            get
            {
                if (liberationDay == null)
                {
                    liberationDay = new NamedDay("LiberationDay", new FixedDayResolver(11, 29));
                }
                return liberationDay;
            }
        }

        private static NamedDay nationalYouthDay;

        public static NamedDay NationalYouthDay
        {
            get
            {
                if (nationalYouthDay == null)
                {
                    nationalYouthDay = new NamedDay("NationalYouthDay", new FixedDayResolver(12, 8));
                }
                return nationalYouthDay;
            }
        }


        public IEnumerable<Observance> GetHolidays()
        {
            return this.InnerObservances;
        }
    
    }
}
