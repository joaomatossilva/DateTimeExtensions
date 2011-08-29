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
		private IDictionary<int, DateTime> dayCache;

		public NthDayOfWeekInMonthHoliday(string name, int count, DayOfWeek dayOfWeek, int month, CountDirection direction)
			: base(name) {
			this.count = count;
			this.dayOfWeek = dayOfWeek;
			this.month = month;
			this.direction = direction;
			dayCache = new Dictionary<int, DateTime>();
		}

		public override DateTime GetInstance(int year) {
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

		private DateTime CalculateDayInYear(int year) {
			if (direction == CountDirection.FromFirst) {
				DateTime firstDayInMonth = new DateTime(year, month, 1);
				if (firstDayInMonth.DayOfWeek == dayOfWeek) {
					return firstDayInMonth;
				}
				var dayOfWeekInMonth = firstDayInMonth.FirstDayOfWeekOfTheMonth(dayOfWeek);
				int daysOffset = 7 * (count - 1);
				return dayOfWeekInMonth.AddDays(daysOffset);
			} else {
				DateTime lastDayInMonth = new DateTime(year, month, 1);
				lastDayInMonth = lastDayInMonth.LastDayOfTheMonth();
				if (lastDayInMonth.DayOfWeek == dayOfWeek) {
					return lastDayInMonth;
				}
				var dayOfWeekInMonth = lastDayInMonth.LastDayOfWeekOfTheMonth(dayOfWeek);
				int daysOffset = -7 * (count - 1);
				return dayOfWeekInMonth.AddDays(daysOffset);
			}
		}
	}
}
