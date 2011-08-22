using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {
	/*
	 * This Extensions were taken from http://dotnetslackers.com/articles/aspnet/5-Helpful-DateTime-Extension-Methods.aspx
	 */
	public static class GeneralDateTimeExtensions {

		public static DateTime FirstDayOfMonth(this DateTime date) {
			return new DateTime(date.Year, date.Month, 1);
		}
		public static DateTime LastDayOfMonth(this DateTime date) {
			return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
		}


		public static DateTime SetTime(this DateTime date, int hour) {
			return date.SetTime(hour, 0, 0, 0);
		}
		public static DateTime SetTime(this DateTime date, int hour, int minute) {
			return date.SetTime(hour, minute, 0, 0);
		}
		public static DateTime SetTime(this DateTime date, int hour, int minute, int second) {
			return date.SetTime(hour, minute, second, 0);
		}
		public static DateTime SetTime(this DateTime date, int hour, int minute, int second, int millisecond) {
			return new DateTime(date.Year, date.Month, date.Day, hour, minute, second, millisecond);
		}
	}
}
