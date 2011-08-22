using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class PT_PTHolidayStrategy : IHolidayStrategy {
		private const ChristianHoliday christianHolidays = ChristianHoliday.All;
		private IHolidayStrategy decoratedInstance;
		IList<DayInYear> fixedNationalHolidays;


		public PT_PTHolidayStrategy() {
			this.decoratedInstance = new ChristianHolidayStrategy(christianHolidays);
			this.fixedNationalHolidays = new List<DayInYear>();
			fixedNationalHolidays.Add(new DayInYear { Day = 25, Month = 4 });	//Freedom Day
			fixedNationalHolidays.Add(new DayInYear { Day = 1, Month = 5 });	//Labor Day
			fixedNationalHolidays.Add(new DayInYear { Day = 10, Month = 6 });	//Portugal Day
			fixedNationalHolidays.Add(new DayInYear { Day = 5, Month = 10 });	//Republic Day
			fixedNationalHolidays.Add(new DayInYear { Day = 1, Month = 12 });	//Restoration of Independance
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
