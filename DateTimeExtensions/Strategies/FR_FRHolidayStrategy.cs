using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class FR_FRHolidayStrategy : IHolidayStrategy {
		IList<Holiday> holidays;


		public FR_FRHolidayStrategy() {
			this.holidays = new List<Holiday>();
			holidays.Add(ChristianHolidays.NewYear);
			holidays.Add(ChristianHolidays.EasterMonday);
			holidays.Add(ChristianHolidays.Ascension);
			holidays.Add(ChristianHolidays.AllSaints);
			holidays.Add(ChristianHolidays.Christmas);

			holidays.Add(GlobalHolidays.InternationalWorkersDay);
			holidays.Add(GlobalHolidays.VeteransDay);
			holidays.Add(VictoryInEuropeDay);
			holidays.Add(BastilleDay);
			holidays.Add(StEtienne);
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

		private static Holiday victoryInEuropeDay;
		public static Holiday VictoryInEuropeDay {
			get {
				if (victoryInEuropeDay == null) {
					victoryInEuropeDay = new FixedHoliday("Victory in Europe Day", 5, 8);
				}
				return victoryInEuropeDay;
			}
		}

		private static Holiday bastilleDay;
		public static Holiday BastilleDay {
			get {
				if (bastilleDay == null) {
					bastilleDay = new FixedHoliday("Bastille Day", 7, 14);
				}
				return bastilleDay;
			}
		}

		private static Holiday stEtienne;
		public static Holiday StEtienne {
			get {
				if (stEtienne == null) {
					stEtienne = new FixedHoliday("St Etienne", 12, 26);
				}
				return stEtienne;
			}
		}
	}
}
