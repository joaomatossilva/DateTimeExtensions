using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.NaturalText.CultureStrategies {
	public class FR_FRNaturalTimeStrategy  : NaturalTimeStrategyBase{
		protected override string YearText {
			get {
				return "année";
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
			if (text.Equals("année", StringComparison.InvariantCultureIgnoreCase)) {
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
