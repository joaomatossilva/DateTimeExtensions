using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class PT_PTHolidayStrategy : IHolidayStrategy {
		IList<Holiday> holidays;


		public PT_PTHolidayStrategy() {
			this.holidays = new List<Holiday>();
			holidays.Add(ChristianHolidays.NewYear);
			holidays.Add(ChristianHolidays.GoodFriday);
			holidays.Add(ChristianHolidays.Easter);
			holidays.Add(ChristianHolidays.ImaculateConception);
			holidays.Add(ChristianHolidays.Assumption);
			holidays.Add(ChristianHolidays.CorpusChristi);
			holidays.Add(ChristianHolidays.AllSaints);
			holidays.Add(ChristianHolidays.Christmas);

			holidays.Add(FreedomDay);
			holidays.Add(GlobalHolidays.InternationalWorkersDay);
			holidays.Add(PortugalDay);
			holidays.Add(RepublicDay);
			holidays.Add(RestorationOfIndependance);
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

		private static Holiday freedomDay;
		public static Holiday FreedomDay {
			get{
				if (freedomDay == null) {
					freedomDay = new FixedHoliday("Freedom Day", 4, 25);
				}
				return freedomDay;
			}
		}

		private static Holiday portugalDay;
		public static Holiday PortugalDay {
			get {
				if (portugalDay == null) {
					portugalDay = new FixedHoliday("Portugal Day", 6, 10);
				}
				return portugalDay;
			}
		}

		private static Holiday republicDay;
		public static Holiday RepublicDay {
			get {
				if (republicDay == null) {
					republicDay = new FixedHoliday("Republic Day", 10, 5);
				}
				return republicDay;
			}
		}

		private static Holiday restorationOfIndependance;
		public static Holiday RestorationOfIndependance {
			get {
				if (restorationOfIndependance == null) {
					restorationOfIndependance = new FixedHoliday("Restoration of Independance", 12, 1);
				}
				return restorationOfIndependance;
			}
		}
	}
}
