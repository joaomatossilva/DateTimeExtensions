using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class NB_NOHolidayStrategy : IHolidayStrategy {
		private readonly IList<Holiday> holidays;

		public NB_NOHolidayStrategy() {
			this.holidays = new List<Holiday>();
			holidays.Add(ChristianHolidays.NewYear);
			holidays.Add(ChristianHolidays.MaundyThursday);
			holidays.Add(ChristianHolidays.GoodFriday);
			holidays.Add(ChristianHolidays.Easter);
			holidays.Add(ChristianHolidays.EasterMonday);
			holidays.Add(GlobalHolidays.InternationalWorkersDay);
			holidays.Add(ConstitutionDay);
			holidays.Add(ChristianHolidays.Ascension);
			holidays.Add(ChristianHolidays.Pentecost);
			holidays.Add(ChristianHolidays.PentecostMonday);
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
		
		private static Holiday constituionDay;
		public static Holiday ConstitutionDay {
			get{
				if (constituionDay == null) {
					constituionDay = new FixedHoliday("Constitution Day", 5, 17);
				}
				return constituionDay;
			}
		}
	}
}
