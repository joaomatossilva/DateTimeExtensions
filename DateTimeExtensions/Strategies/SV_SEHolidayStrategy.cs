using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class SV_SEHolidayStrategy : IHolidayStrategy {
		private readonly IList<Holiday> holidays;

		public SV_SEHolidayStrategy() {
			this.holidays = new List<Holiday>();
			holidays.Add(ChristianHolidays.NewYear);
			holidays.Add(ChristianHolidays.Epiphany);
			holidays.Add(ChristianHolidays.GoodFriday);
			holidays.Add(ChristianHolidays.Easter);
			holidays.Add(ChristianHolidays.EasterMonday);
			holidays.Add(GlobalHolidays.InternationalWorkersDay);
			holidays.Add(ChristianHolidays.Ascension);
			holidays.Add(ChristianHolidays.Pentecost);
			holidays.Add(NationalDay);
			holidays.Add(GlobalHolidays.MidsummerDay);
			holidays.Add(ChristianHolidays.AllSaints);
			holidays.Add(ChristianHolidays.Christmas);
			holidays.Add(GlobalHolidays.BoxingDay);
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
		
		private static Holiday nationalDay;
		public static Holiday NationalDay {
			get{
				if (nationalDay == null) {
					nationalDay = new FixedHoliday("National Day", 6, 6);
				}
				return nationalDay;
			}
		}
	}
}
