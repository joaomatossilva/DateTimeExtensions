using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {
	/*
	 * This Extensions were taken from http://dotnetslackers.com/articles/aspnet/5-Helpful-DateTime-Extension-Methods.aspx
	 */
	public static class GeneralDateTimeExtensions {

		public static DateTime FirstDayOfTheMonth(this DateTime date) {
			return new DateTime(date.Year, date.Month, 1);
		}
		public static DateTime LastDayOfTheMonth(this DateTime date) {
			return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
		}

		public static DateTime LastDayOfWeek(this DateTime date, DayOfWeek dayOfweek){
			int delta = -7;
			DateTime targetDate;
			do{
				targetDate = date.AddDays(delta);
				delta++;
			} while (targetDate.DayOfWeek != dayOfweek);
			return targetDate;
		}
		public static DateTime NextDayOfWeek(this DateTime date, DayOfWeek dayOfweek) {
			int delta = 7;
			DateTime targetDate;
			do {
				targetDate = date.AddDays(delta);
				delta--;
			} while (targetDate.DayOfWeek != dayOfweek);
			return targetDate;
		}
		public static DateTime LastDayOfWeekOfTheMonth(this DateTime date, DayOfWeek dayOfweek) {
			DateTime lastDayOfTheMonth = date.LastDayOfTheMonth();
			if (lastDayOfTheMonth.DayOfWeek == dayOfweek) {
				return lastDayOfTheMonth;
			}
			return lastDayOfTheMonth.LastDayOfWeek(dayOfweek);
		}
		public static DateTime FirstDayOfWeekOfTheMonth(this DateTime date, DayOfWeek dayOfweek) {
			DateTime firstDayOfTheMonth = date.FirstDayOfTheMonth();
			if (firstDayOfTheMonth.DayOfWeek == dayOfweek) {
				return firstDayOfTheMonth;
			}
			return firstDayOfTheMonth.NextDayOfWeek(dayOfweek);
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
