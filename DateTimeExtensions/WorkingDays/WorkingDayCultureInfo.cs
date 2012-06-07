using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays.CultureStrategies;

namespace DateTimeExtensions.WorkingDays {

	public class WorkingDayCultureInfo : IWorkingDayCultureInfo {
		private string name;
		private IWorkingDayOfWeekStrategy workingDayOfWeekStrategy;
		private IHolidayStrategy holidayStrategy;

		public WorkingDayCultureInfo() : this(CultureInfo.CurrentCulture.Name) { 
		}

		public WorkingDayCultureInfo(string name) {
			this.name = name;
			this.LocateWorkingDayOfWeekStrategy = DefaultLocateWorkingDayOfWeekStrategy;
			this.LocateHolidayStrategy = DefaultLocateHolidayStrategy;
		}

		public bool IsHoliday(DateTime date) {
			return holidayStrategy.IsHoliDay(date);
		}

		public bool IsWorkingDay(DateTime date){
			if (!this.workingDayOfWeekStrategy.IsWorkingDay(date.DayOfWeek))
				return false;
			return !IsHoliday(date);
		}

		public bool IsWorkingDay(DayOfWeek dayOfWeek){
			return this.workingDayOfWeekStrategy.IsWorkingDay(dayOfWeek);
		}

		public IEnumerable<Holiday> Holidays {
			get {
				return this.holidayStrategy.Holidays;
			} 
		}

		public IEnumerable<Holiday> GetHolidaysOfYear(int year) {
			return this.holidayStrategy.GetHolidaysOfYear(year);
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

		public static readonly Func<string, IHolidayStrategy> DefaultLocateHolidayStrategy =
			name => LocaleImplementationLocator.FindImplementationOf<IHolidayStrategy>(name) ?? new DefaultHolidayStrategy();

		public static readonly Func<string, IWorkingDayOfWeekStrategy> DefaultLocateWorkingDayOfWeekStrategy =
			name => LocaleImplementationLocator.FindImplementationOf<IWorkingDayOfWeekStrategy>(name) ?? new DefaultWorkingDayOfWeekStrategy();
	}
}
