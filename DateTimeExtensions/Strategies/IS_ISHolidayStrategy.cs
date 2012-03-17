using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class IS_ISHolidayStrategy : IHolidayStrategy {
		private readonly IList<Holiday> holidays;

		public IS_ISHolidayStrategy() {
			this.holidays = new List<Holiday>();
			holidays.Add(ChristianHolidays.NewYear);
			holidays.Add(ChristianHolidays.PalmSunday);
			holidays.Add(ChristianHolidays.MaundyThursday);
			holidays.Add(ChristianHolidays.GoodFriday);
			holidays.Add(ChristianHolidays.Easter);
			holidays.Add(ChristianHolidays.EasterMonday);
			holidays.Add(FirstDayOfSummer);
			holidays.Add(GlobalHolidays.MayDay);
			holidays.Add(ChristianHolidays.Ascension);
			holidays.Add(ChristianHolidays.Pentecost);
			holidays.Add(ChristianHolidays.PentecostMonday);
			holidays.Add(SeamensDay);
			holidays.Add(RepublicsDay);
			holidays.Add(CommerceDay);
			//Christmas Eve is usually half holiday observance
			holidays.Add(ChristianHolidays.Christmas);
			holidays.Add(SecondDayOfChristmas);
			//New Year's Eve is usually half holiday observance
		}

		public bool IsHoliDay(DateTime day) {
			var isHoliday = this.holidays.SingleOrDefault(h => h.IsInstanceOf(day));
			return isHoliday != null;
		}

		public IEnumerable<Holiday> Holidays {
			get {
				var currentYear = DateTime.Now.Year;
				return this.GetHolidaysOfYear(currentYear);
			}
		}

		public IEnumerable<Holiday> GetHolidaysOfYear(int year) {
			return holidays.Where(h => h.GetInstance(year).HasValue);
		}
		
		private static Holiday republicsDay;
		public static Holiday RepublicsDay {
			get{
				if (republicsDay == null) {
					republicsDay = new FixedHoliday("Republic's Day", 6, 17);
				}
				return republicsDay;
			}
		}

		//Commerce Day - First Monday of August
		private static Holiday commerceDay;
		public static Holiday CommerceDay {
			get {
				if (commerceDay == null) {
					commerceDay = new NthDayOfWeekInMonthHoliday("Commerce's Day", 1, DayOfWeek.Monday, 8, CountDirection.FromFirst);
				}
				return commerceDay;
			}
		}

		//The Seamen's Day - First Sunday of June
		private static Holiday seamensDay;
		public static Holiday SeamensDay {
			get {
				if (seamensDay == null) {
					seamensDay = new NthDayOfWeekInMonthHoliday("The Seamen's Day", 1, DayOfWeek.Sunday, 6, CountDirection.FromFirst);
				}
				return commerceDay;
			}
		}

		//First Day of Summer - First Thursday after 18 April
		private static Holiday firstDayOfSummer;
		public static Holiday FirstDayOfSummer {
			get {
				if (firstDayOfSummer == null) {
					//could not find any strong reference of the designated day of 18 April is inclusive or not
					// if it is, then we should change it to 17 April, since NthDayOfWeekAfterHolidayHoliday don't count with the current day
					firstDayOfSummer = new NthDayOfWeekAfterHolidayHoliday("First Day of Summer", 1, DayOfWeek.Thursday, 4, 18);
				}
				return firstDayOfSummer;
			}
		}

		private static Holiday secondDayOfChristmas;
		public static Holiday SecondDayOfChristmas {
			get {
				if (secondDayOfChristmas == null) {
					secondDayOfChristmas = new FixedHoliday("Christmas (2nd Day)", 12, 26);
				}
				return secondDayOfChristmas;
			}
		}

	}
}
