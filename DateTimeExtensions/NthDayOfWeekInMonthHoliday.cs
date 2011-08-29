using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {

	public enum CountDirection { FromFirst, FromLast };

	public class NthDayOfWeekInMonthHoliday : Holiday {
		private int count;
		private DayOfWeek dayOfWeek;
		private CountDirection direction;
		private int month;
		private IDictionary<int, DayInYear> dayCache;

		public NthDayOfWeekInMonthHoliday(string name, int count, DayOfWeek dayOfWeek, int month, CountDirection direction)
			: base(name) {
			this.count = count;
			this.dayOfWeek = dayOfWeek;
			this.direction = direction;
			dayCache = new Dictionary<int, DayInYear>();
		}

		public override DayInYear GetInstance(int year) {
			if (dayCache.ContainsKey(year))
				return dayCache[year];
			var day = CalculateDayInYear(year);
			dayCache.Add(year, day);
			return day;
		}

		public override bool IsInstanceOf(DateTime date) {
			var day = GetInstance(date.Year);
			return date.Month == day.Month && date.Day == day.Day;
		}

		private DayInYear CalculateDayInYear(int year) {
			if (direction == CountDirection.FromFirst) {
				DateTime firstDayInMonth = new DateTime(year, month, 1);
				if (firstDayInMonth.DayOfWeek == dayOfWeek) {
					return new DayInYear(firstDayInMonth.Month, firstDayInMonth.Year);
				}
				var dayOfWeekInMonth = firstDayInMonth.FirstDayOfWeekOfTheMonth(dayOfWeek);
				int daysOffset = 7 * (count - 1);
				var date = dayOfWeekInMonth.AddDays(daysOffset);
				return new DayInYear(date.Month, date.Day);
			} else {
				DateTime lastDayInMonth = new DateTime(year, month, 1);
				lastDayInMonth = lastDayInMonth.LastDayOfTheMonth();
				if (lastDayInMonth.DayOfWeek == dayOfWeek) {
					return new DayInYear(lastDayInMonth.Month, lastDayInMonth.Year);
				}
				var dayOfWeekInMonth = lastDayInMonth.LastDayOfWeekOfTheMonth(dayOfWeek);
				int daysOffset = -7 * (count - 1);
				var date = dayOfWeekInMonth.AddDays(daysOffset);
				return new DayInYear(date.Month, date.Day);
			}
		}
	}
}
