using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.Common;

namespace DateTimeExtensions.NaturalText.CultureStrategies {
	[Locale("en-GB")]
	[Locale("en-US")]
	public class EN_GBNaturalTimeStrategy  : NaturalTimeStrategyBase{
		protected override string YearText {
			get {
				return "year";
			}
		}

		protected override string MonthText {
			get {
				return "month";
			}
		}

		protected override string DayText {
			get {
				return "day";
			}
		}

		protected override string HourText {
			get {
				return "hour";
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
	}
}
