namespace DateTimeExtensions.Tests
{
	using System;
	using System.Linq;
	using DateTimeExtensions.WorkingDays;

	using NUnit.Framework;

	[TestFixture]
	public class NLHolidaysTests
	{
		private readonly WorkingDayCultureInfo dateTimeCulture = new WorkingDayCultureInfo("nl-NL");

		[Test]
		public void The_Netherlands_has_10_main_holidays()
		{
			var holidays = dateTimeCulture.Holidays;
			Assert.AreEqual(10, holidays.Count());
		}

		[Test]
		public void Liberation_Day_is_a_national_holiday_in_2005()
		{
			// Liberation_Day_is_a_national_holiday_once_every_5_years
			
			Assert.That(LiberationDay(2005).IsHoliday(dateTimeCulture));
		}

		[Test]
		public void Liberation_Day_is_a_regular_day_in_2006()
		{
			// Liberation_Day_is_a_national_holiday_once_every_5_years

			Assert.That(LiberationDay(2006).IsWorkingDay(dateTimeCulture));
		}

		private static DateTime LiberationDay (int year)
		{
			var liberationDay = new DateTime(year, 5, 5);

			return liberationDay;
		}
	}
}