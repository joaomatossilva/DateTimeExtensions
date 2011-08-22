using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class DefaultHolidayStrategy : IHolidayStrategy {

		public bool IsHoliDay(DateTime day) {
			return false;
		}

	}
}
