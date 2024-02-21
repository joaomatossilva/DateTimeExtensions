#region License

#endregion

using System.Collections.Generic;
using System.Globalization;
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-IN")]
    public class IndianHolidayStrategy : HolidayStrategyBase
    {
        private static readonly Calendar IndianCalendar = new IndianLunisolarCalendar();

        public IndianHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(RepublicDay);
            this.InnerHolidays.Add(IndependenceDay);
            this.InnerHolidays.Add(GandhiJayanti);
            this.InnerHolidays.Add(Diwali);
            this.InnerHolidays.Add(Holi);
            this.InnerHolidays.Add(Janmashtami);
        }

        // Republic Day
        private static Holiday republicDay;
        public static Holiday RepublicDay
        {
            get
            {
                if (republicDay == null)
                {
                    republicDay = new FixedHoliday("Republic Day", 1, 26, IndianCalendar);
                }
                return republicDay;
            }
        }

        // Independence Day
        private static Holiday independenceDay;
        public static Holiday IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new FixedHoliday("Independence Day", 8, 15, IndianCalendar);
                }
                return independenceDay;
            }
        }

        // Gandhi Jayanti
        private static Holiday gandhiJayanti;
        public static Holiday GandhiJayanti
        {
            get
            {
                if (gandhiJayanti == null)
                {
                    gandhiJayanti = new FixedHoliday("Gandhi Jayanti", 10, 2, IndianCalendar);
                }
                return gandhiJayanti;
            }
        }

        // Diwali (Variable every year)
        private static Holiday diwali;
        public static Holiday Diwali
        {
            get
            {
                if (diwali == null)
                {
                    // Define the occurrences of Diwali based on the Indian lunar calendar
                    var knownDiwaliOccurences = new Dictionary<int, DayInYear>
                    {
                        {2022, new DayInYear(10, 24)},
                        {2023, new DayInYear(11, 13)},
                        {2024, new DayInYear(11, 1)},
                        {2025, new DayInYear(10, 21)},
                    };

                    diwali = new YearMapHoliday("Diwali", knownDiwaliOccurences);
                }
                return diwali;
            }
        }

        // Holi (Variable every year)
        private static Holiday holi;
        public static Holiday Holi
        {
            get
            {
                if (holi == null)
                {
                    // Define the occurrences of Holi based on the Indian lunar calendar
                    var knownHoliOccurences = new Dictionary<int, DayInYear>
                    {
                        {2021, new DayInYear(3, 29)},
                        {2022, new DayInYear(3, 18)},
                        {2023, new DayInYear(3, 8)},
                        {2024, new DayInYear(3, 25)},

                    };

                    holi = new YearMapHoliday("Holi", knownHoliOccurences);
                }
                return holi;
            }
        }

        // Janmashtami (Variable every year)
        private static Holiday janmashtami;
        public static Holiday Janmashtami
        {
            get
            {
                if (janmashtami == null)
                {
                    // Define the occurrences of Janmashtami based on the Indian lunar calendar
                    var knownJanmashtamiOccurences = new Dictionary<int, DayInYear>
                    {    
                        {2022, new DayInYear(8, 19)},
                        {2023, new DayInYear(9, 7)},
                        {2024, new DayInYear(8, 26)},
                        {2025, new DayInYear(8, 16)},
                       
                    };

                    janmashtami = new YearMapHoliday("Janmashtami", knownJanmashtamiOccurences);
                }
                return janmashtami;
            }
        }
    }
}
