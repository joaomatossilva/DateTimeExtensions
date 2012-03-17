using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions {
	/*
	 * Some of This Extensions were taken from http://dotnetslackers.com/articles/aspnet/5-Helpful-DateTime-Extension-Methods.aspx
	 */
	public static class GeneralDateTimeExtensions {

		/// <summary>
		/// Retrives the first day of the month of the <paramref name="date"/>.
		/// </summary>
		/// <param name="date">A date from the month we want to get the first day.</param>
		/// <returns>A DateTime representing the first day of the month.</returns>
		public static DateTime FirstDayOfTheMonth(this DateTime date) {
			return new DateTime(date.Year, date.Month, 1);
		}

		/// <summary>
		/// Retrives the last day of the month of the <paramref name="date"/>.
		/// </summary>
		/// <param name="date">A date from the month we want to get the last day.</param>
		/// <returns>A DateTime representing the last day of the month.</returns>
		public static DateTime LastDayOfTheMonth(this DateTime date) {
			return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
		}

		/// <summary>
		/// Retrives the last day of the week that occourred since <paramref name="date"/>.
		/// </summary>
		/// <remarks>If <paramref name="name"/>.DayOfWeek is already <paramref name="dayOfweek"/>, it will return the last one (seven days before)</remarks>
		/// <param name="date">A date.</param>
		/// <param name="dayOfweek">The kind of DayOfWeek we want to get.</param>
		/// <returns>A DateTime representing the last day of the week that occourred.</returns>
		public static DateTime LastDayOfWeek(this DateTime date, DayOfWeek dayOfweek) {
			int delta = -7;
			DateTime targetDate;
			do{
				targetDate = date.AddDays(delta);
				delta++;
			} while (targetDate.DayOfWeek != dayOfweek);
			return targetDate;
		}

		/// <summary>
		/// Retrives the next day of the week that will occour after <paramref name="date"/>.
		/// </summary>
		/// <remarks>If <paramref name="name"/>.DayOfWeek is already <paramref name="dayOfweek"/>, it will return the next one (seven days after)</remarks>
		/// <param name="date">A date.</param>
		/// <param name="dayOfweek">The kind of DayOfWeek we want to get.</param>
		/// <returns>A DateTime representing the next day of the week that will occour after.</returns>
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

		public static DateDiff GetDiff(this DateTime fromDate, DateTime toDate) {
			return toDate >= fromDate ? new DateDiff(toDate.Subtract(fromDate)) : new DateDiff(fromDate.Subtract(toDate));
		}
	}
}
