using System;
using NUnit.Framework;
using DateTimeExtensions;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class BusinessHoursTests
    {
        [Test]
        public void check_is_within_regular_business_hours()
        {
            //Business hours are from 9AM to 5PM
            var startTime = new TimeSpan(9, 0, 0); // 9 AM
            var endTime = new TimeSpan(17, 0, 0); // 5 PM

            var withinHoursDate = new DateTime(2024, 11, 12, 10, 30, 0); // 10:30 AM
            Assert.IsTrue(withinHoursDate.IsWithinBusinessHours(startTime, endTime));

            var outsideHoursDate = new DateTime(2024, 11, 12, 18, 22, 0); // 6:22 PM
            Assert.IsFalse(outsideHoursDate.IsWithinBusinessHours(startTime, endTime));
        }

        [Test]
        public void check_is_within_overnight_business_hours()
        {
            //Business hours are from 9AM to 5PM
            var startTime = new TimeSpan(19, 0, 0); // 9 AM
            var endTime = new TimeSpan(5, 0, 0); // 5 PM

            var withinHoursDate = new DateTime(2024, 11, 12, 22, 0, 20); // 10:00:20 PM
            Assert.IsTrue(withinHoursDate.IsWithinBusinessHours(startTime, endTime));

            var outsideHoursDate = new DateTime(2024, 11, 12, 12, 30, 44); // 12:30:44 PM
            Assert.IsFalse(outsideHoursDate.IsWithinBusinessHours(startTime, endTime));
        }
    }
}
