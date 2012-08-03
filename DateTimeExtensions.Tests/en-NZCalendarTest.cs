using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;


namespace DateTimeExtensions.Tests
{

	[TestFixture]
	public class en_NZCalendarTest
	{

		[Test]
		public void DayAfterNewYearsDay()
		{
			var holiday = EN_NZHolidayStrategy.DayAfterNewYear;

			var dateOnGregorian = new DateTime(2013, 1, 2);
			TestHoliday(holiday, dateOnGregorian);

			dateOnGregorian = new DateTime(2014, 1, 2); TestHoliday(holiday, dateOnGregorian);
			dateOnGregorian = new DateTime(2015, 1, 2); TestHoliday(holiday, dateOnGregorian);
			dateOnGregorian = new DateTime(2016, 1, 4); TestHoliday(holiday, dateOnGregorian);
		}



		private void TestHoliday(Holiday holiday, DateTime dateOnGregorian)
		{
			var holidayInstance = holiday.GetInstance(dateOnGregorian.Year);
			Assert.IsTrue(holidayInstance.HasValue);
			Assert.AreEqual(dateOnGregorian, holidayInstance.Value);
			Assert.IsTrue(holiday.IsInstanceOf(dateOnGregorian));
		}
	}
}
