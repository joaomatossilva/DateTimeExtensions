using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies {
	[Locale("pt-BR")]
	public class PT_BRHolidayStrategy : HolidayStrategyBase, IHolidayStrategy {

		public PT_BRHolidayStrategy() {			
			this.InnerHolidays.Add(ChristianHolidays.NewYear);
			this.InnerHolidays.Add(ChristianHolidays.Carnival);
			this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
			this.InnerHolidays.Add(ChristianHolidays.Easter);
			this.InnerHolidays.Add(ChristianHolidays.CorpusChristi);
			this.InnerHolidays.Add(ChristianHolidays.Christmas);
			this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
			this.InnerHolidays.Add(ChristianHolidays.DayOfTheDead);
			this.InnerHolidays.Add(TiradentesDay);
			this.InnerHolidays.Add(IndependanceDay);
			this.InnerHolidays.Add(OurLadyOfAparecida);
			this.InnerHolidays.Add(RepublicDay);
		}

		private static Holiday tiradentesDay;
		public static Holiday TiradentesDay {
			get {
				if (tiradentesDay == null) {
					tiradentesDay = new FixedHoliday("Tiradentes Day", 4, 21);
				}
				return tiradentesDay;
			}
		}

		private static Holiday independanceDay;
		public static Holiday IndependanceDay {
			get {
				if (independanceDay == null) {
					independanceDay = new FixedHoliday("Independance Day", 9, 7);
				}
				return independanceDay;
			}
		}

		private static Holiday ourLadyOfAparecida;
		public static Holiday OurLadyOfAparecida {
			get {
				if (ourLadyOfAparecida == null) {
					ourLadyOfAparecida = new FixedHoliday("Our Lady of Aparecida", 10, 12);
				}
				return ourLadyOfAparecida;
			}
		}

		private static Holiday republicDay;
		public static Holiday RepublicDay {
			get {
				if (republicDay == null) {
					republicDay = new FixedHoliday("Republic Day", 11, 15);
				}
				return republicDay;
			}
		}
	}
}
