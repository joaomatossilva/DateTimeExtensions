using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class ES_ESHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public ES_ESHolidayStrategy() {
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.Epiphany);
			this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
			this.InnerHolidays.Add(ChristianHolidays.ImaculateConception);
			this.InnerHolidays.Add(ChristianHolidays.Assumption);
			this.InnerHolidays.Add(ChristianHolidays.AllSaints);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);

			this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
			this.InnerHolidays.Add(NationalDay);
			this.InnerHolidays.Add(ConstitutionDay);
		}

		public override bool IsHoliDay(DateTime day) {
			var isHoliday = this.InnerHolidays.Where(h => h.IsInstanceOf(day)).SingleOrDefault();
			if (isHoliday != null) {
				return true;
			}

			// If day is a monday, check if previous sunday is an holiday
			if (day.DayOfWeek == DayOfWeek.Monday)
				return IsHoliDay(day.AddDays(-1));

			return false;
		}

		private static Holiday nationalDay;
		public static Holiday NationalDay {
			get {
				if (nationalDay == null) {
					nationalDay = new FixedHoliday("National Day", 10, 12);
				}
				return nationalDay;
			}
		}

		private static Holiday constitutionDay;
		public static Holiday ConstitutionDay {
			get {
				if (constitutionDay == null) {
					constitutionDay = new FixedHoliday("Constitution Day", 12, 6);
				}
				return constitutionDay;
			}
		}
	}
}
