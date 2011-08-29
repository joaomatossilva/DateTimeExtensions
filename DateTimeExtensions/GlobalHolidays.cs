using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {
	public static class GlobalHolidays {

		private static Holiday internationalWorkersDay;
		public static Holiday InternationalWorkersDay {
			get {
				if (internationalWorkersDay == null) {
					internationalWorkersDay = new FixedHoliday("International Workers' day", 5, 1);
				}
				return internationalWorkersDay;
			}
		}
	}
}
