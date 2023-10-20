using DateTimeExtensions.WorkingDays;
using NUnit.Framework;
using System;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    internal class enJMHolidaysTests
    {
        private readonly WorkingDayCultureInfo dateTimeCulture = new WorkingDayCultureInfo("en-JM", "Jamaica");

        [Test]
        public void BoxingDay_2022_is_observed_tuesday()
        {
            //Holiday's falling on Sunday are observed on the following monday.
            //boxing day was the 26th, a monday, which would result in a clash, hence the clashing holiday would be observed on the following day (Tuesday)
            var boxingDay = new DateTime(2022, 12, 26);
            var boxingDayObserved = boxingDay.AddDays(1);
            Assert.IsTrue(boxingDayObserved.IsHoliday(dateTimeCulture));
        }

        [Test]
        public void Christmas_2022_sunday_is_observed_monday()
        {
            // Holiday's falling on Sunday are observed on the following monday.
            // Christmas on a sunday should not be a holiday.
            var christmasSunday = new DateTime(2022, 12, 25);
            var christmasObserved = christmasSunday.AddDays(1);
            Assert.IsTrue(christmasObserved.IsHoliday(dateTimeCulture));
        }

        [Test]
        public void Christmas_sunday_not_a_holiday()
        {
            // Holiday's falling on Sunday are observed on the following monday.
            // Christmas on a sunday should not be a holiday.
            var christmasSunday = new DateTime(2022, 12, 25);
            Assert.IsFalse(christmasSunday.IsHoliday(dateTimeCulture));
        }
    }
}