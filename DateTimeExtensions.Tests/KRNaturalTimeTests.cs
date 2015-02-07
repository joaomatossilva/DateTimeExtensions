using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DateTimeExtensions.NaturalText;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class KRNaturalTimeTests
    {
        private NaturalTextCultureInfo foo_ci = new NaturalTextCultureInfo("ko-KR");

        [Test]
        public void can_tranlate_to_natural_text()
        {
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, false, foo_ci);

            Assert.IsNotNullOrEmpty(naturalText);
            Assert.AreEqual("2 시간", naturalText);
        }

        [Test]
        public void can_tranlate_to_natural_text_rounded()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, true, foo_ci);

            Assert.IsNotNullOrEmpty(naturalText);
            Assert.AreEqual("3 시간", naturalText);
        }


        [Test]
        public void can_tranlate_to_exact_natural_text()
        {
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddHours(2).AddMinutes(30);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

            Assert.IsNotNullOrEmpty(naturalText);
            Assert.AreEqual("2 시간 30 분", naturalText);
        }

        [Test]
        public void can_tranlate_to_exact_natural_text_full()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddYears(2).AddMonths(2).AddDays(3).AddHours(4).AddMinutes(5).AddSeconds(6);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

            Assert.IsNotNullOrEmpty(naturalText);
            Assert.AreEqual("2 년 2 개월 3 일 4 시간 5 분 6 초", naturalText);
        }

        [Test]
        public void are_orderless()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddYears(2).AddMonths(2).AddDays(3).AddHours(4).AddMinutes(5).AddSeconds(6);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);
            var naturalTextReverse = toTime.ToExactNaturalText(fromTime, foo_ci);

            Assert.IsNotNullOrEmpty(naturalText);
            Assert.IsNotNullOrEmpty(naturalTextReverse);
            Assert.AreEqual(naturalTextReverse, naturalText);
        }

    }
}