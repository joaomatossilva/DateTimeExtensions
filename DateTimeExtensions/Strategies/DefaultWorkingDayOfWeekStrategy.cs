using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class DefaultWorkingDayOfWeekStrategy : IWorkingDayOfWeekStrategy{

		public bool IsWorkingDay(DayOfWeek dayOfWeek) {
			if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday) {
				return false;
			}
			return true;
		}

	}
}
