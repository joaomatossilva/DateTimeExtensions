using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	[Locale("nl-NL")]
	public class NL_NLHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public NL_NLHolidayStrategy() {			
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
			this.InnerHolidays.Add(ChristianHolidays.Easter);
			this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
			this.InnerHolidays.Add(LiberationDay);
			this.InnerHolidays.Add(ChristianHolidays.Ascension);
			this.InnerHolidays.Add(ChristianHolidays.Pentecost);
			this.InnerHolidays.Add(ChristianHolidays.PentecostMonday);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);
			this.InnerHolidays.Add(GlobalHolidays.BoxingDay);
		}

		//after 2000, Liberation Day only ocours 5 in 5 years
		private static Holiday liberationDay;
		public static Holiday LiberationDay {
			get{
				if (liberationDay == null) {
					liberationDay = new YearDependantHoliday(year => (year <= 2000 || year % 5 == 0) , new FixedHoliday("Liberation Day", 5, 5));
				}
				return liberationDay;
			}
		}
	}
}
