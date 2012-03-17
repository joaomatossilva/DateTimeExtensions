using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class DA_DLHolidayStrategy : IHolidayStrategy {
		private readonly IList<Holiday> holidays;

		public DA_DLHolidayStrategy() {
			this.holidays = new List<Holiday>();
			holidays.Add(ChristianHolidays.NewYear);
			holidays.Add(ChristianHolidays.MaundyThursday);
			holidays.Add(ChristianHolidays.GoodFriday);
			holidays.Add(ChristianHolidays.Easter);
			holidays.Add(ChristianHolidays.EasterMonday);
			holidays.Add(GeneralPrayerDay);
			holidays.Add(ChristianHolidays.Ascension);
			holidays.Add(ChristianHolidays.Pentecost);
			holidays.Add(ChristianHolidays.PentecostMonday);
			holidays.Add(ChristianHolidays.Christmas);
			holidays.Add(SecondDayOfChristmas);
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
		
		private static Holiday secondDayOfChristmas;
		public static Holiday SecondDayOfChristmas {
			get{
				if (secondDayOfChristmas == null) {
					secondDayOfChristmas = new FixedHoliday("Christmas (2nd Day)", 12, 26);
				}
				return secondDayOfChristmas;
			}
		}

		//source: http://en.wikipedia.org/wiki/Store_Bededag
		// Store Bededag, translated literally as Great Prayer Day or more loosely as General Prayer Day, "All Prayers" Day, Great Day of Prayers or Common Prayer Day,
		//is a Danish holiday celebrated on the 4th Friday after Easter
		private static Holiday generalPrayerDay;
		public static Holiday GeneralPrayerDay {
			get {
				if (generalPrayerDay == null) {
					generalPrayerDay = new NthDayOfWeekAfterHolidayHoliday("General Prayer Day", 4, DayOfWeek.Friday, ChristianHolidays.Easter);
				}
				return generalPrayerDay;
			}
		}
	}
}
