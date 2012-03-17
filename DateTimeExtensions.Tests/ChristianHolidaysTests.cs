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

		[Test]
		public void pentecostIs50DaysAfterEater() {
			for (int year = 2012; year < 2020; year++) {
				var easterHoliday = ChristianHolidays.Easter;
				var easter = easterHoliday.GetInstance(year);
				Assert.IsTrue(easter.HasValue);
				Assert.AreEqual(DayOfWeek.Sunday, easter.Value.DayOfWeek);

				var penteconstHoliday = ChristianHolidays.Pentecost;
				var pentecost = penteconstHoliday.GetInstance(year);
				Assert.IsTrue(pentecost.HasValue);
				Assert.AreEqual(DayOfWeek.Sunday, pentecost.Value.DayOfWeek);

				//source: http://en.wikipedia.org/wiki/Pentecost
				// According to Christian tradition, Pentecost is always seven weeks after Easter Sunday; that is to say, 50 days after Easter (inclusive of Easter Day)
				Assert.AreEqual(easter.Value.AddDays(49), pentecost.Value);
			}	
		}
		
	}
}
