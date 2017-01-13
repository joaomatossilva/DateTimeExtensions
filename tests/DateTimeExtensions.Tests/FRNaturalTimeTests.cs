using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DateTimeExtensions.NaturalText;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class FRNaturalTimeTests
    {
        private NaturalTextCultureInfo foo_ci = new NaturalTextCultureInfo("fr-FR");

        [Test]
        public void can_tranlate_to_natural_text()
        {
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, false, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 heures", naturalText);
        }

        [Test]
        public void can_tranlate_to_natural_text_rounded()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var naturalText = fromTime.ToNaturalText(toTime, true, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("3 heures", naturalText);
        }


        [Test]
        public void can_tranlate_to_exact_natural_text()
        {
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddHours(2).AddMinutes(30);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 heures, 30 minutes", naturalText);
        }

        [Test]
        public void can_tranlate_to_exact_natural_text_full()
        {
            var fromTime = DateTime.Now;
            var toTime = fromTime.AddSeconds(6).AddMinutes(5).AddHours(4).AddDays(3).AddMonths(2).AddYears(2);

            var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

            Assert.IsNotNull(naturalText);
            Assert.IsNotEmpty(naturalText);
            Assert.AreEqual("2 ans, 2 mois, 3 journées, 4 heures, 5 minutes, 6 seconds", naturalText);
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
            Assert.AreEqual("2 ans", naturalText_plural);
            Assert.AreEqual("1 année", naturalText_single);
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
            Assert.AreEqual("2 mois", naturalText_plural);
            Assert.AreEqual("1 mois", naturalText_single);
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
            Assert.AreEqual("2 journées, 2 heures, 2 minutes, 2 seconds", naturalText_plural);
            Assert.AreEqual("1 jour, 1 heure, 1 minute, 1 second", naturalText_single);
        }
    }
}