using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class DefaultHolidayStrategy : IHolidayStrategy {
		IEnumerable<Holiday> holidays;

		public DefaultHolidayStrategy() {
			this.holidays = new List<Holiday>();
		}

		public bool IsHoliDay(DateTime day) {
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
	}
}
