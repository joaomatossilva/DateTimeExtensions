using System;
using NUnit.Framework;
using System.Globalization;
using DateTimeExtensions.TimeOfDay;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class TimeTests
    {
        private CultureInfo cultureInfo;

        [OneTimeSetUp]
        public void Setup()
        {
            // save the default culture
            cultureInfo = CultureInfo.CurrentCulture;

            //change the default culture to en-GB
            new CultureInfo("en-GB").SetCurrentCultureInfo();
        }

        [OneTimeTearDown]
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

        [Test]
        public void can_compare_greater_operator()
        {
            Time t1 = new(14, 25);
            Time t2 = Time.Noon;

            bool t1IsGreater = t1 > t2;

            Assert.That(t1IsGreater, Is.True);
        }

        [TestCase(12, 0, 10, 33)]
        [TestCase(13, 37, 13, 37)]
        public void can_compare_greater_or_equal_operator(int h1, int m1, int h2, int m2)
        {
            Time t1 = new(h1, m1);
            Time t2 = new(h2, m2);

            bool t1IsGreaterOrEqual = t1 >= t2;

            Assert.That(t1IsGreaterOrEqual, Is.True);
        }

        [Test]
        public void can_compare_lower_operator()
        {
            Time t1 = Time.Midnight;
            Time t2 = new(17, 25, 33);

            bool t1IsLower = t1 < t2;

            Assert.That(t1IsLower, Is.True);
        }

        [TestCase(4, 0, 17, 21)]
        [TestCase(0, 0, 0, 0)]
        public void can_compare_lower_or_equal_operator(int h1, int m1, int h2, int m2)
        {
            Time t1 = new(h1, m1);
            Time t2 = new(h2, m2);

            bool t1IsLowerOrEqual = t1 <= t2;

            Assert.That(t1IsLowerOrEqual, Is.True);
        }

        [Test]
        public void can_compare_equal_operator()
        {
            Time t1 = Time.Noon;
            Time t2 = new(12, 0);

            bool t1IsEqualTot2 = t1 == t2;

            Assert.That(t1IsEqualTot2, Is.True);
        }

        [Test]
        public void can_compare_not_equal_operator()
        {
            Time t1 = new(12, 13, 14);
            Time t2 = new(23, 59, 59);

            bool t1IsNotEqualTot2 = t1 != t2;

            Assert.That(t1IsNotEqualTot2, Is.True);
        }

        [Test]
        public void can_try_parse()
        {
            string timeString = "12:27:55";

            bool successfulParse = Time.TryParse(timeString, out Time notDefaultTime);

            bool resultingTimeIsNotDefault = notDefaultTime != default;

            Assert.Multiple(() =>
            {
                Assert.That(successfulParse, Is.True);
                Assert.That(resultingTimeIsNotDefault, Is.True);
            });
        }

        [TestCase("61:32:cherry")]
        [TestCase(null)]
        public void cant_try_parse(string s)
        {
            bool failedParse = Time.TryParse(s, out Time defaultTime) == false;

            bool resultTimeIsDefault = defaultTime == default;

            Assert.Multiple(() =>
            {
                Assert.That(failedParse, Is.True);
                Assert.That(resultTimeIsDefault, Is.True);
            });
        }
    }
}