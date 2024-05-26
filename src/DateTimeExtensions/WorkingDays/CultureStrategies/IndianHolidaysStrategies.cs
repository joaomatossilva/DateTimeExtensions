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
            this.InnerHolidays.Add(Dussehra);
            this.InnerHolidays.Add(GuruNanakJayanti);
            this.InnerHolidays.Add(BuddhaPurnima);
            this.InnerHolidays.Add(GoodFriday);
            this.InnerHolidays.Add(ChristmasDay);
            this.InnerHolidays.Add(EidUlFitr);
            this.InnerHolidays.Add(EidUlAdha);
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

        // Dussehra (Vijayadashami) (Variable every year)
        private static Holiday dussehra;
        public static Holiday Dussehra
        {
            get
            {
                if (dussehra == null)
                {
                    // Define the occurrences of Dussehra based on the Indian lunar calendar
                    var knownDussehraOccurences = new Dictionary<int, DayInYear>
                    {
                        {2022, new DayInYear(10, 5)},
                        {2023, new DayInYear(10, 24)},
                        {2024, new DayInYear(10, 12)},
                        {2025, new DayInYear(10, 2)},
                    };

                    dussehra = new YearMapHoliday("Dussehra", knownDussehraOccurences);
                }
                return dussehra;
            }
        }

        // Guru Nanak Jayanti (Variable every year)
        private static Holiday guruNanakJayanti;
        public static Holiday GuruNanakJayanti
        {
            get
            {
                if (guruNanakJayanti == null)
                {
                    // Define the occurrences of Guru Nanak Jayanti based on the Indian lunar calendar
                    var knownGuruNanakJayantiOccurences = new Dictionary<int, DayInYear>
                    {
                        {2022, new DayInYear(11, 8)},
                        {2023, new DayInYear(11, 27)},
                        {2024, new DayInYear(11, 15)},
                        {2025, new DayInYear(11, 5)},
                    };

                    guruNanakJayanti = new YearMapHoliday("Guru Nanak Jayanti", knownGuruNanakJayantiOccurences);
                }
                return guruNanakJayanti;
            }
        }

        // Buddha Purnima (Variable every year)
        private static Holiday buddhaPurnima;
        public static Holiday BuddhaPurnima
        {
            get
            {
                if (buddhaPurnima == null)
                {
                    // Define the occurrences of Buddha Purnima based on the Indian lunar calendar
                    var knownBuddhaPurnimaOccurences = new Dictionary<int, DayInYear>
                    {
                        {2022, new DayInYear(5, 16)},
                        {2023, new DayInYear(5, 5)},
                        {2024, new DayInYear(5, 23)},
                        {2025, new DayInYear(5, 12)},
                    };

                    buddhaPurnima = new YearMapHoliday("Buddha Purnima", knownBuddhaPurnimaOccurences);
                }
                return buddhaPurnima;
            }
        }

        // Good Friday (Variable every year)
        private static Holiday goodFriday;
        public static Holiday GoodFriday
        {
            get
            {
                if (goodFriday == null)
                {
                    // Define the occurrences of Good Friday based on the Indian lunar calendar
                    var knownGoodFridayOccurences = new Dictionary<int, DayInYear>
                    {
                        {2022, new DayInYear(4, 15)},
                        {2023, new DayInYear(4, 7)},
                        {2024, new DayInYear(3, 29)},
                        {2025, new DayInYear(4, 18)},
                    };

                    goodFriday = new YearMapHoliday("Good Friday", knownGoodFridayOccurences);
                }
                return goodFriday;
            }
        }

        // Christmas Day (fixed every year)
        private static Holiday christmasDay;
        public static Holiday ChristmasDay
        {
            get
            {
                if (christmasDay == null)
                {
                    christmasDay = new FixedHoliday("Christmas Day", 12, 25, IndianCalendar);
                }
                return christmasDay;
            }
        }

        // Eid ul-Fitr (Variable every year)
        private static Holiday eidUlFitr;
        public static Holiday EidUlFitr
        
            get
            {
                if (eidUlFitr == null)
                {
                    // Define the occurrences of Eid ul-Fitr based on the Indian lunar calendar
                    var knownEidUlFitrOccurences = new Dictionary<int, DayInYear>
                    {
                        {2022, new DayInYear(5, 2)},
                        {2023, new DayInYear(4, 21)},
                        {2024, new DayInYear(4, 10)},
                        {2025, new DayInYear(3, 30)},
                    };

                    eidUlFitr = new YearMapHoliday("Eid ul-Fitr", knownEidUlFitrOccurences);
                }
                return eidUlFitr;
            }
        }

        // Eid ul-Adha (Variable every year)
        private static Holiday eidUlAdha;
        public static Holiday EidUlAdha
        {
            get
            {
                if (eidUlAdha == null)
                {
                    // Define the occurrences of Eid ul-Adha based on the Indian lunar calendar
                    var knownEidUlAdhaOccurences = new Dictionary<int, DayInYear>
                    {
                        {2022, new DayInYear(7, 10)},
                        {2023, new DayInYear(6, 29)},
                        {2024, new DayInYear(6, 17)},
                        {2025, new DayInYear(6, 6)},
                    };

                    eidUlAdha = new YearMapHoliday("Eid ul-Adha", knownEidUlAdhaOccurences);
                }
                return eidUlAdha;
            }
        }
}
