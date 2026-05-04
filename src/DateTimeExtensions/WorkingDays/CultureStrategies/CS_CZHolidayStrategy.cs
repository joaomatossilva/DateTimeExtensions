using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("cs-CZ")]
    public class CS_CZHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public CS_CZHolidayStrategy()
        {
            // January 1 has two holidays
            this.InnerObservances.Add(NewYearAndRestorationOfIndependence);
            // Good Friday has been a holiday since 2016.
            this.InnerObservances.Add(GoodFridayCzechia);
            this.InnerObservances.Add(ChristianHolidays.EasterMonday);
            this.InnerObservances.Add(LabourDay);
            this.InnerObservances.Add(VictoryDay);
            this.InnerObservances.Add(CyrilAndMethodiusDay);
            this.InnerObservances.Add(JanHusDay);
            this.InnerObservances.Add(StatehoodDay);
            this.InnerObservances.Add(CzechoslovakIndependenceDay);
            this.InnerObservances.Add(FreedomAndDemocracyAndStudentsDay);
            // The main Christmas holiday is on December 24 while the 25 and 26 are also bank holidays.
            this.InnerObservances.Add(ChristmasEve);
            this.InnerObservances.Add(FirstChristmasDay);
            this.InnerObservances.Add(SecondChristmasDay);
        }

        private static NamedDay restorationOfIndependenceDay;
        public static NamedDay NewYearAndRestorationOfIndependence
        {
            get
            {
                if (restorationOfIndependenceDay == null)
                {
                    restorationOfIndependenceDay = new NamedDay(
                        "New Year's Day, Restoration Day of the Independent Czech State",
                        new FixedDayResolver(1, 1));
                }
                return restorationOfIndependenceDay;
            }
        }

        private static NamedDay goodFridayYearDependant;
        public static NamedDay GoodFridayCzechia
        {
            get
            {
                if (goodFridayYearDependant == null)
                {
                    goodFridayYearDependant = new NamedDay(
                        ChristianHolidays.GoodFriday.Name,
                        new YearDependantDayResolver(year => year > 2015, ChristianHolidays.GoodFriday.Resolver));
                }
                return goodFridayYearDependant;
            }
        }

        private static NamedDay labourDay;
        public static NamedDay LabourDay
        {
            get
            {
                if (labourDay == null)
                {
                    labourDay = new NamedDay("Labour Day", new FixedDayResolver(5, 1));
                }
                return labourDay;
            }
        }

        private static NamedDay victoryDay;
        public static NamedDay VictoryDay
        {
            get
            {
                if (victoryDay == null)
                {
                    victoryDay = new NamedDay("Victory Day", new FixedDayResolver(5, 8));
                }
                return victoryDay;
            }
        }

        private static NamedDay cyrilAndMethodiusDay;
        public static NamedDay CyrilAndMethodiusDay
        {
            get
            {
                if (cyrilAndMethodiusDay == null)
                {
                    cyrilAndMethodiusDay = new NamedDay("Saints Cyril and Methodius Day", new FixedDayResolver(7, 5));
                }
                return cyrilAndMethodiusDay;
            }
        }

        private static NamedDay janHusDay;
        public static NamedDay JanHusDay
        {
            get
            {
                if (janHusDay == null)
                {
                    janHusDay = new NamedDay("Jan Hus Day", new FixedDayResolver(7, 6));
                }
                return janHusDay;
            }
        }

        private static NamedDay statehoodDay;
        public static NamedDay StatehoodDay
        {
            get
            {
                if (statehoodDay == null)
                {
                    statehoodDay = new NamedDay("Czech Statehood Day", new FixedDayResolver(9, 28));
                }
                return statehoodDay;
            }
        }

        private static NamedDay czechoslovakIndependenceDay;
        public static NamedDay CzechoslovakIndependenceDay
        {
            get
            {
                if (czechoslovakIndependenceDay == null)
                {
                    czechoslovakIndependenceDay = new NamedDay("Independent Czechoslovak State Day", new FixedDayResolver(10, 28));
                }
                return czechoslovakIndependenceDay;
            }
        }

        private static NamedDay freedomAndDemocracyDay;
        public static NamedDay FreedomAndDemocracyAndStudentsDay
        {
            get
            {
                if (freedomAndDemocracyDay == null)
                {
                    freedomAndDemocracyDay = new NamedDay("Struggle for Freedom and Democracy Day and International Students' Day", new FixedDayResolver(11, 17));
                }
                return freedomAndDemocracyDay;
            }
        }

        private static NamedDay christmasEve;
        public static NamedDay ChristmasEve
        {
            get
            {
                if (christmasEve == null)
                {
                    christmasEve = new NamedDay("Christmas Eve", new FixedDayResolver(12, 24));
                }
                return christmasEve;
            }
        }

        private static NamedDay firstChristmasDay;
        public static NamedDay FirstChristmasDay
        {
            get
            {
                if (firstChristmasDay == null)
                {
                    firstChristmasDay = new NamedDay("1st Christmas Day", new FixedDayResolver(12, 25));
                }
                return firstChristmasDay;
            }
        }

        private static NamedDay secondChristmasDay;
        public static NamedDay SecondChristmasDay
        {
            get
            {
                if (secondChristmasDay == null)
                {
                    secondChristmasDay = new NamedDay("2nd Christmas Day", new FixedDayResolver(12, 26));
                }
                return secondChristmasDay;
            }
        }
    }
}
