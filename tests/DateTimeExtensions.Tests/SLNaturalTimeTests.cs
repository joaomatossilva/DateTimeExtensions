using DateTimeExtensions.NaturalText;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class SL_SINaturalTimeTests : SLNaturalTimeTests
    {
        public SL_SINaturalTimeTests() : base(new NaturalTextCultureInfo("sl-SI"))
        {
        }
    }

    [TestFixture]
    public class SLNaturalTimeTests
    {
        private readonly NaturalTextCultureInfo culture;
        private DateTime fromTime = new DateTime(2016, 6, 21, 10, 28, 0);

        public SLNaturalTimeTests()
        {
            this.culture = new NaturalTextCultureInfo("sl-SI");
        }

        public SLNaturalTimeTests(NaturalTextCultureInfo culture)
        {
            this.culture = culture;
        }

        [Test]
        public void can_tranlate_to_natural_text()
        {
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, false, this.culture);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 uri", naturalText);
        }

        [Test]
        public void can_tranlate_to_natural_text_rounded()
        {
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, true, this.culture);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("3 ure", naturalText);
        }


        [Test]
        public void can_tranlate_to_exact_natural_text()
        {
            var toTime = fromTime.AddHours(2).AddMinutes(30);

            var naturalText = fromTime.ToExactNaturalText(toTime, this.culture);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 uri, 30 minut", naturalText);
        }

        [Test]
        public void can_tranlate_to_exact_natural_text_full()
        {
            var toTime = fromTime.AddSeconds(6).AddMinutes(5).AddHours(4).AddDays(3).AddMonths(2).AddYears(2);

            var naturalText = fromTime.ToExactNaturalText(toTime, this.culture);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 leti, 2 mesca, 3 dni, 4 ur, 5 minut, 6 sekund", naturalText);
        }

        [Test]
        public void are_orderless()
        {
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
            var toTime_plural = fromTime.AddYears(2);
            var toTime_plural3 = fromTime.AddYears(3);
            var toTime_plural4 = fromTime.AddYears(4);
            var toTime_single = fromTime.AddYears(1);

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, this.culture);
            var naturalText_plural3 = fromTime.ToNaturalText(toTime_plural3, true, this.culture);
            var naturalText_plural4 = fromTime.ToNaturalText(toTime_plural4, true, this.culture);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, this.culture);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_plural3);
            Assert.IsNotEmpty(naturalText_plural3);
            Assert.IsNotNull(naturalText_plural4);
            Assert.IsNotEmpty(naturalText_plural4);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("4 let", naturalText_plural4);
            Assert.AreEqual("3 leta", naturalText_plural3);
            Assert.AreEqual("2 leti", naturalText_plural);
            Assert.AreEqual("1 leto", naturalText_single);
        }

        [Test]
        public void can_pluralize_months()
        {
            var toTime_plural = fromTime.AddMonths(2);
            var toTime_plural3 = fromTime.AddMonths(3);
            var toTime_plural4 = fromTime.AddMonths(4);
            var toTime_single = fromTime.AddMonths(1);

            var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, this.culture);
            var naturalText_plural3 = fromTime.ToNaturalText(toTime_plural3, true, this.culture);
            var naturalText_plural4 = fromTime.ToNaturalText(toTime_plural4, true, this.culture);
            var naturalText_single = fromTime.ToNaturalText(toTime_single, true, this.culture);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_plural3);
            Assert.IsNotEmpty(naturalText_plural3);
            Assert.IsNotNull(naturalText_plural4);
            Assert.IsNotEmpty(naturalText_plural4);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("4 mescev", naturalText_plural4);
            Assert.AreEqual("3 mesci", naturalText_plural3);
            Assert.AreEqual("2 mesca", naturalText_plural);
            Assert.AreEqual("1 mesec", naturalText_single);
        }

        [Test]
        public void can_pluralize()
        {
            var toTime_plural = fromTime.AddDays(2).AddHours(2).AddMinutes(2).AddSeconds(2);
            var toTime_plural3 = fromTime.AddDays(3).AddHours(3).AddMinutes(3).AddSeconds(3);
            var toTime_plural4 = fromTime.AddDays(4).AddHours(4).AddMinutes(4).AddSeconds(4);
            var toTime_single = fromTime.AddDays(1).AddHours(1).AddMinutes(1).AddSeconds(1);

            var naturalText_plural = fromTime.ToExactNaturalText(toTime_plural, this.culture);
            var naturalText_plural3 = fromTime.ToExactNaturalText(toTime_plural3, this.culture);
            var naturalText_plural4 = fromTime.ToExactNaturalText(toTime_plural4, this.culture);
            var naturalText_single = fromTime.ToExactNaturalText(toTime_single, this.culture);

            Assert.IsNotNull(naturalText_plural);
            Assert.IsNotEmpty(naturalText_plural);
            Assert.IsNotNull(naturalText_plural3);
            Assert.IsNotEmpty(naturalText_plural3);
            Assert.IsNotNull(naturalText_plural4);
            Assert.IsNotEmpty(naturalText_plural4);
            Assert.IsNotNull(naturalText_single);
            Assert.IsNotEmpty(naturalText_single);
            Assert.AreEqual("2 dni, 2 uri, 2 minuti, 2 sekundi", naturalText_plural);
            Assert.AreEqual("3 dni, 3 ure, 3 minute, 3 sekunde", naturalText_plural3);
            Assert.AreEqual("4 dni, 4 ur, 4 minut, 4 sekund", naturalText_plural4);
            Assert.AreEqual("1 dan, 1 ura, 1 minuta, 1 sekunda", naturalText_single);
        }
    }
}
