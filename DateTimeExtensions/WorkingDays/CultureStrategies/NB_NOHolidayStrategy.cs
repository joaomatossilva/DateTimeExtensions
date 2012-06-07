using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	[Locale("nb-NO")]
	public class NB_NOHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public NB_NOHolidayStrategy() {
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.MaundyThursday);
			this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
			this.InnerHolidays.Add(ChristianHolidays.Easter);
			this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
			this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
			this.InnerHolidays.Add(ConstitutionDay);
			this.InnerHolidays.Add(ChristianHolidays.Ascension);
			this.InnerHolidays.Add(ChristianHolidays.Pentecost);
			this.InnerHolidays.Add(ChristianHolidays.PentecostMonday);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);
			this.InnerHolidays.Add(ChristianHolidays.StStephansDay);
		}

		private static Holiday constituionDay;
		public static Holiday ConstitutionDay {
			get{
				if (constituionDay == null) {
					constituionDay = new FixedHoliday("Constitution Day", 5, 17);
				}
				return constituionDay;
			}
		}
	}
}
