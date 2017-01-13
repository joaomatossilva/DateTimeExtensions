using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DateTimeExtensions.NaturalText;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class GenericNaturalTimeTests
    {
        private NaturalTextCultureInfo foo_ci = new NaturalTextCultureInfo("foo");

        [Test]
        public void can_tranlate_to_natural_text()
        {
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, false, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 hours", naturalText);
        }

        [Test]
        public void can_tranlate_to_natural_text_rounded()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, true, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("3 hours", naturalText);
        }


        [Test]
        public void can_tranlate_to_exact_natural_text()
        {
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddHours(2).AddMinutes(30);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 hours, 30 minutes", naturalText);
        }

        [Test]
        public void can_tranlate_to_exact_natural_text_full()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddSeconds(6).AddMinutes(5).AddHours(4).AddDays(3).AddMonths(2).AddYears(2);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 years, 2 months, 3 days, 4 hours, 5 minutes, 6 seconds", naturalText);
        }

        [Test]
        public void can_tranlate_to_exact_natural_text_full_on_february_with_leap()
        {
            var fromTime = new DateTime(2012, 2, 27, 23, 59, 58);
            var toTime = fromTime.AddDays(3).AddHours(4).AddMinutes(5).AddSeconds(6);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("3 days, 4 hours, 5 minutes, 6 seconds", naturalText);
        }

        [Test]
        public void can_tranlate_to_exact_natural_text_full_on_february_without_leap()
        {
            var fromTime = new DateTime(2010, 2, 27, 23, 59, 58);
            var toTime = fromTime.AddDays(3).AddHours(4).AddMinutes(5).AddSeconds(6);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("3 days, 4 hours, 5 minutes, 6 seconds", naturalText);
        }

        [Test]
        public void can_tranlate_to_exact_natural_text_full_on_march()
        {
            var fromTime = new DateTime(2010, 3, 29, 23, 59, 58);
            var toTime = fromTime.AddDays(3).AddHours(4).AddMinutes(5).AddSeconds(6);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("3 days, 4 hours, 5 minutes, 6 seconds", naturalText);
        }

        [Test]
        public void can_tranlate_to_exact_natural_text_full_on_april()
        {
            var fromTime = new DateTime(2010, 4, 29, 23, 59, 58);
            var toTime = fromTime.AddSeconds(6).AddMinutes(5).AddHours(4).AddDays(3).AddMonths(2).AddYears(2);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 years, 2 months, 3 days, 4 hours, 5 minutes, 6 seconds", naturalText);
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


        [Test]
        public void can_pluralize_years()
        {
            var fromTime = DateTime.Now;
            var toTime_plural = fromTime.AddYears(2);
            var toTime_single = fromTime.AddYears(1);

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, foo_ci);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, foo_ci);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("2 years", naturalText_plural);
            Assert.AreEqual("1 year", naturalText_single);
        }

        [Test]
        public void can_pluralize_months()
        {
            var fromTime = DateTime.Now;
            var toTime_plural = fromTime.AddMonths(2);
            var toTime_single = fromTime.AddMonths(1);

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, foo_ci);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, foo_ci);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("2 months", naturalText_plural);
            Assert.AreEqual("1 month", naturalText_single);
        }

        [Test]
        public void can_pluralize()
        {
            var fromTime = DateTime.Now;
            var toTime_plural = fromTime.AddDays(2).AddHours(2).AddMinutes(2).AddSeconds(2);
            var toTime_single = fromTime.AddDays(1).AddHours(1).AddMinutes(1).AddSeconds(1);

            var naturalText_plural = fromTime.ToExactNaturalText(toTime_plural, foo_ci);
            var naturalText_single = fromTime.ToExactNaturalText(toTime_single, foo_ci);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("2 days, 2 hours, 2 minutes, 2 seconds", naturalText_plural);
            Assert.AreEqual("1 day, 1 hour, 1 minute, 1 second", naturalText_single);
        }


        [Test]
        public void can_round()
        {
            var fromTime = DateTime.Now;
            var overflowYear = fromTime.AddYears(1).AddMonths(8);
            var noOverflowYear = fromTime.AddYears(1).AddMonths(2);
            Assert.AreEqual("2 years", fromTime.ToNaturalText(overflowYear, foo_ci));
            Assert.AreEqual("1 year", fromTime.ToNaturalText(noOverflowYear, foo_ci));

            var overflowMonth = fromTime.AddMonths(1).AddDays(20);
            var noOverflowMonth = fromTime.AddMonths(1).AddDays(10);
            Assert.AreEqual("2 months", fromTime.ToNaturalText(overflowMonth, foo_ci));
            Assert.AreEqual("1 month", fromTime.ToNaturalText(noOverflowMonth, foo_ci));

            var overflowDays = fromTime.AddDays(1).AddHours(20);
            var noOverflowDays = fromTime.AddDays(1).AddHours(10);
            Assert.AreEqual("2 days", fromTime.ToNaturalText(overflowDays, foo_ci));
            Assert.AreEqual("1 day", fromTime.ToNaturalText(noOverflowDays, foo_ci));

            var overflowHours = fromTime.AddHours(1).AddMinutes(40);
            var overflowHours2 = fromTime.AddHours(1).AddMinutes(55);
            var noOverflowHours = fromTime.AddHours(1).AddMinutes(10);
            Assert.AreEqual("2 hours", fromTime.ToNaturalText(overflowHours, foo_ci));
            Assert.AreEqual("2 hours", fromTime.ToNaturalText(overflowHours2, foo_ci));
            Assert.AreEqual("1 hour", fromTime.ToNaturalText(noOverflowHours, foo_ci));

            var overflowMinutes = fromTime.AddMinutes(1).AddSeconds(40);
            var overflowMinutes2 = fromTime.AddMinutes(1).AddSeconds(55);
            var noOverflowMinutes = fromTime.AddMinutes(1).AddSeconds(10);
            Assert.AreEqual("2 minutes", fromTime.ToNaturalText(overflowMinutes, foo_ci));
            Assert.AreEqual("2 minutes", fromTime.ToNaturalText(overflowMinutes2, foo_ci));
            Assert.AreEqual("1 minute", fromTime.ToNaturalText(noOverflowMinutes, foo_ci));

            var roundedMinutes_lowValue = fromTime.AddMinutes(3);
            Assert.AreEqual("3 minutes", fromTime.ToNaturalText(roundedMinutes_lowValue, foo_ci));

            var roundedMinutes_firstQuarter1 = fromTime.AddMinutes(21);
            var roundedMinutes_firstQuarter2 = fromTime.AddMinutes(9);
            Assert.AreEqual("15 minutes", fromTime.ToNaturalText(roundedMinutes_firstQuarter1, foo_ci));
            Assert.AreEqual("15 minutes", fromTime.ToNaturalText(roundedMinutes_firstQuarter2, foo_ci));

            var roundedMinutes_half1 = fromTime.AddMinutes(25);
            var roundedMinutes_half2 = fromTime.AddMinutes(35);
            Assert.AreEqual("30 minutes", fromTime.ToNaturalText(roundedMinutes_half1, foo_ci));
            Assert.AreEqual("30 minutes", fromTime.ToNaturalText(roundedMinutes_half2, foo_ci));

            var roundedMinutes_lastQuarter1 = fromTime.AddMinutes(42);
            var roundedMinutes_lastQuarter2 = fromTime.AddMinutes(47);
            Assert.AreEqual("45 minutes", fromTime.ToNaturalText(roundedMinutes_lastQuarter1, foo_ci));
            Assert.AreEqual("45 minutes", fromTime.ToNaturalText(roundedMinutes_lastQuarter2, foo_ci));
        }
    }
}