using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	[Locale("de-DE")]
	public class DE_DEHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public DE_DEHolidayStrategy() {
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
			this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
			this.InnerHolidays.Add(ChristianHolidays.Ascension);
			this.InnerHolidays.Add(ChristianHolidays.Pentecost);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);

			this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
			this.InnerHolidays.Add(GermanUnityDay);
			this.InnerHolidays.Add(ChristianHolidays.StStephansDay);
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
	}
}
