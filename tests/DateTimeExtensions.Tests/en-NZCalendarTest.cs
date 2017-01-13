using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;


namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class en_NZCalendarTest
    {
        [Test]
        public void NewYearsDay()
        {
            var workingDayCultureInfo = new WorkingDayCultureInfo("en-NZ");

            var dateOnGregorian = new DateTime(2013, 1, 1);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2014, 1, 1);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2015, 1, 1);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2016, 1, 1);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2017, 1, 3);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2018, 1, 1);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2019, 1, 1);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2020, 1, 1);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
        }

        [Test]
        public void DayAfterNewYearsDay()
        {
            var workingDayCultureInfo = new WorkingDayCultureInfo("en-NZ");

            var dateOnGregorian = new DateTime(2013, 1, 2);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2014, 1, 2);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2015, 1, 2);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2016, 1, 4);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2017, 1, 2);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2018, 1, 2);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2019, 1, 2);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2020, 1, 2);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
        }

        [Test]
        public void Christmas()
        {
            var workingDayCultureInfo = new WorkingDayCultureInfo("en-NZ");

            var dateOnGregorian = new DateTime(2013, 12, 25);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2014, 12, 25);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2015, 12, 25);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2016, 12, 26);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2017, 12, 25);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2018, 12, 25);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2019, 12, 25);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2020, 12, 25);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
        }

        [Test]
        public void BoxingDay()
        {
            var workingDayCultureInfo = new WorkingDayCultureInfo("en-NZ");

            var dateOnGregorian = new DateTime(2013, 12, 26);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2014, 12, 26);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2015, 12, 28);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2016, 12, 26);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2017, 12, 26);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2018, 12, 26);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2019, 12, 26);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
            dateOnGregorian = new DateTime(2020, 12, 28);
            TestHoliday(workingDayCultureInfo, dateOnGregorian);
        }


        private void TestHoliday(IWorkingDayCultureInfo workingDayCultureInfo, DateTime dateOnGregorian)
        {
            var isHoliday = workingDayCultureInfo.IsHoliday(dateOnGregorian);
            Assert.IsTrue(isHoliday);
        }
    }
}