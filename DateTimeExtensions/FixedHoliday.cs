using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {
	public class FixedHoliday : Holiday {
		private DayInYear day;

		public FixedHoliday(string name, DayInYear day)
			: base(name) {
			this.day = day;
		}

		public FixedHoliday(string name, int month, int day)
			: base(name) {
			this.day = new DayInYear (month, day);
		}

		public override DateTime? GetInstance(int year) {
			return new DateTime(year, day.Month, day.Day);
		}

		public override bool IsInstanceOf(DateTime date) {
			return date.Month == day.Month && date.Day == day.Day;
		}
	}
}
