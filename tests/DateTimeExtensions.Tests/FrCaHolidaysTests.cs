using System;
using System.Linq;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class FrCaHolidaysTests
    {
        [Test]
        public void can_get_stratery()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("fr-CA");
            var strategy = dateTimeCulture.LocateHolidayStrategy(dateTimeCulture.Name, null);
            Assert.AreEqual(typeof (FR_CAHolidayStrategy), strategy.GetType());
        }

        [Test]
        public void assert_holidays_count()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("fr-CA");
            var holidays = dateTimeCulture.Holidays;
            Assert.AreEqual(8, holidays.Count());
        }

        [Test]
        public void assert_holidays_on_sunday_observed_on_monday()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("fr-CA");
            // 01-07-2012 Canada Day on a Sunday
            var mondayAfterCanadaDay = new DateTime(2012, 07, 02);
            Assert.AreEqual(DayOfWeek.Monday, mondayAfterCanadaDay.DayOfWeek);
            Assert.IsFalse(mondayAfterCanadaDay.IsWorkingDay(dateTimeCulture));
        }

        [Test]
        public void assert_holidays_on_saturday_observed_on_friday()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("fr-CA");
            // 25-12-2010 Christmas on a Saturday
            var fridayBeforeCanadaDay = new DateTime(2010, 12, 24);
            Assert.AreEqual(DayOfWeek.Friday, fridayBeforeCanadaDay.DayOfWeek);
            Assert.IsFalse(fridayBeforeCanadaDay.IsWorkingDay(dateTimeCulture));
        }

        [Test]
        public void CanWorkOn2016()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("fr-CA");
            var holidays = dateTimeCulture.GetHolidaysOfYear(2016);
            Assert.IsTrue(holidays.Any());
        }
    }
}