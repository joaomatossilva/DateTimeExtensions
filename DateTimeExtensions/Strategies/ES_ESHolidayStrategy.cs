using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class ES_ESHolidayStrategy : IHolidayStrategy {
		private IHolidayStrategy decoratedInstance;
		IList<DayInYear> fixedNationalHolidays;


		public ES_ESHolidayStrategy() {
			var christianHolidays = 
				ChristianHoliday.NewYear |
				ChristianHoliday.GoodFriday |
				ChristianHoliday.ImaculateConception |
				ChristianHoliday.Assumption |
				ChristianHoliday.AllSaints |
				ChristianHoliday.Christmas;
			this.decoratedInstance = new ChristianHolidayStrategy(christianHolidays);
			this.fixedNationalHolidays = new List<DayInYear>();

			fixedNationalHolidays.Add(new DayInYear { Day = 6, Month = 1 });	//Epiphany
			fixedNationalHolidays.Add(new DayInYear { Day = 1, Month = 5 });	//Labor Day
			fixedNationalHolidays.Add(new DayInYear { Day = 12, Month = 8 });	//National Day
			fixedNationalHolidays.Add(new DayInYear { Day = 6, Month = 12 });	//Constitution Day
		}

		public bool IsHoliDay(DateTime day) {
			DateTime testDate = day;
			// If day is a monday, check if previous sunday is an holiday
			if (day.DayOfWeek == DayOfWeek.Monday)
				testDate = day.AddDays(-1);

			if (decoratedInstance.IsHoliDay(testDate)) {
				return true;
			}
			var isHoliday = fixedNationalHolidays.Where(h => h.Day == testDate.Day && h.Month == testDate.Month).SingleOrDefault();
			if (isHoliday != null) {
				return true;
			}
			return false;
		}

	}
}
