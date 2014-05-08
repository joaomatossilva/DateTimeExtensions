using System;
using NUnit.Framework;
using System.Globalization;
using System.Threading;
using DateTimeExtensions;
using DateTimeExtensions.WorkingDays;
using System.Collections.Generic;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    internal class ChristianHolidaysTests
    {
        private IEnumerable<int> years;

        private IDictionary<int, DateTime> easterDates;

        [TestFixtureSetUp]
        public void SetUpYears()
        {
            years = new int[] {1800, 1899, 1900, 1999, 2000, 2025, 2035, 2067, 2099};
            easterDates = new Dictionary<int, DateTime>
            {
                {1800, new DateTime(1800, 4, 13)},
                {1899, new DateTime(1899, 4, 2)},
                {1900, new DateTime(1900, 4, 15)},
                {1999, new DateTime(1999, 4, 4)},
                {2000, new DateTime(2000, 4, 23)},
                {2025, new DateTime(2025, 4, 20)},
                {2035, new DateTime(2035, 3, 25)},
                {2067, new DateTime(2067, 4, 3)},
                {2099, new DateTime(2099, 4, 12)}
            };
        }

        [Test]
        public void can_calculate_easter()
        {
            foreach (int year in years)
            {
                var easterHoliday = ChristianHolidays.Easter;
                var easter = easterHoliday.GetInstance(year);
                Assert.IsTrue(easter.HasValue);
                Assert.AreEqual(DayOfWeek.Sunday, easter.Value.DayOfWeek);
                Assert.AreEqual(easterDates[year], easter.Value);
            }
        }

        [Test]
        public void pentecost_is_49_days_after_easter()
        {
            foreach (int year in years)
            {
                var easter = easterDates[year];

                var pentecostHoliday = ChristianHolidays.Pentecost;
                var pentecost = pentecostHoliday.GetInstance(year);
                Assert.IsTrue(pentecost.HasValue);
                Assert.AreEqual(DayOfWeek.Sunday, pentecost.Value.DayOfWeek);

                //source: http://en.wikipedia.org/wiki/Pentecost
                // According to Christian tradition, Pentecost is always seven weeks after Easter Sunday; that is to say, 50 days after Easter (inclusive of Easter Day)
                Assert.AreEqual(easter.AddDays(49), pentecost.Value);
            }
        }

        [Test]
        public void ascencion_is_39_days_after_easter()
        {
            foreach (int year in years)
            {
                var easter = easterDates[year];

                var ascencionHoliday = ChristianHolidays.Ascension;
                var ascencion = ascencionHoliday.GetInstance(year);
                Assert.IsTrue(ascencion.HasValue);
                Assert.AreEqual(DayOfWeek.Thursday, ascencion.Value.DayOfWeek);

                //source: http://en.wikipedia.org/wiki/Ascension_Day
                // Ascension Day is traditionally celebrated on a Thursday, the fortieth day of Easter
                // again, easter day is included
                Assert.AreEqual(easter.AddDays(39), ascencion.Value);
            }
        }

        [Test]
        public void palmSunday_is_7_days_before_easter()
        {
            foreach (int year in years)
            {
                var easter = easterDates[year];

                var palmSundayHoliday = ChristianHolidays.PalmSunday;
                var palmSunday = palmSundayHoliday.GetInstance(year);
                Assert.IsTrue(palmSunday.HasValue);
                Assert.AreEqual(DayOfWeek.Sunday, palmSunday.Value.DayOfWeek);

                //source: http://en.wikipedia.org/wiki/Palm_Sunday
                //Palm Sunday is a Christian moveable feast that falls on the Sunday before Easter
                Assert.AreEqual(easter.AddDays(-7), palmSunday.Value);
            }
        }

        [Test]
        public void carnival_is_47_days_before_easter()
        {
            foreach (int year in years)
            {
                var easter = easterDates[year];

                var carnivalHoliday = ChristianHolidays.Carnival;
                var carnival = carnivalHoliday.GetInstance(year);
                Assert.IsTrue(carnival.HasValue);
                Assert.AreEqual(DayOfWeek.Tuesday, carnival.Value.DayOfWeek);
                Assert.AreEqual(easter.AddDays(-47), carnival.Value);
            }
        }
    }
}