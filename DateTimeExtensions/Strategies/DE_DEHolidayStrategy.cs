using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class DE_DEHolidayStrategy : IHolidayStrategy {
		private IHolidayStrategy decoratedInstance;
		IList<DayInYear> fixedNationalHolidays;


		public DE_DEHolidayStrategy() {
			var christianHolidays =
				ChristianHoliday.NewYear |
				ChristianHoliday.GoodFriday |
				ChristianHoliday.EasterMonday |
				ChristianHoliday.Ascension |
				ChristianHoliday.Pentecost |
				ChristianHoliday.Christmas;

			this.decoratedInstance = new ChristianHolidayStrategy(christianHolidays);
			this.fixedNationalHolidays = new List<DayInYear>();
			fixedNationalHolidays.Add(new DayInYear { Day = 1, Month = 5 });	//Labor Day
			fixedNationalHolidays.Add(new DayInYear { Day = 3, Month = 10 });	//German Unity Day
			fixedNationalHolidays.Add(new DayInYear { Day = 26, Month = 12 });	//St Stephen's Day
		}

		public bool IsHoliDay(DateTime day) {
			if (decoratedInstance.IsHoliDay(day)) {
				return true;
			}
			var isHoliday = fixedNationalHolidays.Where(h => h.Day == day.Day && h.Month == day.Month).SingleOrDefault();
			if (isHoliday != null) {
				return true;
			}
			return false;
		}

	}
}
