using NUnit.Framework;
using System;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        public void IsWithinBusinessHours_ShouldReturnTrue_WhenWithinHours()
        {
            var dateTime = new DateTime(2024, 8, 5, 10, 0, 0); // 10:00 AM
            var startTime = new TimeSpan(9, 0, 0);
            var endTime = new TimeSpan(17, 0, 0);

            var result = dateTime.IsWithinBusinessHours(startTime, endTime);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsWithinBusinessHours_ShouldReturnFalse_WhenOutsideHours()
        {
            var dateTime = new DateTime(2024, 8, 5, 18, 0, 0); // 6:00 PM
            var startTime = new TimeSpan(9, 0, 0);
            var endTime = new TimeSpan(17, 0, 0);

            var result = dateTime.IsWithinBusinessHours(startTime, endTime);

            Assert.IsFalse(result);
        }
    }
}
