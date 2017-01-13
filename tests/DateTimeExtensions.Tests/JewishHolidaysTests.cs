using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DateTimeExtensions.WorkingDays;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class JewishHolidaysTests
    {
        [Test]
        public void can_identify_RoshHashanah()
        {
            var holiday = JewishHolidays.RoshHashanah;
            var dateOnGregorian = new DateTime(2012, 9, 17);
            TestHoliday(holiday, dateOnGregorian);
        }

        [Test]
        public void can_identify_RoshHashanahSecondDay()
        {
            var holiday = JewishHolidays.RoshHashanahSecondDay;
            var dateOnGregorian = new DateTime(2012, 9, 18);
            TestHoliday(holiday, dateOnGregorian);
        }

        [Test]
        public void can_identify_YomKippur()
        {
            var holiday = JewishHolidays.YomKippur;
            var dateOnGregorian = new DateTime(2012, 9, 26);
            TestHoliday(holiday, dateOnGregorian);
        }

        [Test]
        public void can_identify_Sukkot()
        {
            var holiday = JewishHolidays.Sukkot;
            var dateOnGregorian = new DateTime(2012, 10, 1);
            TestHoliday(holiday, dateOnGregorian);
        }

        [Test]
        public void can_identify_ShminiAtzeret()
        {
            var holiday = JewishHolidays.ShminiAtzeret;
            var dateOnGregorian = new DateTime(2012, 10, 8);
            TestHoliday(holiday, dateOnGregorian);
        }

        [Test]
        public void can_identify_ShminiTorah()
        {
            var holiday = JewishHolidays.ShminiTorah;
            var dateOnGregorian = new DateTime(2012, 10, 9);
            TestHoliday(holiday, dateOnGregorian);
        }

        [Test]
        public void can_identify_Pesach()
        {
            var holiday = JewishHolidays.Pesach;
            var dateOnGregorian = new DateTime(2012, 4, 7);
            TestHoliday(holiday, dateOnGregorian);
        }

        [Test]
        public void can_identify_ShviiShelPesach()
        {
            var holiday = JewishHolidays.ShviiShelPesach;
            var dateOnGregorian = new DateTime(2012, 4, 13);
            TestHoliday(holiday, dateOnGregorian);
        }

        [Test]
        public void can_identify_Shavuot()
        {
            var holiday = JewishHolidays.Shavuot;
            var dateOnGregorian = new DateTime(2012, 5, 27);
            TestHoliday(holiday, dateOnGregorian);
        }

        [Test]
        public void can_identify_TuBishvat()
        {
            var holiday = JewishHolidays.TuBishvat;
            var dateOnGregorian = new DateTime(2012, 2, 8);
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