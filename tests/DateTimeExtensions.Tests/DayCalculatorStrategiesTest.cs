using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class DayCalculatorStrategiesTest
    {
        [Test]
        public void nth_day_of_the_week()
        {
            var firstDayInMonth = new NthDayOfWeekInMonthDayStrategy(1, DayOfWeek.Sunday, 1,
                CountDirection.FromFirst);
            Assert.AreEqual(new DateTime(2012, 1, 1), firstDayInMonth.GetInstance(2012));

            var eigththDayInMonth = new NthDayOfWeekInMonthDayStrategy(2, DayOfWeek.Sunday, 1,
                CountDirection.FromFirst);
            Assert.AreEqual(new DateTime(2012, 1, 8), eigththDayInMonth.GetInstance(2012));


            var lastDayInMonth = new NthDayOfWeekInMonthDayStrategy(1, DayOfWeek.Tuesday, 1,
                CountDirection.FromLast);
            Assert.AreEqual(new DateTime(2012, 1, 31), lastDayInMonth.GetInstance(2012));


            var twentyfourthDayInMonth = new NthDayOfWeekInMonthDayStrategy(2, DayOfWeek.Tuesday, 1,
                CountDirection.FromLast);
            Assert.AreEqual(new DateTime(2012, 1, 24), twentyfourthDayInMonth.GetInstance(2012));
        }

        [Test]
        public void easter()
        {
            var easterHoliday = EasterDayStrategy.Instance;
            Assert.AreEqual(new DateTime(2012, 4, 8), easterHoliday.GetInstance(2012));

            var esterPositiveOffsetHoliday = new NthDayAfterDayStrategy(5, easterHoliday);
            Assert.AreEqual(new DateTime(2012, 4, 13), esterPositiveOffsetHoliday.GetInstance(2012));

            var esterNegativeOffsetHoliday = new NthDayAfterDayStrategy(-5, easterHoliday);
            Assert.AreEqual(new DateTime(2012, 4, 3), esterNegativeOffsetHoliday.GetInstance(2012));
        }

        [Test]
        public void fixedHolidays()
        {
            var fixedHoliday = new FixedDayStrategy(new DayInYear(2, 15));
            Assert.AreEqual(new DateTime(2012, 2, 15), fixedHoliday.GetInstance(2012));

            var fixedHoliday2 = new FixedDayStrategy(2, 16);
            Assert.AreEqual(new DateTime(2012, 2, 16), fixedHoliday2.GetInstance(2012));
        }
    }
}