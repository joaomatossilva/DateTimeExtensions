using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class FR_FRHolidayStrategy : IHolidayStrategy {
		private IHolidayStrategy decoratedInstance;
		IList<DayInYear> fixedNationalHolidays;


		public FR_FRHolidayStrategy() {
			var christianHolidays =
				ChristianHoliday.NewYear |
				ChristianHoliday.EasterMonday |
				ChristianHoliday.Ascension |
				ChristianHoliday.AllSaints |
				ChristianHoliday.Christmas;

			this.decoratedInstance = new ChristianHolidayStrategy(christianHolidays);
			this.fixedNationalHolidays = new List<DayInYear>();
			fixedNationalHolidays.Add(new DayInYear { Day = 1, Month = 5 });	//Labor Day
			fixedNationalHolidays.Add(new DayInYear { Day = 8, Month = 5 });	//Victory in Europe Day
			fixedNationalHolidays.Add(new DayInYear { Day = 14, Month = 7 });	//Bastille Day
			fixedNationalHolidays.Add(new DayInYear { Day = 11, Month = 11 });	//Veterans Day
			fixedNationalHolidays.Add(new DayInYear { Day = 26, Month = 12 });	//St Etienne
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
