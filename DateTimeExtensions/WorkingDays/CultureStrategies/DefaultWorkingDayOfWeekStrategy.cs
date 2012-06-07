using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	public class DefaultWorkingDayOfWeekStrategy : IWorkingDayOfWeekStrategy{

		public bool IsWorkingDay(DayOfWeek dayOfWeek) {
			if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday) {
				return false;
			}
			return true;
		}

	}
}
