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
    public class KRHolidaysTests
    {
        [Test]
        public void can_get_strateryies()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("ko-KR");
            var holidaysStrategy = dateTimeCulture.LocateHolidayStrategy(dateTimeCulture.Name, null);
            Assert.AreEqual(typeof(KO_KRHolidayStrategy), holidaysStrategy.GetType());
            var workingDaysStrategy = dateTimeCulture.LocateWorkingDayOfWeekStrategy(dateTimeCulture.Name, null);
            Assert.AreEqual(typeof(DefaultWorkingDayOfWeekStrategy), workingDaysStrategy.GetType());
        }

        [Test]
        public void holiday_days_span()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("ko-KR");
            var holiday = KO_KRHolidayStrategy.Seolnal;
            var startDay = holiday.GetInstance(2015);

            //Seol 2015
            DateTime day = new DateTime(2015, 2, 18);
            do
            {
                Assert.IsFalse(dateTimeCulture.IsWorkingDay(day), day.ToString() + " shouldn't be a working day");
                day = day.AddDays(1);
            } while (day <= new DateTime(2015, 2, 20));

            //Seol 2016 (with substitute holiday)
            day = new DateTime(2016, 2, 7);
            do
            {
                Assert.IsFalse(dateTimeCulture.IsWorkingDay(day), day.ToString() + " shouldn't be a working day");
                day = day.AddDays(1);
            } while (day <= new DateTime(2015, 2, 10));

            //Chuseok 2015 (with substitute holiday)
            day = new DateTime(2015, 9, 26);
            do
            {
                Assert.IsFalse(dateTimeCulture.IsWorkingDay(day), day.ToString() + " shouldn't be a working day");
                day = day.AddDays(1);
            } while (day <= new DateTime(2015, 9, 29));
        }

        [Test]
        public void can_identify_Seolnal()
        {
            var holiday = KO_KRHolidayStrategy.Seolnal;
            var dateOnGregorian = new DateTime(2015, 2, 19);
            TestHoliday(holiday, dateOnGregorian);
        }

        [Test]
        public void can_identify_SeokgaTansilil()
        {
            var holiday = KO_KRHolidayStrategy.SeokgaTansinil;
            var dateOnGregorian = new DateTime(2015, 5, 25);
            TestHoliday(holiday, dateOnGregorian);
        }

        [Test]
        public void can_identify_Chuseok()
        {
            var holiday = KO_KRHolidayStrategy.Chuseok;
            var dateOnGregorian = new DateTime(2015, 9, 27);
            TestHoliday(holiday, dateOnGregorian);
        }

        private void TestHoliday(Holiday holiday, DateTime dateOnGregorian)
        {
            var holidayInstance = holiday.GetInstance(dateOnGregorian.Year);
            Assert.IsTrue(holidayInstance.HasValue);
            Assert.AreEqual(dateOnGregorian, holidayInstance.Value);
            Assert.IsTrue(holiday.IsInstanceOf(dateOnGregorian));
        }
    }
}