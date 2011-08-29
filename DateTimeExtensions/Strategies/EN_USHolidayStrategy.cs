using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class EN_USHolidayStrategy : IHolidayStrategy {
		IList<Holiday> holidays;

		public EN_USHolidayStrategy() {
			this.holidays = new List<Holiday>();
			/*
			var christianHolidays = 
				ChristianHoliday.NewYear |
				ChristianHoliday.Christmas;
			this.decoratedInstance = new ChristianHolidayStrategy(christianHolidays);
			this.fixedNationalHolidays = new List<DayInYear>();
			this.mobileNationalHolidaysPerYear = new Dictionary<int, IList<DayInYear>>();

			fixedNationalHolidays.Add(new DayInYear { Day = 4, Month = 7 });	//Independence Day
			fixedNationalHolidays.Add(new DayInYear { Day = 11, Month = 11 });	//Veterans Day
			 * */
		}

		public bool IsHoliDay(DateTime day) {
			var isHoliday = holidays.Where(h => h.IsInstanceOf(day)).SingleOrDefault();
			if (isHoliday != null) {
				return true;
			}
			
			// If day is a monday, check if previous sunday is an holiday
			if (day.DayOfWeek == DayOfWeek.Monday)
				return IsHoliDay(day.AddDays(-1));

			// If day is a friday, check if nex saturday is an holiday
			if (day.DayOfWeek == DayOfWeek.Friday)
				return IsHoliDay(day.AddDays(1));

			return false;
		}

		public IEnumerable<Holiday> Holidays {
			get {
				return holidays;
			}
		}

		/*
		private void CalculateMobileHolidays(int year) {
			var mobileHolidaysInYear = new List<DayInYear>();

			//Third Monday in January - Birthday of Martin Luther King, Jr.
			var firstJanuary = new DateTime(year, 1, 1);
			var martinLutherDay = firstJanuary.FirstDayOfWeekOfTheMonth(DayOfWeek.Monday).AddDays(7);
			mobileHolidaysInYear.Add(new DayInYear { Day = martinLutherDay.Day, Month = martinLutherDay.Month });

			//Inauguration Day
			//First January 20th following a Presidential election

			//Third Monday in February - Washington's Birthday
			var firstFebruary = new DateTime(year, 2, 1);
			var washingtonBirthday = firstFebruary.FirstDayOfWeekOfTheMonth(DayOfWeek.Monday).AddDays(14);
			mobileHolidaysInYear.Add(new DayInYear { Day = washingtonBirthday.Day, Month = washingtonBirthday.Month });

			//Last Monday in May - Memorial Day
			var aDayInMay = new DateTime(year, 5,1);
			var memorialDay = aDayInMay.LastDayOfWeekOfTheMonth(DayOfWeek.Monday);
			mobileHolidaysInYear.Add(new DayInYear { Day = memorialDay.Day, Month = memorialDay.Month });

			//First Monday in September - Labor Day
			var aDayInSeptember = new DateTime(year, 9, 1);
			var laborDay = aDayInSeptember.FirstDayOfWeekOfTheMonth(DayOfWeek.Monday);
			mobileHolidaysInYear.Add(new DayInYear { Day = laborDay.Day, Month = laborDay.Month });

			//Second Monday in October - Columbus Day
			var firstOctober = new DateTime(year, 10, 1);
			var columbusDay = firstOctober.FirstDayOfWeekOfTheMonth(DayOfWeek.Monday).AddDays(7);
			mobileHolidaysInYear.Add(new DayInYear { Day = columbusDay.Day, Month = columbusDay.Month });

			//Fourth Thursday in November - Thanksgiving Day
			var firstNovember = new DateTime(year, 11, 1);
			var thanksgivingDay = firstNovember.FirstDayOfWeekOfTheMonth(DayOfWeek.Monday).AddDays(21);
			mobileHolidaysInYear.Add(new DayInYear { Day = thanksgivingDay.Day, Month = thanksgivingDay.Month });

			mobileNationalHolidaysPerYear.Add(year, mobileHolidaysInYear);
		}
		*/
	}
}
