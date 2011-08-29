using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class PT_BRHolidayStrategy : IHolidayStrategy {
		IList<Holiday> holidays;


		public PT_BRHolidayStrategy() {
			this.holidays = new List<Holiday>();
			holidays.Add(ChristianHolidays.NewYear);
			holidays.Add(ChristianHolidays.Christmas);
			holidays.Add(GlobalHolidays.InternationalWorkersDay);
			holidays.Add(ChristianHolidays.DayOfTheDead);
			holidays.Add(TiradentesDay);
			holidays.Add(IndependanceDay);
			holidays.Add(OurLadyOfAparecida);
			holidays.Add(RepublicDay);
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

		private static Holiday tiradentesDay;
		public static Holiday TiradentesDay {
			get {
				if (tiradentesDay != null) {
					tiradentesDay = new FixedHoliday("Tiradentes Day", 4, 21);
				}
				return tiradentesDay;
			}
		}

		private static Holiday independanceDay;
		public static Holiday IndependanceDay {
			get {
				if (independanceDay != null) {
					independanceDay = new FixedHoliday("Independance Day", 9, 7);
				}
				return independanceDay;
			}
		}

		private static Holiday ourLadyOfAparecida;
		public static Holiday OurLadyOfAparecida {
			get {
				if (ourLadyOfAparecida != null) {
					ourLadyOfAparecida = new FixedHoliday("Our Lady of Aparecida", 10, 12);
				}
				return ourLadyOfAparecida;
			}
		}

		private static Holiday republicDay;
		public static Holiday RepublicDay {
			get {
				if (republicDay != null) {
					republicDay = new FixedHoliday("Republic Day", 11, 15);
				}
				return republicDay;
			}
		}
	}
}
