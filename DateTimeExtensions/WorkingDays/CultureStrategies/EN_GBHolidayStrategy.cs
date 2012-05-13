using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	[Locale("en-GB")]
	public class EN_GBHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public EN_GBHolidayStrategy() {
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
			this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);
			
			this.InnerHolidays.Add(GlobalHolidays.StPatricsDay);
			this.InnerHolidays.Add(GlobalHolidays.BoxingDay);
			this.InnerHolidays.Add(MayDayBank);
			this.InnerHolidays.Add(SpringBank);
			this.InnerHolidays.Add(LateSummerBank);
		}

		private static Holiday boxingDay;
		public static Holiday BoxingDay {
			get {
				if (boxingDay == null) {
					boxingDay = new FixedHoliday("Boxing Day", 12, 26);
				}
				return boxingDay;
			}
		}

		//1st Monday in May	- May Day Bank Holiday
		private static Holiday mayDayBank;
		public static Holiday MayDayBank {
			get {
				if (mayDayBank == null) {
					mayDayBank = new NthDayOfWeekInMonthHoliday("May Day Bank", 1, DayOfWeek.Monday, 5, CountDirection.FromFirst);
				}
				return mayDayBank;
			}
		}

		//Last Monday in May - Spring Bank Holiday
		private static Holiday springBank;
		public static Holiday SpringBank {
			get {
				if (springBank == null) {
					springBank = new NthDayOfWeekInMonthHoliday("Spring Bank", 1, DayOfWeek.Monday, 5, CountDirection.FromLast);
				}
				return springBank;
			}
		}

		//Last Monday in August	- Late Summer Bank Holiday
		private static Holiday lateSummerBank;
		public static Holiday LateSummerBank {
			get {
				if (lateSummerBank == null) {
					lateSummerBank = new NthDayOfWeekInMonthHoliday("Late Summer Bank", 1, DayOfWeek.Monday, 8, CountDirection.FromLast);
				}
				return lateSummerBank;
			}
		}
	}
}
