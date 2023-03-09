using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    internal class enJMHolidaysTests
    {
        private readonly WorkingDayCultureInfo dateTimeCulture = new WorkingDayCultureInfo("en-JM");
        [Test]
        public void can_get_strateryies()
        {            
            var holidaysStrategy = dateTimeCulture.LocateHolidayStrategy(dateTimeCulture.Name, null);
            Assert.AreEqual(typeof(EN_JMHolidayStrategy), holidaysStrategy.GetType());
            //var workingDaysStrategy = dateTimeCulture.LocateWorkingDayOfWeekStrategy(dateTimeCulture.Name, null);
            //Assert.AreEqual(typeof(AR_SAWorkingDayOfWeekStrategy), workingDaysStrategy.GetType());
        }

        private void AssertIsHoliday(IWorkingDayCultureInfo dateTimeCulture, DateTime dateOnGregorian)
        {
            var isHoliday = dateTimeCulture.IsHoliday(dateOnGregorian);
            Assert.IsTrue(isHoliday);
        }

        private void AssertIsNotHoliday(IWorkingDayCultureInfo dateTimeCulture, DateTime dateOnGregorian)
        {
            var isHoliday = dateTimeCulture.IsHoliday(dateOnGregorian);
            Assert.IsFalse(isHoliday);
        }
    }
}
