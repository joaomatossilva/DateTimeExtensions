using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.NaturalText;

namespace DateTimeExtensions {
	public static class NaturalTimeExtensions {

		public static string ToNaturalText(this DateTime fromDate, DateTime toDate, INaturalTextCultureInfo cultureInfo) {
			return ToNaturalText(fromDate, toDate, true, cultureInfo);
		}

		public static string ToNaturalText(this DateTime fromDate, DateTime toDate) {
			return ToNaturalText(fromDate, toDate, true, new NaturalTextCultureInfo());
		}

		public static string ToNaturalText(this DateTime fromDate, DateTime toDate, bool round, INaturalTextCultureInfo cultureInfo) {
			var dateDiff = fromDate.GetDiff(toDate);
			return cultureInfo.ToNaturalText(dateDiff, round);
		}

		public static string ToNaturalText(this DateTime fromDate, DateTime toDate, bool round) {
			return ToNaturalText(fromDate, toDate, round, new NaturalTextCultureInfo());
		}

		public static string ToExactNaturalText(this DateTime fromDate, DateTime toDate, INaturalTextCultureInfo cultureInfo) {
			var dateDiff = fromDate.GetDiff(toDate);
			return cultureInfo.ToExactNaturalText(dateDiff);
		}

		public static string ToExactNaturalText(this DateTime fromDate, DateTime toDate) {
			return ToExactNaturalText(fromDate, toDate, new NaturalTextCultureInfo());
		}

		public static DateDiff GetDiff(this DateTime fromDate, DateTime toDate) {
			return toDate >= fromDate ? new DateDiff(fromDate, toDate) : new DateDiff(toDate, fromDate);
		}
	}
}
