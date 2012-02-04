using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {
	public static class NaturalTimeExtensions {

		public static string ToNaturalText(this DateTime fromDate, DateTime toDate, bool round, INaturalTextCultureInfo cultureInfo) {
			return cultureInfo.ToNaturalText(toDate.Subtract(fromDate), round);
		}

		public static string ToNaturalText(this DateTime fromDate, DateTime toDate, bool round) {
			return ToNaturalText(fromDate, toDate, round, new DateTimeCultureInfo());
		}

		public static string ToExactNaturalText(this DateTime fromDate, DateTime toDate, INaturalTextCultureInfo cultureInfo) {
			return cultureInfo.ToExactNaturalText(toDate.Subtract(fromDate));
		}

		public static string ToExactNaturalText(this DateTime fromDate, DateTime toDate) {
			return ToExactNaturalText(fromDate, toDate, new DateTimeCultureInfo());
		}
	}
}
