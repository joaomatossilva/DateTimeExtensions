using System;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	[Locale("ar-SA")]
	public class AR_SAWorkingDayOfWeekStrategy : IWorkingDayOfWeekStrategy {

		public bool IsWorkingDay(DayOfWeek dayOfWeek) {
			if (dayOfWeek == DayOfWeek.Thursday || dayOfWeek == DayOfWeek.Friday) {
				return false;
			}
			return true;
		}

	}
}
