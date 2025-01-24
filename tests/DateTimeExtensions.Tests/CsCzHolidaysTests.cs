using DateTimeExtensions.WorkingDays;
using NUnit.Framework;
using System;
using System.Linq;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class CsCzHolidaysTests
    {
        private WorkingDayCultureInfo dateTimeCulture = new WorkingDayCultureInfo("cs-CZ");

        [Test]
        public void Czechia_Has_13_HolidayDays()
        {
            Assert.That(dateTimeCulture.Holidays.Count(), Is.EqualTo(13));
        }

        [Test]
        [TestCase(2016)]
        [TestCase(2025)]
        [TestCase(2031)]
        public void Good_Friday_Is_A_Holiday_From_2016(int year)
        {
            DateTime goodFriday = ChristianHolidays.GoodFriday.GetInstance(year).Value;
            Assert.That(goodFriday.IsHoliday(), Is.True);
        }

        [Test]
        [TestCase(2015)]
        [TestCase(2003)]
        [TestCase(1996)]
        public void Good_Friday_Is_Not_A_Holiday_Before_2016(int year)
        {
            DateTime goodFriday = ChristianHolidays.GoodFriday.GetInstance(year).Value;
            Assert.That(goodFriday.IsWorkingDay(), Is.True);
        }

        [Test]
        [TestCase(2015, 1, 1)]
        [TestCase(2003, 5, 1)]
        [TestCase(1996, 5, 8)]
        [TestCase(1998, 7, 5)]
        [TestCase(1994, 7, 6)]
        [TestCase(1996, 9, 28)]
        [TestCase(2005, 10, 28)]
        [TestCase(2028, 11, 17)]
        [TestCase(2001, 12, 24)]
        [TestCase(2011, 12, 25)]
        [TestCase(2025, 12, 26)]
        public void Dates_Are_Correctly_Identified_As_Specific_Czech_Holidays(int year, int month, int day)
        {
            DateTime holiday = new(year, month, day);
            Assert.That(holiday.IsHoliday(), Is.True);
        }
    }
}
