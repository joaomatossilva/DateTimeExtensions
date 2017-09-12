using System;
using NUnit.Framework;
using DateTimeExtensions.WorkingDays;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class EnUsHolidaysTests
    {
        private readonly WorkingDayCultureInfo workingDayCultureInfo = new WorkingDayCultureInfo("en-US");

        [Test]
        public void NewYearsDay_FallsOnSaturday_ExpectFridayHoliday()
        {
            var dateOnGregorian = new DateTime(2004, 12, 31);
            AssertIsHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2010, 12, 31);
            AssertIsHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2021, 12, 31);
            AssertIsHoliday(workingDayCultureInfo, dateOnGregorian);
        }

        [Test]
        public void NewYearsDay_FallsNotOnWeekend_Expect31stNotHoliday()
        {
            var dateOnGregorian = new DateTime(2008, 12, 31);
            AssertIsNotHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2011, 12, 31);
            AssertIsNotHoliday(workingDayCultureInfo, dateOnGregorian);
        }

        private void AssertIsHoliday(IWorkingDayCultureInfo workingDayCultureInfo, DateTime dateOnGregorian)
        {
            var isHoliday = workingDayCultureInfo.IsHoliday(dateOnGregorian);
            Assert.IsTrue(isHoliday);
        }

        private void AssertIsNotHoliday(IWorkingDayCultureInfo workingDayCultureInfo, DateTime dateOnGregorian)
        {
            var isHoliday = workingDayCultureInfo.IsHoliday(dateOnGregorian);
            Assert.IsFalse(isHoliday);
        }
    }
}
