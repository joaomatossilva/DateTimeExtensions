using DateTimeExtensions.WorkingDays;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class BEHolidaysTests
    {
        private readonly WorkingDayCultureInfo dateTimeCulture = new WorkingDayCultureInfo("nl-BE");

        [Test]
        public void Belgium_has_12_main_holidays()
        {
            var holidays = dateTimeCulture.Holidays;
            Assert.AreEqual(12, holidays.Count());
        }

        [Test]
        public void Easter2017_is_16_april()
        {
            Assert.That(new DateTime(2017,4,16).IsHoliday(dateTimeCulture));
        }

        [Test]
        public void Easter2018_is_1_april()
        {
            Assert.That(new DateTime(2018 ,4, 1).IsHoliday(dateTimeCulture));
        }
    }
}
