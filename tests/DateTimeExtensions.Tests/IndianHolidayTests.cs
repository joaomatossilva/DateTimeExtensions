using System;
using System.Linq;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class IndianHolidayTests
    {
        [Test]
        public void IndependenceDayTest()
        {
            var independenceDayHoliday = IndianHolidayStrategy.IndependenceDay;

            var observanceIn2015 = independenceDayHoliday.GetInstance(2015);
            Assert.AreEqual(new DateTime(2015, 8, 15), observanceIn2015);

            var observanceIn2016 = independenceDayHoliday.GetInstance(2016);
            Assert.AreEqual(new DateTime(2016, 8, 15), observanceIn2016);

            var observanceIn2017 = independenceDayHoliday.GetInstance(2017);
            Assert.AreEqual(new DateTime(2017, 8, 15), observanceIn2017);
        }

        public void CanGetIndianHolidaysListIn2017()
        {
            var cultureInfo = new WorkingDayCultureInfo("en-IN");
            Assert.IsNotNull(cultureInfo);
            var holidays = cultureInfo.GetHolidaysOfYear(2017);
            Assert.AreEqual(5, holidays.Count());
        }
    }
}