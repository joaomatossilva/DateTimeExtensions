using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {
	public class DayInYear {

		public DayInYear(int month, int day) {
			this.Month = month;
			this.Day = day;
		}

		public int Day { get; private set; }
		public int Month { get; private set; }
	}
}
