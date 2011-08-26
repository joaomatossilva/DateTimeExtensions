using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class PT_BRHolidayStrategy : IHolidayStrategy {
		private IHolidayStrategy decoratedInstance;
		IList<DayInYear> fixedNationalHolidays;


		public PT_BRHolidayStrategy() {
			var christianHolidays =
				ChristianHoliday.NewYear |
				ChristianHoliday.Christmas;

			this.decoratedInstance = new ChristianHolidayStrategy(christianHolidays);
			this.fixedNationalHolidays = new List<DayInYear>();
			fixedNationalHolidays.Add(new DayInYear { Day = 21, Month = 4 });	//Tiradentes Day
			fixedNationalHolidays.Add(new DayInYear { Day = 1, Month = 5 });	//Labor Day
			fixedNationalHolidays.Add(new DayInYear { Day = 7, Month = 9 });	//Independance Day
			fixedNationalHolidays.Add(new DayInYear { Day = 12, Month = 10 });	//Our Lady of Aparecida
			fixedNationalHolidays.Add(new DayInYear { Day = 2, Month = 11 });	//Day of the Dead
			fixedNationalHolidays.Add(new DayInYear { Day = 15, Month = 11 });	//Republic Day
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
