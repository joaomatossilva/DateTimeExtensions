using System;
using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-NG")]
    public class EN_NGHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_NGHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(IndependenceDay);
            this.InnerHolidays.Add(DemocracyDay);
            this.InnerHolidays.Add(ChristmasDay);
            this.InnerHolidays.Add(BoxingDay);
            this.InnerHolidays.Add(GoodFriday);
            this.InnerHolidays.Add(EasterMonday);
            this.InnerHolidays.Add(Maulid);
            this.InnerHolidays.Add(EidAlFitr);
            this.InnerHolidays.Add(EidAlAdha);
        }

        // Fixed Holidays

        // 1 October - Independence Day
        private static Holiday independenceDay;
        public static Holiday IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new FixedHoliday("Independence Day", 10, 1);
                }
                return independenceDay;
            }
        }

        // 12 June - Democracy Day
        private static Holiday democracyDay;
        public static Holiday DemocracyDay
        {
            get
            {
                if (democracyDay == null)
                {
                    democracyDay = new FixedHoliday("Democracy Day", 6, 12);
                }
                return democracyDay;
            }
        }

        // 1 May - Workers' Day (also International Workers' Day)
        private static Holiday workersDay;
        public static Holiday WorkersDay
        {
            get
            {
                if (workersDay == null)
                {
                    workersDay = new FixedHoliday("Workers' Day", 5, 1);
                }
                return workersDay;
            }
        }

        // 25 December - Christmas Day
        private static Holiday christmasDay;
        public static Holiday ChristmasDay
        {
            get
            {
                if (christmasDay == null)
                {
                    christmasDay = new FixedHoliday("Christmas Day", 12, 25);
                }
                return christmasDay;
            }
        }

        // 26 December - Boxing Day
        private static Holiday boxingDay;
        public static Holiday BoxingDay
        {
            get
            {
                if (boxingDay == null)
                {
                    boxingDay = new FixedHoliday("Boxing Day", 12, 26);
                }
                return boxingDay;
            }
        }

        // Dynamic Holidays

        // Good Friday (2 days before Easter Sunday)
        private static Holiday goodFriday;
        public static Holiday GoodFriday
        {
            get
            {
                if (goodFriday == null)
                {
                    goodFriday = new RelativeHoliday("Good Friday", GlobalHolidays.EasterSunday, -2);
                }
                return goodFriday;
            }
        }

        // Easter Monday (1 day after Easter Sunday)
        private static Holiday easterMonday;
        public static Holiday EasterMonday
        {
            get
            {
                if (easterMonday == null)
                {
                    easterMonday = new RelativeHoliday("Easter Monday", GlobalHolidays.EasterSunday, 1);
                }
                return easterMonday;
            }
        }

        // Eid al-Fitr (Islamic calendar, date changes each year)
        private static Holiday eidAlFitr;
        public static Holiday EidAlFitr
        {
            get
            {
                if (eidAlFitr == null)
                {
                    eidAlFitr = new IslamicHoliday("Eid al-Fitr");
                }
                return eidAlFitr;
            }
        }

        // Eid al-Adha (Islamic calendar, date changes each year)
        private static Holiday eidAlAdha;
        public static Holiday EidAlAdha
        {
            get
            {
                if (eidAlAdha == null)
                {
                    eidAlAdha = new IslamicHoliday("Eid al-Adha");
                }
                return eidAlAdha;
            }
        }

        // Maulid an-Nabi (Birth of Prophet Muhammad)
        private static Holiday maulid;
        public static Holiday Maulid
        {
            get
            {
                if (maulid == null)
                {
                    maulid = new IslamicHoliday("Maulid an-Nabi");
                }
                return maulid;
            }
        }
    }
}
