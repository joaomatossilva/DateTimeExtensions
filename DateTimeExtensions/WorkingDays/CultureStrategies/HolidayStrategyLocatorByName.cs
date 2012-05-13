using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	public class HolidayStrategyLocatorByName {

		public static IHolidayStrategy LocateHolidayStrategyForName(string name) {
			return LocaleImplementationLocator.FindImplementationOf<IHolidayStrategy>(name) ?? new DefaultHolidayStrategy();
		}

		public static IWorkingDayOfWeekStrategy LocateDayOfWeekStrategyForName(string name) {
			return LocaleImplementationLocator.FindImplementationOf<IWorkingDayOfWeekStrategy>(name) ?? new DefaultWorkingDayOfWeekStrategy();
		}		
	}
}
