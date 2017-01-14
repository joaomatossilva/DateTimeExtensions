using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using DateTimeExtensions;
using DateTimeExtensions.TimeOfDay;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class TimeTests
    {
        private CultureInfo cultureInfo;

        [TestFixtureSetUp]
        public void Setup()
        {
            // save the default culture
            cultureInfo = CultureInfo.CurrentCulture;

            //change the default culture to en-GB
            new CultureInfo("en-GB").SetCurrentCultureInfo();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            //restore the default culture
            cultureInfo.SetCurrentCultureInfo();
        }

        [Test]
        public void can_format_24hour_time()
        {
            var compareTime = new Time(13, 59, 58, "HH:mm:ss");
            var time = compareTime.ToString();
            string timeValue = "13:59:58";
            Assert.AreEqual(time, timeValue);
        }

        [Test]
        public void can_format_12hour_time()
        {
            var compareTime = new Time(13, 59, 58, "h:mm:ss tt");
            var time = compareTime.ToString();
            string timeValue = "1:59:58 " + CultureInfo.CurrentCulture.DateTimeFormat.PMDesignator;
            Assert.AreEqual(time, timeValue);
        }

        [Test]
        public void can_parse_time()
        {
            var compareTime = new Time(3, 59, 58);
            string timeValue = "3:59:58";
            var time = timeValue.ToTimeOfDay();
            Assert.AreEqual(time, compareTime);
        }

        [Test]
        public void can_parse_time_leading_zero()
        {
            var compareTime = new Time(3, 59, 58);
            string timeValue = "03:59:58";
            var time = timeValue.ToTimeOfDay();
            Assert.AreEqual(time, compareTime);
        }

        [Test]
        public void can_parse_time_two_digit_hours()
        {
            var compareTime = new Time(13, 59);
            string timeValue = "13:59:00";
            var time = timeValue.ToTimeOfDay();
            Assert.AreEqual(time, compareTime);
        }

        [Test]
        public void can_extract_time_from_datetime()
        {
            var compareTime = new Time(13, 59);
            var dateTime = new DateTime(2011, 3, 5, 13, 59, 0);
            var time = dateTime.TimeOfTheDay();
            Assert.AreEqual(time, compareTime);
        }

        [Test]
        public void can_compare_times()
        {
            //interval is from 10:15 -> 14:00
            var startTime = new Time(10, 15);
            var endTime = new Time(14);

            var beforeDate = new DateTime(2011, 5, 3, 9, 30, 0);
            var middleDate = new DateTime(2011, 6, 10, 12, 30, 0);
            var aftereDate = new DateTime(2012, 10, 11, 15, 30, 0);

            Assert.IsTrue(beforeDate.IsBefore(startTime));
            Assert.IsTrue(middleDate.IsBetween(startTime, endTime));
            Assert.IsTrue(aftereDate.IsAfter(endTime));

            Assert.IsFalse(aftereDate.IsBefore(startTime));
            Assert.IsFalse(middleDate.IsBetween(endTime, startTime));
            Assert.IsFalse(beforeDate.IsAfter(endTime));
        }

        [Test]
        public void can_compare_inverted_between()
        {
            //interval is from 00:00 -> 10:15 and 14:00 -> 23:59:58
            var startTime = new Time(14);
            var endTime = new Time(10, 15);

            var beforeDate = new DateTime(2011, 5, 3, 9, 30, 0);
            var middleDate = new DateTime(2011, 6, 10, 12, 30, 0);
            var aftereDate = new DateTime(2012, 10, 11, 15, 30, 0);

            Assert.IsFalse(middleDate.IsBetween(startTime, endTime));
            Assert.IsTrue(middleDate.IsBetween(endTime, startTime));
            Assert.IsTrue(beforeDate.IsBetween(startTime, endTime));
            Assert.IsTrue(aftereDate.IsBetween(startTime, endTime));
        }
    }
}