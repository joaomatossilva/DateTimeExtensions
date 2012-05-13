using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	[Locale("it-IT")]
	public class IT_ITHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public IT_ITHolidayStrategy() {
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.Epiphany);
			this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
			this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
			this.InnerHolidays.Add(RepublicDay);
			this.InnerHolidays.Add(ChristianHolidays.Assumption);
			this.InnerHolidays.Add(ChristianHolidays.AllSaints);
			this.InnerHolidays.Add(ChristianHolidays.ImaculateConception);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);
			this.InnerHolidays.Add(ChristianHolidays.StStephansDay);
		}

		//2 June - Republic Day
		private static Holiday republicDay;
		public static Holiday RepublicDay {
			get {
				if (republicDay == null) {
					republicDay = new FixedHoliday("Republic Day", 6, 2);
				}
				return republicDay;
			}
		}
	}
}
