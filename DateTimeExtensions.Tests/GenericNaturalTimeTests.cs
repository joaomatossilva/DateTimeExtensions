using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using DateTimeExtensions;

namespace DateTimeExtensions.Tests {

	[TestFixture]
	public class GenericNaturalTimeTests {
		private DateTimeCultureInfo foo_ci = new DateTimeCultureInfo("foo");

		[Test]
		public void can_tranlate_to_natural_text() {
			var fromTime = DateTime.Now;
			var toTime = DateTime.Now.AddHours(2);

			var naturalText = fromTime.ToNaturalText(toTime, true, foo_ci);

			Assert.IsNotNullOrEmpty(naturalText);
			Assert.AreEqual("2 hours", naturalText);
		}

		[Test]
		public void can_tranlate_to_exact_natural_text() {
			var fromTime = DateTime.Now;
			var toTime = DateTime.Now.AddHours(2).AddMinutes(30);

			var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

			Assert.IsNotNullOrEmpty(naturalText);
			Assert.AreEqual("2 hours, 30 minutes", naturalText);
		}

		[Test]
		public void can_tranlate_to_exact_natural_text_full() {
			var fromTime = DateTime.Now;
			var toTime = fromTime.AddYears(2).AddMonths(2).AddDays(3).AddHours(4).AddMinutes(5).AddSeconds(6);

			var naturalText = fromTime.ToExactNaturalText(toTime, foo_ci);

			Assert.IsNotNullOrEmpty(naturalText);
			Assert.AreEqual("2 years, 2 months, 3 days, 4 hours, 5 minutes, 6 seconds", naturalText);
		}

		[Test]
		public void can_pluralize_years() {
			var fromTime = DateTime.Now;
			var toTime_plural = fromTime.AddYears(2);
			var toTime_single = fromTime.AddYears(1);

			var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, foo_ci);
			var naturalText_single = fromTime.ToNaturalText(toTime_single, true, foo_ci);

			Assert.IsNotNullOrEmpty(naturalText_plural);
			Assert.IsNotNullOrEmpty(naturalText_single);
			Assert.AreEqual("2 years", naturalText_plural);
			Assert.AreEqual("1 year", naturalText_single);
		}

		[Test]
		public void can_pluralize_months() {
			var fromTime = DateTime.Now;
			var toTime_plural = fromTime.AddDays(60);
			var toTime_single = fromTime.AddDays(30);

			var naturalText_plural = fromTime.ToNaturalText(toTime_plural, true, foo_ci);
			var naturalText_single = fromTime.ToNaturalText(toTime_single, true, foo_ci);

			Assert.IsNotNullOrEmpty(naturalText_plural);
			Assert.IsNotNullOrEmpty(naturalText_single);
			Assert.AreEqual("2 months", naturalText_plural);
			Assert.AreEqual("1 month", naturalText_single);
		}

		[Test]
		public void can_pluralize() {
			var fromTime = DateTime.Now;
			var toTime_plural = fromTime.AddDays(2).AddHours(2).AddMinutes(2).AddSeconds(2);
			var toTime_single = fromTime.AddDays(1).AddHours(1).AddMinutes(1).AddSeconds(1);

			var naturalText_plural = fromTime.ToExactNaturalText(toTime_plural, foo_ci);
			var naturalText_single = fromTime.ToExactNaturalText(toTime_single, foo_ci);

			Assert.IsNotNullOrEmpty(naturalText_plural);
			Assert.IsNotNullOrEmpty(naturalText_single);
			Assert.AreEqual("2 days, 2 hours, 2 minutes, 2 seconds", naturalText_plural);
			Assert.AreEqual("1 day, 1 hour, 1 minute, 1 second", naturalText_single);
		}	

	}
}
