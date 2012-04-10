using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {
	public class FixedHoliday : Holiday {
		private readonly DayInYear day;

		public FixedHoliday(string name, DayInYear day)
			: base(name) {
			this.day = day;
		}

		public FixedHoliday(string name, int month, int day, Calendar calendar)
			: base(name) {
			this.day = new DayInYear (month, day);
		}

		public FixedHoliday(string name, int month, int day)
			: this(name, month, day, new GregorianCalendar()) {
		}

		public override DateTime? GetInstance(int year) {
			return day.GetDayOnYear(year);
		}

		public override bool IsInstanceOf(DateTime date) {
			return day.IsTheSameDay(date);
		}
	}
}
