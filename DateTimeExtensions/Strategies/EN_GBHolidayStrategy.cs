using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class EN_GBHolidayStrategy : IHolidayStrategy {
		private IHolidayStrategy decoratedInstance;
		IList<DayInYear> fixedNationalHolidays;
		private IDictionary<int, IList<DayInYear>> mobileNationalHolidaysPerYear;


		public EN_GBHolidayStrategy() {
			var christianHolidays = 
				ChristianHoliday.NewYear |
				ChristianHoliday.GoodFriday |
				ChristianHoliday.EasterMonday |
				ChristianHoliday.Christmas;
			this.decoratedInstance = new ChristianHolidayStrategy(christianHolidays);
			this.fixedNationalHolidays = new List<DayInYear>();
			this.mobileNationalHolidaysPerYear = new Dictionary<int, IList<DayInYear>>();

			fixedNationalHolidays.Add(new DayInYear { Day = 17, Month = 3 });	//St. Patric's Day
			fixedNationalHolidays.Add(new DayInYear { Day = 26, Month = 12 });	//Boxing Day
		}

		public bool IsHoliDay(DateTime day) {
			if (decoratedInstance.IsHoliDay(day)) {
				return true;
			}
			var isFixedHoliday = fixedNationalHolidays.Where(h => h.Day == day.Day && h.Month == day.Month).SingleOrDefault();
			if (isFixedHoliday != null) {
				return true;
			}

			if(!mobileNationalHolidaysPerYear.ContainsKey(day.Year)){
				CalculateMobileHolidays(day.Year);
			}
			var mobileHolidaysInYear = mobileNationalHolidaysPerYear[day.Year];
			var isMobileHoliday = mobileHolidaysInYear.Where(h => h.Day == day.Day && h.Month == day.Month).SingleOrDefault();
			if (isMobileHoliday != null) {
				return true;
			}

			return false;
		}

		private void CalculateMobileHolidays(int year) {
			var mobileHolidaysInYear = new List<DayInYear>();
			//1st Monday in May	- May Day Bank Holiday
			var aDayInMay = new DateTime(year, 5, 1);
			var mayDayBank = aDayInMay.FirstDayOfWeekOfTheMonth(DayOfWeek.Monday);
			mobileHolidaysInYear.Add(new DayInYear { Day = mayDayBank.Day, Month = mayDayBank.Month });
			//Last Monday in May - Spring Bank Holiday
			var springBank = aDayInMay.LastDayOfWeekOfTheMonth(DayOfWeek.Monday);
			mobileHolidaysInYear.Add(new DayInYear { Day = springBank.Day, Month = springBank.Month });

			//Last Monday in August	- Late Summer Bank Holiday
			var aDayInAugust = new DateTime(year, 8, 1);
			var laateSummer = aDayInAugust.LastDayOfWeekOfTheMonth(DayOfWeek.Monday);
			mobileHolidaysInYear.Add(new DayInYear { Day = laateSummer.Day, Month = laateSummer.Month });

			mobileNationalHolidaysPerYear.Add(year, mobileHolidaysInYear);
		}

	}
}
