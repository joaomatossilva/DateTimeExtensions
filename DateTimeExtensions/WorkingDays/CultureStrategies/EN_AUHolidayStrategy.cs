using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	[Locale("en-AU")]
	public class EN_AUHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public EN_AUHolidayStrategy() {
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(AustraliaDay);
			this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
			this.InnerHolidays.Add(ChristianHolidays.EasterSaturday);
			this.InnerHolidays.Add(ChristianHolidays.Easter);
			this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
			this.InnerHolidays.Add(AnzacDay);
			this.InnerHolidays.Add(QueensBirthday);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);
			this.InnerHolidays.Add(GlobalHolidays.BoxingDay);
			this.InnerHolidays.Add(GlobalHolidays.NewYearsEve);
		}

		public override IDictionary<DateTime, Holiday> BuildObservancesMap(int year) {
			IDictionary<DateTime, Holiday> holidayMap = new Dictionary<DateTime, Holiday>();
			foreach (var innerHoliday in InnerHolidays) {
				var date = innerHoliday.GetInstance(year);
				if (date.HasValue) {
					holidayMap.Add(date.Value, innerHoliday);
					//don't move the holiday if it is easter based since it's already observated
					if (innerHoliday.GetType() != typeof(EasterBasedHoliday)) {
						//if the holiday is a saturday, the holiday is observed on next monday
						if (date.Value.DayOfWeek == DayOfWeek.Saturday) {
							holidayMap.Add(date.Value.AddDays(2), innerHoliday);
						}
						//if the holiday is a sunday, the holiday is observed on next monday
						if (date.Value.DayOfWeek == DayOfWeek.Sunday) {
							holidayMap.Add(date.Value.AddDays(1), innerHoliday);
						}
					}
				}
			}
			return holidayMap;
		}


		//Last Monday in May - Spring Bank Holiday
		private static Holiday australiaDay;
		public static Holiday AustraliaDay {
			get {
				if (australiaDay == null) {
					australiaDay = new FixedHoliday("Australia Day", 1, 26);
				}
				return australiaDay;
			}
		}

		//1st Monday in May	- May Day Bank Holiday (not an national holiday, but observed on some regions)
		private static Holiday mayDay;
		public static Holiday MayDay {
			get {
				if (mayDay == null) {
					mayDay = new NthDayOfWeekInMonthHoliday("May Day", 1, DayOfWeek.Monday, 5, CountDirection.FromFirst);
				}
				return mayDay;
			}
		}

		//25th April - Anzac Day
		private static Holiday anzacDay;
		public static Holiday AnzacDay {
			get {
				if (anzacDay == null) {
					anzacDay = new FixedHoliday("Anzac Day", 4, 25);
				}
				return anzacDay;
			}
		}

		//2nd Monday in June - Queen's Birthday
		private static Holiday queensBirthday;
		public static Holiday QueensBirthday {
			get {
				if (queensBirthday == null) {
					queensBirthday = new NthDayOfWeekInMonthHoliday("Queen's Birthday", 2, DayOfWeek.Monday, 6, CountDirection.FromFirst);
				}
				return queensBirthday;
			}
		}
	}
}
