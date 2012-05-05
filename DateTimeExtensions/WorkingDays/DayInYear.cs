using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace DateTimeExtensions.WorkingDays {
	public class DayInYear {

		public DayInYear(int month, int day)
			: this(month, day, new GregorianCalendar()) {
		}

		public DayInYear(int month, int day, Calendar calendar) {
			this.Month = month;
			this.Day = day;
			this.Calendar = calendar;
		}

		public int Day { get; private set; }
		public int Month { get; private set; }
		public Calendar Calendar { get; private set; }

		public DateTime GetDayOnYear(int year) {
			var firstDayOnGregoryanCalendar = new DateTime(year, 1, 1);
			var dayInstance = new DateTime(Calendar.GetYear(firstDayOnGregoryanCalendar), Month, Day, Calendar);

			//check if the instance day falls on previous year on Gregorian calendar.
			// the instance should fall between year and year + 1. 
			// TODO: This smells a bit. Ensure this is true for all types of calendars.
			if (dayInstance.Year < firstDayOnGregoryanCalendar.Year) {
				dayInstance = Calendar.AddYears(dayInstance, 1);
			}

			return dayInstance;
		}

		public bool IsTheSameDay(DateTime day) {
			var thisDayInYear = new DateTime(Calendar.GetYear(day), Month, Day, Calendar);
			return thisDayInYear == day.Date;
		}
	}
}
