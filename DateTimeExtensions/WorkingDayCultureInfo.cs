using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

using DateTimeExtensions.Strategies;

namespace DateTimeExtensions {

	public class WorkingDayCultureInfo : IWorkingDayCultureInfo {
		private string name;
		private IWorkingDayOfWeekStrategy workingDayOfWeekStrategy;
		private IHolidayStrategy holidayStrategy;

		public WorkingDayCultureInfo() : this(CultureInfo.CurrentCulture.Name) { 
		}

		public WorkingDayCultureInfo(string name) {
			this.name = name;
			this.LocateWorkingDayOfWeekStrategy = HolidayStrategyLocatorByName.LocateDayOfWeekStrategyForName;
			this.LocateHolidayStrategy = HolidayStrategyLocatorByName.LocateHolidayStrategyForName;
		}

		public bool IsWorkingDay(DateTime date){
			if (!this.workingDayOfWeekStrategy.IsWorkingDay(date.DayOfWeek))
				return false;
			return !holidayStrategy.IsHoliDay(date);
		}

		public bool IsWorkingDay(DayOfWeek dayOfWeek){
			return this.workingDayOfWeekStrategy.IsWorkingDay(dayOfWeek);
		}

		public IEnumerable<Holiday> Holidays {
			get {
				return this.holidayStrategy.Holidays;
			} 
		}

		public string Name { 
			get{
				return name;
			} 
		}

		private Func<string, IWorkingDayOfWeekStrategy> locateWorkingDayOfWeekStrategy;
		public Func<string, IWorkingDayOfWeekStrategy> LocateWorkingDayOfWeekStrategy {
			get { return locateWorkingDayOfWeekStrategy; }
			set {
				if (value != null) {
					locateWorkingDayOfWeekStrategy = value;
					workingDayOfWeekStrategy = locateWorkingDayOfWeekStrategy(name);
				} else {
					throw new ArgumentNullException("value");
				}
			}
		}

		private Func<string, IHolidayStrategy> locateHolidayWeekStrategy;
		public Func<string, IHolidayStrategy> LocateHolidayStrategy {
			get { return locateHolidayWeekStrategy; }
			set {
				if (value != null) {
					locateHolidayWeekStrategy = value;
					holidayStrategy = locateHolidayWeekStrategy(name);
				} else {
					throw new ArgumentNullException("value");
				}
			}
		}
	}
}
