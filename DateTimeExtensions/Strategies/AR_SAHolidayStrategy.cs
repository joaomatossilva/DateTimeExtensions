using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class AR_SAHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		private static readonly Calendar HirijiCalendar = new HijriCalendar();

		public AR_SAHolidayStrategy() {
			this.InnerHolidays.Add(EndOfRamadan);
			this.InnerHolidays.Add(EndOfHajj);
			this.InnerHolidays.Add(SaudiNationalDay);
		}

		public override bool IsHoliDay(DateTime day) {
			var holiday = this.InnerHolidays.Where(h => h.IsInstanceOf(day)).SingleOrDefault();
			if (holiday != null) {
				return true;
			}

			//TODO: Requires confirmation
			var endOfRamadanObservance = EndOfRamadan.GetInstance(day.Year);
			if (endOfRamadanObservance.HasValue && day > endOfRamadanObservance.Value && day <= endOfRamadanObservance.Value.AddDays(7)) {
				return true;
			}

			//TODO: Requires confirmation
			var endOfHajjendOfRamadanObservance = EndOfHajj.GetInstance(day.Year);
			if (endOfHajjendOfRamadanObservance.HasValue && day > endOfHajjendOfRamadanObservance.Value && day <= endOfHajjendOfRamadanObservance.Value.AddDays(6)) {
				return true;
			}

			return false;
		}

		//1 Shawwal
		private static Holiday endOfRamadan;
		public static Holiday EndOfRamadan {
			get {
				if (endOfRamadan == null) {
					endOfRamadan = new FixedHoliday("Eid ul-Fitr", 10, 1, HirijiCalendar);
				}
				return endOfRamadan;
			}
		}

		//10 Dhul-Hijjah
		private static Holiday endOfHajj;
		public static Holiday EndOfHajj {
			get {
				if (endOfHajj == null) {
					endOfHajj = new FixedHoliday("Eid ul-Adha", 12, 10, HirijiCalendar);
				}
				return endOfHajj;
			}
		}

		//23 September - Saudi National Day
		private static Holiday saudiNationalDay;
		public static Holiday SaudiNationalDay {
			get {
				if (saudiNationalDay == null) {
					saudiNationalDay = new FixedHoliday("Saudi National Day", 9, 23);
				}
				return saudiNationalDay;
			}
		}
	}
}
