using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.Strategies {
	public class FR_FRNaturalTimeStrategy  : NaturalTimeStrategyBase{
		protected override string YearText {
			get {
				return "anée";
			}
		}

		protected override string MonthText {
			get {
				return "mois";
			}
		}

		protected override string DayText {
			get {
				return "jour";
			}
		}

		protected override string HourText {
			get {
				return "heure";
			}
		}

		protected override string MinuteText {
			get {
				return "minute";
			}
		}

		protected override string SecondText {
			get {
				return "second";
			}
		}

		protected override string Pluralize(string text) {
			if (text.Equals("anée", StringComparison.InvariantCultureIgnoreCase)) {
				return "ans";
			}
			if (text.Equals("mois", StringComparison.InvariantCultureIgnoreCase)) {
				return "mois";
			}
			if (text.Equals("jour", StringComparison.InvariantCultureIgnoreCase)) {
				return "journées";
			}
			if (text.EndsWith("s")) {
				return text + "es";
			}
			return base.Pluralize(text);
		}

	}
}
