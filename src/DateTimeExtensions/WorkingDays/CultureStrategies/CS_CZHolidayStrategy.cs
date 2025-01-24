using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("cs-CZ")]
    public class CS_CZHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public CS_CZHolidayStrategy()
        {
            // January 1 has two holidays
            this.InnerHolidays.Add(NewYearAndRestorationOfIndependence);
            // Good Friday has been a holiday since 2016.
            this.InnerHolidays.Add(GoodFridayCzechia);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(LabourDay);
            this.InnerHolidays.Add(VictoryDay);
            this.InnerHolidays.Add(CyrilAndMethodiusDay);
            this.InnerHolidays.Add(JanHusDay);
            this.InnerHolidays.Add(StatehoodDay);
            this.InnerHolidays.Add(CzechoslovakIndependenceDay);
            this.InnerHolidays.Add(FreedomAndDemocracyAndStudentsDay);
            // The main Christmas holiday is on December 24 while the 25 and 26 are also bank holidays.
            this.InnerHolidays.Add(ChristmasEve);
            this.InnerHolidays.Add(FirstChristmasDay);
            this.InnerHolidays.Add(SecondChristmasDay);
        }

        private static Holiday restorationOfIndependenceDay;
        public static Holiday NewYearAndRestorationOfIndependence
        {
            get
            {
                if (restorationOfIndependenceDay == null)
                {
                    restorationOfIndependenceDay = new FixedHoliday(
                        "New Year's Day, Restoration Day of the Independent Czech State", 1, 1);
                }
                return restorationOfIndependenceDay;
            }
        }

        private static Holiday goodFridayYearDependant;
        public static Holiday GoodFridayCzechia
        {
            get
            {
                if (goodFridayYearDependant == null)
                {
                    goodFridayYearDependant = new YearDependantHoliday(
                        year => year > 2015, ChristianHolidays.GoodFriday);
                }
                return goodFridayYearDependant;
            }
        }

        private static Holiday labourDay;
        public static Holiday LabourDay
        {
            get
            {
                if (labourDay == null)
                {
                    labourDay = new FixedHoliday("Labour Day", 5, 1);
                }
                return labourDay;
            }
        }

        private static Holiday victoryDay;
        public static Holiday VictoryDay
        {
            get
            {
                if (victoryDay == null)
                {
                    victoryDay = new FixedHoliday("Victory Day", 5, 8);
                }
                return victoryDay;
            }
        }

        private static Holiday cyrilAndMethodiusDay;
        public static Holiday CyrilAndMethodiusDay
        {
            get
            {
                if (cyrilAndMethodiusDay == null)
                {
                    cyrilAndMethodiusDay = new FixedHoliday("Saints Cyril and Methodius Day", 7, 5);
                }
                return cyrilAndMethodiusDay;
            }
        }

        private static Holiday janHusDay;
        public static Holiday JanHusDay
        {
            get
            {
                if (janHusDay == null)
                {
                    janHusDay = new FixedHoliday("Jan Hus Day", 7, 6);
                }
                return janHusDay;
            }
        }

        private static Holiday statehoodDay;
        public static Holiday StatehoodDay
        {
            get
            {
                if (statehoodDay == null)
                {
                    statehoodDay = new FixedHoliday("Czech Statehood Day", 9, 28);
                }
                return statehoodDay;
            }
        }

        private static Holiday czechoslovakIndependenceDay;
        public static Holiday CzechoslovakIndependenceDay
        {
            get
            {
                if (czechoslovakIndependenceDay == null)
                {
                    czechoslovakIndependenceDay = new FixedHoliday("Independent Czechoslovak State Day", 10, 28);
                }
                return czechoslovakIndependenceDay;
            }
        }

        private static Holiday freedomAndDemocracyDay;
        public static Holiday FreedomAndDemocracyAndStudentsDay
        {
            get
            {
                if (freedomAndDemocracyDay == null)
                {
                    freedomAndDemocracyDay = new FixedHoliday(
                        "Struggle for Freedom and Democracy Day and International Students' Day", 11, 17);
                }
                return freedomAndDemocracyDay;
            }
        }

        private static Holiday christmasEve;
        public static Holiday ChristmasEve
        {
            get
            {
                if (christmasEve == null)
                {
                    christmasEve = new FixedHoliday("Christmas Eve", 12, 24);
                }
                return christmasEve;
            }
        }

        private static Holiday firstChristmasDay;
        public static Holiday FirstChristmasDay
        {
            get
            {
                if (firstChristmasDay == null)
                {
                    firstChristmasDay = new FixedHoliday("1st Christmas Day", 12, 25);
                }
                return firstChristmasDay;
            }
        }

        private static Holiday secondChristmasDay;
        public static Holiday SecondChristmasDay
        {
            get
            {
                if (secondChristmasDay == null)
                {
                    secondChristmasDay = new FixedHoliday("2nd Christmas Day", 12, 26);
                }
                return secondChristmasDay;
            }
        }
    }
}
