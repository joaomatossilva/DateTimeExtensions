using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

using DateTimeExtensions.Strategies;

namespace DateTimeExtensions {

	public class DateTimeCultureInfo : IWorkingDayCultureInfo, INaturalTextCultureInfo {
		private string name;
		private IWorkingDayOfWeekStrategy workingDayOfWeekStrategy;
		private IHolidayStrategy holidayStrategy;
		private INaturalTimeStrategy naturalTimeStrategy;

		public DateTimeCultureInfo() : this(CultureInfo.CurrentCulture.Name) { 
		}

		public DateTimeCultureInfo(string name) {
			this.name = name;
			this.LocateNaturalTimeStrategy = HolidayStrategyLocatorByName.LocateNaturalTimeStrategyForName;
			this.LocateWorkingDayOfWeekStrategy = HolidayStrategyLocatorByName.LocateDayOfWeekStrategyForName;
			this.LocateHolidayStrategy = HolidayStrategyLocatorByName.LocateHolidayStrategyForName;
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

		public string ToNaturalText(DateDiff span, bool round) {
			return naturalTimeStrategy.ToNaturalText(span, round);
		}

		public string ToExactNaturalText(DateDiff span) {
			return naturalTimeStrategy.ToExactNaturalText(span);
		}

		private Func<string, INaturalTimeStrategy> locateNaturalTimeStrategy;
		public Func<string, INaturalTimeStrategy> LocateNaturalTimeStrategy {
			get { return locateNaturalTimeStrategy; }
			set {
				if (value != null) {
					locateNaturalTimeStrategy = value;
					naturalTimeStrategy = locateNaturalTimeStrategy(name);
				} else {
					throw new ArgumentNullException("value");
				}
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
