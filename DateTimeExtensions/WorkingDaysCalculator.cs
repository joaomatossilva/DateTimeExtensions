using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeExtensions {
	public static class WorkingDaysCalculator {

		/// <summary>
		/// Adds or subctracts the value in <paramref name="workingDays"/> as working days to <paramref name="day"/>. 
		/// </summary>
		/// <remarks>
		/// This algorithm is only efficient for small values of workingDays.
		/// </remarks>
		/// <param name="day">The starting day.</param>
		/// <param name="workingDays">The number of working days to be added or subtracted.</param>
		/// <param name="workingDayCultureInfo">The culture of working days to be used in the calculation. See <seealso cref="DateTimeCultureInfo"/> for more information.</param>
		/// <returns>Returns a DateTime representing a date 
		/// with <paramref name="workingDays"/> added or subctracted to <paramref name="day"/>
		/// </returns>
		public static DateTime AddWorkingDays(this DateTime day, int workingDays, IWorkingDayCultureInfo workingDayCultureInfo) {
			DateTime ret;
			int added = 0;

			ret = day.Subtract(day.TimeOfDay);
			while (added < Math.Abs(workingDays)) {
				ret = ret.AddDays((workingDays >= 0)? 1 : -1);
				if (IsWorkingDay(ret, workingDayCultureInfo)) {
					added++;
				}
			}
			return ret;
		}

		/// <summary>
		/// Adds or subctracts the number in <paramref name="workingDays"/> as working days to <paramref name="day"/> using the default <seealso cref="IWorkingDayCultureInfo"/>. 
		/// </summary>
		/// <remarks>
		/// This algorithm is only efficient for small values of workingDays
		/// </remarks>
		/// <param name="day">The starting day.</param>
		/// <param name="workingDays">The number of working days to be added or subtracted.</param>
		/// <returns>Returns a <typeref name="DateTime"/> representing a date 
		/// with <paramref name="workingDays"/> added or subctracted to <paramref name="day"/>
		/// </returns>
		public static DateTime AddWorkingDays(this DateTime day, int workingDays) {
			return AddWorkingDays(day, workingDays, new DateTimeCultureInfo());
		}

		/// <summary>
		/// Checks if a specific day is an holiday day, using the default <seealso cref="IWorkingDayCultureInfo"/>, desregarding
		/// the day of the week.
		/// </summary>
		/// <param name="day">The day from calendar to check</param>
		/// <returns></returns>
		public static bool IsWorkingDay(this DateTime day) {
			var workingDayCultureInfo = new DateTimeCultureInfo();
			return IsWorkingDay(day, workingDayCultureInfo);
		}

		/// <summary>
		/// Checks if a specific day is an holiday desregarding the day of the week.
		/// </summary>
		/// <param name="day">The day from calendar to check</param>
		/// <param name="workingDayCultureInfo">The <seealso cref="IWorkingDayCultureInfo"/> used the check if the day is a working day</param>
		/// <returns></returns>
		public static bool IsHoliday(this DateTime day, IWorkingDayCultureInfo workingDayCultureInfo) {
			return workingDayCultureInfo.IsHoliday(day);
		}

		/// <summary>
		/// Checks if a specific day is a working day, using the default <seealso cref="IWorkingDayCultureInfo"/>.
		/// </summary>
		/// <param name="day">The day from calendar to check</param>
		/// <returns></returns>
		public static bool IsHoliday(this DateTime day) {
			var workingDayCultureInfo = new DateTimeCultureInfo();
			return IsHoliday(day, workingDayCultureInfo);
		}

		/// <summary>
		/// Checks if a specific day is a working day.
		/// </summary>
		/// <param name="day">The day from calendar to check</param>
		/// <param name="workingDayCultureInfo">The <seealso cref="IWorkingDayCultureInfo"/> used the check if the day is a working day</param>
		/// <returns></returns>
		public static bool IsWorkingDay(this DateTime day, IWorkingDayCultureInfo workingDayCultureInfo) {
			if (!workingDayCultureInfo.IsWorkingDay(day.DayOfWeek)) {
				return false;
			}
			return workingDayCultureInfo.IsWorkingDay(day);
		}

		/// <summary>
		/// Retrieves the holidays that have and are still ocouring on the <paramref name="day" /> year, using the default <seealso cref="IWorkingDayCultureInfo"/>. 
		/// </summary>
		/// <param name="day">The day used to gat the year from.</param>
		/// <returns>Returns a dictionary with the instance of the holiday observed on the year, and the holiday that gave it the observance.</returns>
		public static IDictionary<DateTime, Holiday> AllYearHolidays(this DateTime day) {
			var workingDayCultureInfo = new DateTimeCultureInfo();
			return AllYearHolidays(day, workingDayCultureInfo);
		}

		/// <summary>
		/// Retrieves the holidays that have and are still ocouring on the <paramref name="day" /> year. 
		/// </summary>
		/// <param name="day">The day used to gat the year from.</param>
		/// <param name="workingDayCultureInfo">The <seealso cref="IWorkingDayCultureInfo"/> used the get the holidays.</param>
		/// <returns>Returns a dictionary with the instance of the holiday observed on the year, and the holiday that gave it the observance.</returns>
		public static IDictionary<DateTime, Holiday> AllYearHolidays(this DateTime day, IWorkingDayCultureInfo workingDayCultureInfo) {
			var holidays = new SortedDictionary<DateTime, Holiday>();
			foreach (Holiday holiday in workingDayCultureInfo.GetHolidaysOfYear(day.Year)) {
				var date = holiday.GetInstance(day.Year);
				if (date.HasValue) {
					holidays.Add(date.Value, holiday);
				}
			}
			return holidays;
		}
	}
}
