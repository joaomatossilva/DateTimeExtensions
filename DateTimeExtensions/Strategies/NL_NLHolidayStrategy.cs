using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class NL_NLHolidayStrategy : IHolidayStrategy {
		private readonly IList<Holiday> holidays;


		public NL_NLHolidayStrategy() {
			this.holidays = new List<Holiday>();
			holidays.Add(ChristianHolidays.NewYear);
			holidays.Add(ChristianHolidays.GoodFriday);
			holidays.Add(ChristianHolidays.Easter);
			holidays.Add(ChristianHolidays.EasterMonday);
			holidays.Add(LiberationDay);
			holidays.Add(ChristianHolidays.Pentecost);
			holidays.Add(ChristianHolidays.PentecostMonday);
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

		//after 2000, Liberation Day only ocours 5 in 5 years
		private static Holiday liberationDay;
		public static Holiday LiberationDay {
			get{
				if (liberationDay == null) {
					liberationDay = new YearDependantHoliday(year => (year <= 2000 || year % 5 == 0) , new FixedHoliday("Liberation Day", 5, 5));
				}
				return liberationDay;
			}
		}
	}
}
