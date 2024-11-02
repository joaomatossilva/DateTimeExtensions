using System;

using DateTimeExtensions.NaturalText;

using NUnit.Framework;

#pragma warning disable NUnit2005

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class UK_UANaturalTimeTests
    {
        private NaturalTextCultureInfo ua_ci = new NaturalTextCultureInfo("uk-UA");
        private DateTime fromTime = new DateTime(2024, 5, 8, 9, 41, 0);

        [Test]
        public void can_tranlate_to_natural_text()
        {
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, false, ua_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 години", naturalText);
        }

        [Test]
        public void can_tranlate_to_natural_text_rounded()
        {
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, true, ua_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("3 години", naturalText);
        }

        [Test]
        public void can_tranlate_to_exact_natural_text_full()
        {
            var toTime = fromTime
                .AddSeconds(6)
                .AddMinutes(5)
                .AddHours(4)
                .AddDays(3)
                .AddMonths(2)
                .AddYears(2);

            var naturalText = fromTime.ToExactNaturalText(toTime, ua_ci);

            Assert.NotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 роки, 2 місяці, 3 дні, 4 години, 5 хвилини, 6 секунди", naturalText);
        }

        [Test]
        public void can_pluralize_years()
        {
            var toTime_plural = fromTime.AddYears(2);
            var toTime_single = fromTime.AddYears(1);

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, ua_ci);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, ua_ci);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("2 роки", naturalText_plural);
            Assert.AreEqual("1 рік", naturalText_single);
        }

        [Test]
        public void can_pluralize_months()
        {
            var toTime_plural = fromTime.AddMonths(2);
            var toTime_single = fromTime.AddMonths(1);

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, ua_ci);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, ua_ci);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("2 місяці", naturalText_plural);
            Assert.AreEqual("1 місяць", naturalText_single);
        }
    }
}