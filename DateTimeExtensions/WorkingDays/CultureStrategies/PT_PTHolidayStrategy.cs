using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	public class PT_PTHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public PT_PTHolidayStrategy() {
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
			this.InnerHolidays.Add(ChristianHolidays.Easter);
			this.InnerHolidays.Add(ChristianHolidays.ImaculateConception);
			/* v1.2 Change Reversion. Theses InnerHolidays abolishment aren't still final
			InnerHolidays.Add(new YearDependantHoliday(year => year < 2012, ChristianHolidays.Assumption));
			InnerHolidays.Add(new YearDependantHoliday(year => year < 2012, ChristianHolidays.CorpusChristi));
			 */
			this.InnerHolidays.Add(ChristianHolidays.Assumption);
			this.InnerHolidays.Add(ChristianHolidays.CorpusChristi);
			this.InnerHolidays.Add(ChristianHolidays.AllSaints);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);

			this.InnerHolidays.Add(FreedomDay);
			this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
			this.InnerHolidays.Add(PortugalDay);
			/* v1.2 Change Reversion. Theses InnerHolidays abolishment aren't still final
			InnerHolidays.Add(new YearDependantHoliday(year => year < 2012, RepublicDay));
			InnerHolidays.Add(new YearDependantHoliday(year => year < 2012, RestorationOfIndependance));
			 */
			this.InnerHolidays.Add(RepublicDay);
			this.InnerHolidays.Add(RestorationOfIndependance);
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
