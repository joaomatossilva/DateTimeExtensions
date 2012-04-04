using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public abstract class HolidayStrategyBase : IHolidayStrategy {
		protected IList<Holiday> InnerHolidays;

		protected HolidayStrategyBase() {
			this.InnerHolidays = new List<Holiday>();
		}

		public virtual bool IsHoliDay(DateTime day) {
			var isHoliday = this.InnerHolidays.SingleOrDefault(h => h.IsInstanceOf(day));
			if (isHoliday != null) {
				return true;
			}
			return false;
		}

		public virtual IEnumerable<Holiday> Holidays {
			get {
				var currentYear = DateTime.Now.Year;
				return this.GetHolidaysOfYear(currentYear);
			}
		}

		public virtual IEnumerable<Holiday> GetHolidaysOfYear(int year) {
			return this.InnerHolidays.Where(h => h.GetInstance(year).HasValue);
		}
	}
}
