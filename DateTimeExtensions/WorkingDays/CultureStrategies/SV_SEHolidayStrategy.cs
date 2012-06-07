using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	[Locale("sv-SE")]
	public class SV_SEHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public SV_SEHolidayStrategy() {
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.Epiphany);
			this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
			this.InnerHolidays.Add(ChristianHolidays.Easter);
			this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
			this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
			this.InnerHolidays.Add(ChristianHolidays.Ascension);
			this.InnerHolidays.Add(ChristianHolidays.Pentecost);
			this.InnerHolidays.Add(NationalDay);
			this.InnerHolidays.Add(GlobalHolidays.MidsummerDay);
			this.InnerHolidays.Add(ChristianHolidays.AllSaints);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);
			this.InnerHolidays.Add(GlobalHolidays.BoxingDay);
		}
		
		private static Holiday nationalDay;
		public static Holiday NationalDay {
			get{
				if (nationalDay == null) {
					nationalDay = new FixedHoliday("National Day", 6, 6);
				}
				return nationalDay;
			}
		}
	}
}
