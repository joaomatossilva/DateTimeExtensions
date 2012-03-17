using System;
using NUnit.Framework;
using System.Globalization;
using System.Threading;
using DateTimeExtensions;
using DateTimeExtensions.Strategies;
using System.Collections.Generic;

namespace DateTimeExtensions.Tests {
	[TestFixture]
	class ChristianHolidaysTests {

		public void can_calculate_easter() {
			for (int year = 2012; year < 2020; year++) {
				var easterHoliday = ChristianHolidays.Easter;
				var easter = easterHoliday.GetInstance(year);
				Assert.IsTrue(easter.HasValue);
				Assert.AreEqual(DayOfWeek.Sunday, easter.Value.DayOfWeek);
			}
		}

		[Test]
		public void pentecost_is_49_days_after_easter() {
			for (int year = 2012; year < 2020; year++) {
				var easterHoliday = ChristianHolidays.Easter;
				var easter = easterHoliday.GetInstance(year);

				var pentecostHoliday = ChristianHolidays.Pentecost;
				var pentecost = pentecostHoliday.GetInstance(year);
				Assert.IsTrue(pentecost.HasValue);
				Assert.AreEqual(DayOfWeek.Sunday, pentecost.Value.DayOfWeek);

				//source: http://en.wikipedia.org/wiki/Pentecost
				// According to Christian tradition, Pentecost is always seven weeks after Easter Sunday; that is to say, 50 days after Easter (inclusive of Easter Day)
				Assert.AreEqual(easter.Value.AddDays(49), pentecost.Value);
			}	
		}
		
		[Test]
		public void ascencion_is_40_days_after_easter() {
			for (int year = 2012; year < 2020; year++) {
				var easterHoliday = ChristianHolidays.Easter;
				var easter = easterHoliday.GetInstance(year);

				var ascencionHoliday = ChristianHolidays.Ascension;
				var ascencion = ascencionHoliday.GetInstance(year);
				Assert.IsTrue(ascencion.HasValue);
				Assert.AreEqual(DayOfWeek.Thursday, ascencion.Value.DayOfWeek);

				//source: http://en.wikipedia.org/wiki/Ascension_Day
				// Ascension Day is traditionally celebrated on a Thursday, the fortieth day of Easter
				// again, easter day is included
				Assert.AreEqual(easter.Value.AddDays(39), ascencion.Value);
			}			
		}
	}
}
