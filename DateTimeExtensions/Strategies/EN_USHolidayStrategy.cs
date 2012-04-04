using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class EN_USHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public EN_USHolidayStrategy() {
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);

			this.InnerHolidays.Add(IndependenceDay);
			this.InnerHolidays.Add(GlobalHolidays.VeteransDay);
			this.InnerHolidays.Add(MartinLutherKing);
			this.InnerHolidays.Add(WashingtonsBirthday);
			this.InnerHolidays.Add(MemorialDay);
			this.InnerHolidays.Add(LaborDay);
			this.InnerHolidays.Add(ColumbusDay);
			this.InnerHolidays.Add(ThanksgivingDay);
		}

		public override bool IsHoliDay(DateTime day) {
			var isHoliday = this.InnerHolidays.Where(h => h.IsInstanceOf(day)).SingleOrDefault();
			if (isHoliday != null) {
				return true;
			}
			
			// If day is a monday, check if previous sunday is an holiday
			if (day.DayOfWeek == DayOfWeek.Monday)
				return IsHoliDay(day.AddDays(-1));

			// If day is a friday, check if nex saturday is an holiday
			if (day.DayOfWeek == DayOfWeek.Friday)
				return IsHoliDay(day.AddDays(1));

			return false;
		}

		private static Holiday independenceDay;
		public static Holiday IndependenceDay {
			get {
				if (independenceDay == null) {
					independenceDay = new FixedHoliday("Independence Day", 7, 4);
				}
				return independenceDay;
			}
		}

		//Third Monday in January - Birthday of Martin Luther King, Jr.
		private static Holiday martinLutherKing;
		public static Holiday MartinLutherKing {
			get {
				if (martinLutherKing == null) {
					martinLutherKing = new NthDayOfWeekInMonthHoliday("Birthday of Martin Luther King, Jr.", 3, DayOfWeek.Monday, 1, CountDirection.FromFirst);
				}
				return martinLutherKing;
			}
		}

		//Inauguration Day
		//First January 20th following a Presidential election

		//Third Monday in February - Washington's Birthday
		private static Holiday washingtonsBirthday;
		public static Holiday WashingtonsBirthday {
			get {
				if (washingtonsBirthday == null) {
					washingtonsBirthday = new NthDayOfWeekInMonthHoliday("Washington's Birthday", 3, DayOfWeek.Monday, 2, CountDirection.FromFirst);
				}
				return washingtonsBirthday;
			}
		}

		//Last Monday in May - Memorial Day
		private static Holiday memorialDay;
		public static Holiday MemorialDay {
			get {
				if (memorialDay == null) {
					memorialDay = new NthDayOfWeekInMonthHoliday("Memorial Day", 1, DayOfWeek.Monday, 5, CountDirection.FromLast);
				}
				return memorialDay;
			}
		}

		//Third Monday in February - Washington's Birthday
		private static Holiday laborDay;
		public static Holiday LaborDay {
			get {
				if (laborDay == null) {
					laborDay = new NthDayOfWeekInMonthHoliday("Labor Day", 1, DayOfWeek.Monday, 9, CountDirection.FromFirst);
				}
				return laborDay;
			}
		}

		//Second Monday in October - Columbus Day
		private static Holiday columbusDay;
		public static Holiday ColumbusDay {
			get {
				if (columbusDay == null) {
					columbusDay = new NthDayOfWeekInMonthHoliday("Columbus Day", 2, DayOfWeek.Monday, 10, CountDirection.FromFirst);
				}
				return columbusDay;
			}
		}

		//Fourth Thursday in November - Thanksgiving Day
		private static Holiday thanksgivingDay;
		public static Holiday ThanksgivingDay {
			get {
				if (thanksgivingDay == null) {
					thanksgivingDay = new NthDayOfWeekInMonthHoliday("Thanksgiving Day", 4, DayOfWeek.Thursday, 11, CountDirection.FromFirst);
				}
				return thanksgivingDay;
			}
		}
	}
}
