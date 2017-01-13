using System;
using DateTimeExtensions.NaturalText;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class NL_BENaturalTimeTests : NLNaturalTimeTests
    {
        public NL_BENaturalTimeTests() : base(new NaturalTextCultureInfo("nl-BE"))
        {
        }
    }

    [TestFixture]
    public class NLNaturalTimeTests
    {
        private readonly NaturalTextCultureInfo culture;

        public NLNaturalTimeTests()
        {
            this.culture = new NaturalTextCultureInfo("nl-NL");
        }

        public NLNaturalTimeTests(NaturalTextCultureInfo culture)
        {
            this.culture = culture;
        }

        [Test]
        public void can_tranlate_to_natural_text()
        {
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, false, this.culture);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 uur", naturalText);
        }

        [Test]
        public void can_tranlate_to_natural_text_rounded()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, true, this.culture);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("3 uur", naturalText);
        }


        [Test]
        public void can_tranlate_to_exact_natural_text()
        {
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddHours(2).AddMinutes(30);

            var naturalText = fromTime.ToExactNaturalText(toTime, this.culture);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 uur, 30 minuten", naturalText);
        }

        [Test]
        public void can_tranlate_to_exact_natural_text_full()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddSeconds(6).AddMinutes(5).AddHours(4).AddDays(3).AddMonths(2).AddYears(2);

            var naturalText = fromTime.ToExactNaturalText(toTime, this.culture);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 jaar, 2 maanden, 3 dagen, 4 uur, 5 minuten, 6 seconden", naturalText);
        }

        [Test]
        public void are_orderless()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddSeconds(6).AddMinutes(5).AddHours(4).AddDays(3).AddMonths(2).AddYears(2);

            var naturalText = fromTime.ToExactNaturalText(toTime, this.culture);
            var naturalTextReverse = toTime.ToExactNaturalText(fromTime, this.culture);

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

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, this.culture);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, this.culture);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("2 jaar", naturalText_plural);
            Assert.AreEqual("1 jaar", naturalText_single);
        }

        [Test]
        public void can_pluralize_months()
        {
            var fromTime = DateTime.Now;
            var toTime_plural = fromTime.AddMonths(2);
            var toTime_single = fromTime.AddMonths(1);

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, this.culture);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, this.culture);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("2 maanden", naturalText_plural);
            Assert.AreEqual("1 maand", naturalText_single);
        }

        [Test]
        public void can_pluralize()
        {
            var fromTime = DateTime.Now;
            var toTime_plural = fromTime.AddDays(2).AddHours(2).AddMinutes(2).AddSeconds(2);
            var toTime_single = fromTime.AddDays(1).AddHours(1).AddMinutes(1).AddSeconds(1);

            var naturalText_plural = fromTime.ToExactNaturalText(toTime_plural, this.culture);
            var naturalText_single = fromTime.ToExactNaturalText(toTime_single, this.culture);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("2 dagen, 2 uur, 2 minuten, 2 seconden", naturalText_plural);
            Assert.AreEqual("1 dag, 1 uur, 1 minuut, 1 seconde", naturalText_single);
        }
    }
}