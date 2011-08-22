using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public interface IWorkingDayOfWeekStrategy {
		bool IsWorkingDay(DayOfWeek dayOfWeek);
	}
}
