using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public interface IHolidayStrategy {
		IEnumerable<Holiday> Holidays { get; }
		bool IsHoliDay(DateTime day);
	}
}
