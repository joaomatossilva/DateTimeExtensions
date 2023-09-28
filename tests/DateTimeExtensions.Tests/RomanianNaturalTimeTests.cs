using System;
using DateTimeExtensions.NaturalText;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]

    public class RomanianNaturalTimeTests
    {
        private NaturalTextCultureInfo ro_ci = new NaturalTextCultureInfo("ro-RO");
        private DateTime fromTime = new DateTime(2016, 6, 21, 10, 28, 0);

        [Test]
        public void can_tranlate_to_natural_text()
        {
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, false, ro_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 ore", naturalText);
        }

        [Test]
        public void can_tranlate_to_natural_text_rounded()
        {
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, true, ro_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("3 ore", naturalText);
        }

        [Test]
        public void can_tranlate_to_exact_natural_text_full()
        {
            var toTime = fromTime.AddSeconds(6).AddMinutes(5).AddHours(4).AddDays(3).AddMonths(2).AddYears(2);

            var naturalText = fromTime.ToExactNaturalText(toTime, ro_ci);

            Assert.NotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 ani, 2 luni, 3 zile, 4 ore, 5 minute, 6 secunde", naturalText);
        }


        [Test]
        public void can_pluralize_years()
        {
            var toTime_plural = fromTime.AddYears(2);
            var toTime_single = fromTime.AddYears(1);

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, ro_ci);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, ro_ci);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("2 ani", naturalText_plural);
            Assert.AreEqual("1 an", naturalText_single);
        }

        [Test]
        public void can_pluralize_months()
        {
            var toTime_plural = fromTime.AddMonths(2);
            var toTime_single = fromTime.AddMonths(1);

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, ro_ci);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, ro_ci);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("2 luni", naturalText_plural);
            Assert.AreEqual("1 luna", naturalText_single);
        }

    }
}