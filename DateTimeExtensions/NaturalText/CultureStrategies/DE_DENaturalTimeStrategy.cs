using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.NaturalText.CultureStrategies {
	[Locale("de-DE")]
	public class DE_DENaturalTimeStrategy  : NaturalTimeStrategyBase{
		protected override string YearText {
			get {
				return "jahr";
			}
		}

		protected override string MonthText {
			get {
				return "monat";
			}
		}

		protected override string DayText {
			get {
				return "tag";
			}
		}

		protected override string HourText {
			get {
				return "stunde";
			}
		}

		protected override string MinuteText {
			get {
				return "minute";
			}
		}

		protected override string SecondText {
			get {
				return "sekunde";
			}
		}

		protected override string Pluralize(string text) {
			if (text.EndsWith("e")) {
				return text + "n";
			}
			return text + "en";
		}

	}
}
