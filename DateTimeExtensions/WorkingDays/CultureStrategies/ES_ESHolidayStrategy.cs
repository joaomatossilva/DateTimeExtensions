using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	[Locale("es-ES")]
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

		public override IDictionary<DateTime, Holiday> BuildObservancesMap(int year) {
			IDictionary<DateTime, Holiday> holidayMap = new Dictionary<DateTime, Holiday>();
			foreach (var innerHoliday in InnerHolidays) {
				var date = innerHoliday.GetInstance(year);
				if (date.HasValue) {
					holidayMap.Add(date.Value, innerHoliday);
					//if the holiday is a sunday, the holiday is observed on next monday
					if (date.Value.DayOfWeek == DayOfWeek.Sunday) {
						holidayMap.Add(date.Value.AddDays(1), innerHoliday);
					}
				}
			}
			return holidayMap;
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
