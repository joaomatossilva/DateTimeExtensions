using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class FI_FIHolidayStrategy : IHolidayStrategy {
		private readonly IList<Holiday> holidays;

		public FI_FIHolidayStrategy() {
			this.holidays = new List<Holiday>();
			holidays.Add(ChristianHolidays.NewYear);
			holidays.Add(ChristianHolidays.Epiphany);
			holidays.Add(ChristianHolidays.GoodFriday);
			holidays.Add(ChristianHolidays.Easter);
			holidays.Add(ChristianHolidays.EasterMonday);
			holidays.Add(GlobalHolidays.MayDay);
			holidays.Add(ChristianHolidays.Ascension);
			holidays.Add(ChristianHolidays.Pentecost);
			holidays.Add(GlobalHolidays.MidsummerEve);
			holidays.Add(GlobalHolidays.MidsummerDay);
			holidays.Add(AllSaintsDay);
			holidays.Add(IndependanceDay);
			holidays.Add(ChristianHolidays.ChristmasEve);
			holidays.Add(ChristianHolidays.Christmas);
			holidays.Add(ChristianHolidays.StStephansDay);
		}

		public bool IsHoliDay(DateTime day) {
			var isHoliday = this.holidays.SingleOrDefault(h => h.IsInstanceOf(day));
			return isHoliday != null;
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

		private static Holiday independanceDay;
		public static Holiday IndependanceDay {
			get {
				if (independanceDay == null) {
					independanceDay = new FixedHoliday("Independance Day", 12, 6);
				}
				return independanceDay;
			}
		}

		//All Saints' Day - Saturday between 31 October and 6 November
		// - Same as ChristianHolidays.AllSaints but has diferent ocurrence
		private static Holiday allSaintsDay;
		public static Holiday AllSaintsDay {
			get {
				if (allSaintsDay == null) {
					allSaintsDay = new NthDayOfWeekAfterHolidayHoliday("All Saint's Day", 1, DayOfWeek.Saturday, 11, 31);
				}
				return allSaintsDay;
			}
		}
	}
}
