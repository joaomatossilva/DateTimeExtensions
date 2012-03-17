using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {

	public class NthDayOfWeekAfterHolidayHoliday : Holiday {
		private readonly DayOfWeek dayOfWeek;
		private readonly int count;
		private readonly Holiday baseHoliday;
		private readonly IDictionary<int, DateTime?> dayCache;

		public NthDayOfWeekAfterHolidayHoliday(string name, int count, DayOfWeek dayOfWeek, int month, int day)
			: this(name, count, dayOfWeek, new FixedHoliday(name, month, day)) {
		}

		public NthDayOfWeekAfterHolidayHoliday(string name, int count, DayOfWeek dayOfWeek, DayInYear dayInYear) 
			: this(name, count, dayOfWeek, new FixedHoliday(name, dayInYear)) {			
		}

		public NthDayOfWeekAfterHolidayHoliday(string name, int count, DayOfWeek dayOfWeek, Holiday baseHoliday)
			: base(name) {
			this.count = count;
			this.dayOfWeek = dayOfWeek;
			this.baseHoliday = baseHoliday;
			dayCache = new Dictionary<int, DateTime?>();
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

		private DateTime? CalculateDayInYear(int year) {
			var startDate = baseHoliday.GetInstance(year);
			if (!startDate.HasValue) {
				return null;
			}
			if (startDate.Value.DayOfWeek != dayOfWeek) {
				startDate = startDate.Value.NextDayOfWeek(dayOfWeek);
			}			
			return startDate.Value.AddDays((count - 1) * 7);
		}
	}
}
