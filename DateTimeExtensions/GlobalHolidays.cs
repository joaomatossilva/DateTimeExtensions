using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {
	public static class GlobalHolidays {

		private static Holiday internationalWorkersDay;
		public static Holiday InternationalWorkersDay {
			get {
				if (internationalWorkersDay == null) {
					internationalWorkersDay = new FixedHoliday("International Workers' day", 5, 1);
				}
				return internationalWorkersDay;
			}
		}

		private static Holiday stPatricksDay;
		public static Holiday StPatricsDay {
			get {
				if (stPatricksDay == null) {
					stPatricksDay = new FixedHoliday("St. Patric's Day", 3, 17);
				}
				return stPatricksDay;
			}
		}

		private static Holiday veteransDay;
		public static Holiday VeteransDay {
			get {
				if (veteransDay == null) {
					veteransDay = new FixedHoliday("Veterans Day", 11, 11);
				}
				return veteransDay;
			}
		}

		private static Holiday boxingDay;
		public static Holiday BoxingDay {
			get {
				if (boxingDay == null) {
					boxingDay = new FixedHoliday("Boxing Day", 12, 26);
				}
				return boxingDay;
			}
		}

		private static Holiday mayDay;
		public static Holiday MayDay {
			get {
				if (mayDay == null) {
					mayDay = new FixedHoliday("May Day", 5, 1);
				}
				return mayDay;
			}
		}

		//Midsummer Eve - Friday between 19 June and 25 June
		private static Holiday midsummerEve;
		public static Holiday MidsummerEve {
			get {
				if (midsummerEve == null) {
					midsummerEve = new NthDayOfWeekAfterDayHoliday("Midsummer Eve", 1, DayOfWeek.Friday, 6, 19);
				}
				return midsummerEve;
			}
		}

		//MidSummer Day - Saturday between 20 June and 26 June
		private static Holiday midsummerDay;
		public static Holiday MidsummerDay {
			get {
				if (midsummerDay == null) {
					midsummerDay = new NthDayOfWeekAfterDayHoliday("Midsummer Day", 1, DayOfWeek.Saturday, 6, 20);
				}
				return midsummerDay;
			}
		}

		//New Year's Eve - 31 December
		private static Holiday newYearsEve;
		public static Holiday NewYearsEve {
			get {
				if (newYearsEve == null) {
					newYearsEve = new FixedHoliday("New Year's Eve", 12, 31);
				}
				return newYearsEve;
			}
		}
	}
}
