using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class EN_GBHolidayStrategy : IHolidayStrategy {
		IList<Holiday> holidays;

		public EN_GBHolidayStrategy() {
			this.holidays = new List<Holiday>();
			holidays.Add(ChristianHolidays.NewYear);
			holidays.Add(ChristianHolidays.GoodFriday);
			holidays.Add(ChristianHolidays.EasterMonday);
			holidays.Add(ChristianHolidays.Christmas);
			
			holidays.Add(GlobalHolidays.StPatricsDay);
			holidays.Add(GlobalHolidays.BoxingDay);
			holidays.Add(MayDayBank);
			holidays.Add(SpringBank);
			holidays.Add(LateSummerBank);
		}

		public bool IsHoliDay(DateTime day) {
			var isHoliday = holidays.Where(h => h.IsInstanceOf(day)).SingleOrDefault();
			if (isHoliday != null) {
				return true;
			}
			return false;
		}

		public IEnumerable<Holiday> Holidays {
			get {
				var currentYear = DateTime.Now.Year;
				return this.GetHolidaysOfYear(currentYear);
			}
		}

		public IEnumerable<Holiday> GetHolidaysOfYear(int year) {
			return holidays.Where(h => h.GetInstance(year).HasValue);
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

		//1st Monday in May	- May Day Bank Holiday
		private static Holiday mayDayBank;
		public static Holiday MayDayBank {
			get {
				if (mayDayBank == null) {
					mayDayBank = new NthDayOfWeekInMonthHoliday("May Day Bank", 1, DayOfWeek.Monday, 5, CountDirection.FromFirst);
				}
				return mayDayBank;
			}
		}

		//Last Monday in May - Spring Bank Holiday
		private static Holiday springBank;
		public static Holiday SpringBank {
			get {
				if (springBank == null) {
					springBank = new NthDayOfWeekInMonthHoliday("Spring Bank", 1, DayOfWeek.Monday, 5, CountDirection.FromLast);
				}
				return springBank;
			}
		}

		//Last Monday in August	- Late Summer Bank Holiday
		private static Holiday lateSummerBank;
		public static Holiday LateSummerBank {
			get {
				if (lateSummerBank == null) {
					lateSummerBank = new NthDayOfWeekInMonthHoliday("Late Summer Bank", 1, DayOfWeek.Monday, 8, CountDirection.FromLast);
				}
				return lateSummerBank;
			}
		}
	}
}
