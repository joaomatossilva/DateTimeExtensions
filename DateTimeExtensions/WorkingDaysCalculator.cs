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
		/// <param name="cultureWorkingDayInfo">The culture of working days to be used in the calculation</param>
		/// <returns>Returns a <typeparamref name="DateTime"/> with the value of the day 
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
		/// Adds or subctracts the number in <paramref name="workingDays"/> as working days to <paramref name="day"/> using the default WorkingDaysCultureInfo. 
		/// </summary>
		/// <remarks>
		/// This algorithm is only efficient for small values of workingDays
		/// </remarks>
		/// <param name="day">The starting day.</param>
		/// <param name="workingDays">The number of working days to be added or subtracted.</param>
		/// <returns>Returns a <typeparamref name="DateTime"/> with the value of the day 
		/// with <paramref name="workingDays"/> added or subctracted to <paramref name="day"/>
		/// </returns>
		public static DateTime AddWorkingDays(this DateTime day, int workingDays) {
			return AddWorkingDays(day, workingDays, new WorkingDayCultureInfo());
		}

		public static bool IsWorkingDay(this DateTime day) {
			var workingDayCultureInfo = new WorkingDayCultureInfo();
			return IsWorkingDay(day, workingDayCultureInfo);
		}

		public static bool IsWorkingDay(this DateTime day, IWorkingDayCultureInfo workingDayCultureInfo) {
			if (!workingDayCultureInfo.IsWorkingDay(day.DayOfWeek)) {
				return false;
			}
			return workingDayCultureInfo.IsWorkingDay(day);
		}		
	}
}
