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

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 시간", naturalText);
        }

        [Test]
        public void can_tranlate_to_natural_text_rounded()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, true, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("3 시간", naturalText);
        }


        [Test]
        public void can_tranlate_to_exact_natural_text()
        {
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddHours(2).AddMinutes(30);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 시간 30 분", naturalText);
        }

        [Test]
        public void can_tranlate_to_exact_natural_text_full()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddSeconds(6).AddMinutes(5).AddHours(4).AddDays(3).AddMonths(2).AddYears(2);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);

            var result = string.Empty;
            var dateDiff = fromTime.GetDiff(toTime);
            if (dateDiff.Years > 0)
                result += "2 년";
            if (dateDiff.Months > 0)
                result += " 2 개월";
            if (dateDiff.Days > 0)
                result += " 3 일";
            if (dateDiff.Hours > 0)
                result += " 4 시간";
            if (dateDiff.Minutes > 0)
                result += " 5 분";
            if (dateDiff.Seconds > 0)
                result += " 6 초";
            Assert.AreEqual(result, naturalText);
        }

        [Test]
        public void are_orderless()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddSeconds(6).AddMinutes(5).AddHours(4).AddDays(3).AddMonths(2).AddYears(2);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);
            var naturalTextReverse = toTime.ToExactNaturalText(fromTime, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.IsNotNull(naturalTextReverse);
            Assert.IsNotEmpty(naturalTextReverse);
            Assert.AreEqual(naturalTextReverse, naturalText);
        }

    }
}