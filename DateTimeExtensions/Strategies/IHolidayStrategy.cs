using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public interface IHolidayStrategy {
		bool IsHoliDay(DateTime day);
	}
}
