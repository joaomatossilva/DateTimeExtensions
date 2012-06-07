using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.WorkingDays {
	public interface IHolidayStrategy {
		IEnumerable<Holiday> Holidays { get; }
		IEnumerable<Holiday> GetHolidaysOfYear(int year);
		bool IsHoliDay(DateTime day);
	}
}
