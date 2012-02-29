using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class HolidaysTest
    {
        [Test]
        public void nth_day_of_the_week()
        {
            var firstDayInMonth = new NthDayOfWeekInMonthHoliday("test1", 1, DayOfWeek.Sunday, 1, CountDirection.FromFirst);
            Assert.AreEqual(new DateTime(2012, 1, 1), firstDayInMonth.GetInstance(2012));

            var eigththDayInMonth = new NthDayOfWeekInMonthHoliday("test2", 2, DayOfWeek.Sunday, 1, CountDirection.FromFirst);
            Assert.AreEqual(new DateTime(2012, 1, 8), eigththDayInMonth.GetInstance(2012));


            var lastDayInMonth = new NthDayOfWeekInMonthHoliday("test3", 1, DayOfWeek.Tuesday, 1, CountDirection.FromLast);
            Assert.AreEqual(new DateTime(2012, 1, 31), lastDayInMonth.GetInstance(2012));


            var twentyfourthDayInMonth = new NthDayOfWeekInMonthHoliday("test4", 2, DayOfWeek.Tuesday, 1, CountDirection.FromLast);
            Assert.AreEqual(new DateTime(2012, 1, 24), twentyfourthDayInMonth.GetInstance(2012));
        }
    }
}
