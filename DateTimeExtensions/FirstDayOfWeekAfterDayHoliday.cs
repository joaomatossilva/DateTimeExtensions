using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {

	public class FirstDayOfWeekAfterDayHoliday : Holiday {
		private DayOfWeek dayOfWeek;
		private DayInYear dayInYear;
		private IDictionary<int, DateTime> dayCache;

		public FirstDayOfWeekAfterDayHoliday(string name, DayOfWeek dayOfWeek, int month,  int day)
			: this(name, dayOfWeek, new DayInYear(month, day)) {
		}

		public FirstDayOfWeekAfterDayHoliday(string name, DayOfWeek dayOfWeek, DayInYear dayInYear)
			: base(name) {
			this.dayOfWeek = dayOfWeek;
			this.dayInYear = dayInYear;
			dayCache = new Dictionary<int, DateTime>();
		}

		public override DateTime? GetInstance(int year) {
			if (dayCache.ContainsKey(year))
				return dayCache[year];
			var day = CalculateDayInYear(year);
			dayCache.Add(year, day);
			return day;
		}

		public override bool IsInstanceOf(DateTime date) {
			var day = GetInstance(date.Year);
			return day.HasValue && date.Month == day.Value.Month && date.Day == day.Value.Day;
		}

		private DateTime CalculateDayInYear(int year) {
			var startDate = new DateTime(year, dayInYear.Month, dayInYear.Day);
			if (startDate.DayOfWeek == dayOfWeek) {
				return startDate;
			}
			return startDate.NextDayOfWeek(dayOfWeek);
		}
	}
}
