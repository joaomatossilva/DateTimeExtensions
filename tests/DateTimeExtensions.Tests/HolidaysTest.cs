using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions.WorkingDays;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class HolidaysTest
    {
        [Test]
        public void nth_day_of_the_week()
        {
            var firstDayInMonth = new NthDayOfWeekInMonthHoliday("test1", 1, DayOfWeek.Sunday, 1,
                CountDirection.FromFirst);
            Assert.AreEqual(new DateTime(2012, 1, 1), firstDayInMonth.GetInstance(2012));

            var eigththDayInMonth = new NthDayOfWeekInMonthHoliday("test2", 2, DayOfWeek.Sunday, 1,
                CountDirection.FromFirst);
            Assert.AreEqual(new DateTime(2012, 1, 8), eigththDayInMonth.GetInstance(2012));


            var lastDayInMonth = new NthDayOfWeekInMonthHoliday("test3", 1, DayOfWeek.Tuesday, 1,
                CountDirection.FromLast);
            Assert.AreEqual(new DateTime(2012, 1, 31), lastDayInMonth.GetInstance(2012));


            var twentyfourthDayInMonth = new NthDayOfWeekInMonthHoliday("test4", 2, DayOfWeek.Tuesday, 1,
                CountDirection.FromLast);
            Assert.AreEqual(new DateTime(2012, 1, 24), twentyfourthDayInMonth.GetInstance(2012));
        }

        [Test]
        public void easter()
        {
            var easterHoliday = new EasterBasedHoliday("easter1", 0);
            Assert.AreEqual(new DateTime(2012, 4, 8), easterHoliday.GetInstance(2012));

            var esterPositiveOffsetHoliday = new EasterBasedHoliday("easter2", 5);
            Assert.AreEqual(new DateTime(2012, 4, 13), esterPositiveOffsetHoliday.GetInstance(2012));

            var esterNegativeOffsetHoliday = new EasterBasedHoliday("easter3", -5);
            Assert.AreEqual(new DateTime(2012, 4, 3), esterNegativeOffsetHoliday.GetInstance(2012));
        }

        [Test]
        public void fixedHolidays()
        {
            var fixedHoliday = new FixedHoliday("fixed1", new DayInYear(2, 15));
            Assert.AreEqual(new DateTime(2012, 2, 15), fixedHoliday.GetInstance(2012));

            var fixedHoliday2 = new FixedHoliday("fixed1", 2, 16);
            Assert.AreEqual(new DateTime(2012, 2, 16), fixedHoliday2.GetInstance(2012));
        }
    }
}