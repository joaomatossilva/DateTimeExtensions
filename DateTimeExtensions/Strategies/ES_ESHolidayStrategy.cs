using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class ES_ESHolidayStrategy : IHolidayStrategy {
		IList<Holiday> holidays;


		public ES_ESHolidayStrategy() {
			this.holidays = new List<Holiday>();
			holidays.Add(ChristianHolidays.NewYear);
			holidays.Add(ChristianHolidays.Epiphany);
			holidays.Add(ChristianHolidays.GoodFriday);
			holidays.Add(ChristianHolidays.ImaculateConception);
			holidays.Add(ChristianHolidays.Assumption);
			holidays.Add(ChristianHolidays.AllSaints);
			holidays.Add(ChristianHolidays.Christmas);

			holidays.Add(GlobalHolidays.InternationalWorkersDay);
			holidays.Add(NationalDay);
			holidays.Add(ConstitutionDay);
		}

		public bool IsHoliDay(DateTime day) {
			var isHoliday = holidays.Where(h => h.IsInstanceOf(day)).SingleOrDefault();
			if (isHoliday != null) {
				return true;
			}

			// If day is a monday, check if previous sunday is an holiday
			if (day.DayOfWeek == DayOfWeek.Monday)
				return IsHoliDay(day.AddDays(-1));

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

		private static Holiday nationalDay;
		public static Holiday NationalDay {
			get {
				if (nationalDay == null) {
					nationalDay = new FixedHoliday("National Day", 10, 12);
				}
				return nationalDay;
			}
		}

		private static Holiday constitutionDay;
		public static Holiday ConstitutionDay {
			get {
				if (constitutionDay == null) {
					constitutionDay = new FixedHoliday("Constitution Day", 12, 6);
				}
				return constitutionDay;
			}
		}
	}
}
