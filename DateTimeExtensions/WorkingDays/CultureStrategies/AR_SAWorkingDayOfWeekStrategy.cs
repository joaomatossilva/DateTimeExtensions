using System;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	public class AR_SAWorkingDayOfWeekStrategy : IWorkingDayOfWeekStrategy {

		public bool IsWorkingDay(DayOfWeek dayOfWeek) {
			if (dayOfWeek == DayOfWeek.Thursday || dayOfWeek == DayOfWeek.Friday) {
				return false;
			}
			return true;
		}

	}
}
