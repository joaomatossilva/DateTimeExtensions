using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class DE_DEHolidayStrategy : IHolidayStrategy {
		IList<Holiday> holidays;


		public DE_DEHolidayStrategy() {
			this.holidays = new List<Holiday>();
			holidays.Add(ChristianHolidays.NewYear);
			holidays.Add(ChristianHolidays.GoodFriday);
			holidays.Add(ChristianHolidays.EasterMonday);
			holidays.Add(ChristianHolidays.Ascension);
			holidays.Add(ChristianHolidays.Pentecost);
			holidays.Add(ChristianHolidays.Christmas);

			holidays.Add(GlobalHolidays.InternationalWorkersDay);
			holidays.Add(GermanUnityDay);
			holidays.Add(StStephensDay);
		}

		public bool IsHoliDay(DateTime day) {
			var isHoliday = holidays.Where(h => h.IsInstanceOf(day)).SingleOrDefault();
			if (isHoliday != null) {
				return true;
			}
			return false;
		}

		public IEnumerable<Holiday> Holidays {
			get {
				return holidays;
			}
		}

		private static Holiday germanUnityDay;
		public static Holiday GermanUnityDay {
			get {
				if (germanUnityDay == null) {
					germanUnityDay = new FixedHoliday("German Unity Day", 10, 3);
				}
				return germanUnityDay;
			}
		}

		private static Holiday stStephensDay;
		public static Holiday StStephensDay {
			get {
				if (stStephensDay == null) {
					stStephensDay = new FixedHoliday("St Stephen's Day", 12, 26);
				}
				return stStephensDay;
			}
		}
	}
}
