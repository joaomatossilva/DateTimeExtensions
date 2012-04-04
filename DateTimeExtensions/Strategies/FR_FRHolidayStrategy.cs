using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class FR_FRHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public FR_FRHolidayStrategy() {
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
			this.InnerHolidays.Add(ChristianHolidays.Ascension);
			this.InnerHolidays.Add(ChristianHolidays.AllSaints);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);

			this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
			this.InnerHolidays.Add(GlobalHolidays.VeteransDay);
			this.InnerHolidays.Add(VictoryInEuropeDay);
			this.InnerHolidays.Add(BastilleDay);
			this.InnerHolidays.Add(StEtienne);
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
