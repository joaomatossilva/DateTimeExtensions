using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	
	//Canada official languages are french and english.
	// for the time beeing, the en-CA will inherit from fr-CA.
	// in the furure this could be changed...
	public class FR_CAHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public FR_CAHolidayStrategy() {
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
			this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
			this.InnerHolidays.Add(VictoriaDay);
			this.InnerHolidays.Add(CanadaDay);
			this.InnerHolidays.Add(LabourDay);
			this.InnerHolidays.Add(Thanksgiving);
			this.InnerHolidays.Add(RemembranceDay);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);
			this.InnerHolidays.Add(GlobalHolidays.BoxingDay);
		}

		public override bool IsHoliDay(DateTime day) {
			var holiday = this.InnerHolidays.Where(h => h.IsInstanceOf(day)).SingleOrDefault();
			if (holiday != null) {
				return true;
			}

			// If day is a monday, check if previous sunday or saturday is an holiday
			if (day.DayOfWeek == DayOfWeek.Monday) {
				if (IsHoliDay(day.AddDays(-1))) {
					return true;
				}
				return IsHoliDay(day.AddDays(-2));
			}

			return false;
		}

		//First Monday in September - Canada Day
		private static Holiday canadaDay;
		public static Holiday CanadaDay {
			get {
				if (canadaDay == null) {
					canadaDay = new FixedHoliday("Canada Day", 7, 1);
				}
				return canadaDay;
			}
		}

		//First Monday in September - Labour Day
		private static Holiday labourDay;
		public static Holiday LabourDay {
			get {
				if (labourDay == null) {
					labourDay = new NthDayOfWeekInMonthHoliday("Labour Day", 1, DayOfWeek.Monday, 8, CountDirection.FromFirst);
				}
				return labourDay;
			}
		}

		//Monday on or before May 24 - Victoria Day
		private static Holiday victoriaDay;
		public static Holiday VictoriaDay {
			get {
				if (victoriaDay == null) {
					victoriaDay = new NthDayOfWeekAfterDayHoliday("Victoria Day", 1, DayOfWeek.Monday, 5, 24);
				}
				return victoriaDay;
			}
		}

		//Second Monday in October - Thanksgiving
		private static Holiday thanksgiving;
		public static Holiday Thanksgiving {
			get {
				if (thanksgiving == null) {
					thanksgiving = new NthDayOfWeekInMonthHoliday("Thanksgiving", 2, DayOfWeek.Monday, 10, CountDirection.FromFirst);
				}
				return thanksgiving;
			}
		}

		//November 11 - Remembrance Day
		private static Holiday remembranceDay;
		public static Holiday RemembranceDay {
			get {
				if (remembranceDay == null) {
					remembranceDay = new FixedHoliday("Remembrance Day", 11, 11);
				}
				return remembranceDay;
			}
		}
	}
}
