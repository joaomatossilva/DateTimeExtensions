using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {
	public struct DateDiff {

		private const int DAYS_IN_MONTH = 30;
		private const int DAYS_IN_YEAR = 365;

		public DateDiff(TimeSpan span) : this() {
			int totalDays = span.Days;
			Years = totalDays / DAYS_IN_YEAR;
			if (Years > 0) {
				totalDays -= Years * DAYS_IN_YEAR;
			}
			Months = totalDays / DAYS_IN_MONTH;
			if (Months > 0) {
				totalDays -= Months * DAYS_IN_MONTH;
			}
			Days = totalDays;
			Hours = span.Hours;
			Minutes = span.Minutes;
			Seconds = span.Seconds;
		}

		public DateDiff(int seconds, int minutes = 0, int hours = 0, int days = 0, int months = 0, int years = 0) : this() {
			Years = years;
			Months = months;
			Days = days;
			Hours = hours;
			Minutes = minutes;
			Seconds = seconds;
		}

		public int Years { get; set; }

		public int Months { get; set; }

		public int Days { get; set; }

		public int Hours { get; set; }

		public int Minutes { get; set; }

		public int Seconds { get; set; }
	}
}
