using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions.TimeOfDay;

namespace DateTimeExtensions {
	public static class TimeExtensions {
		public static DateTime AddTime(this DateTime dateTime, Time timeToAdd) {
			return dateTime.AddSeconds(timeToAdd.Second).AddMinutes(timeToAdd.Minute).AddHours(timeToAdd.Hour);
		}

		public static DateTime SetTime(this DateTime dateTime, Time timeToAdd) {
			return AddTime(dateTime.Date, timeToAdd);
		}

		public static Time TimeOfTheDay(this DateTime dateTime) {
			return new Time(dateTime.Hour, dateTime.Minute, dateTime.Second);
		}

		public static bool IsBetween(this DateTime dateTime, Time startTime, Time endTime) {
			var currentTime = dateTime.TimeOfTheDay();
			//start time is lesser or equal than end time
			if (startTime.CompareTo(endTime) <= 0) {
				//currentTime should be between start time and end time
				if (currentTime.CompareTo(startTime) >= 0 && currentTime.CompareTo(endTime) <= 0) {
					return true;
				}
				return false;
			} else {
				//currentTime should be between end time time and start time
				if (currentTime.CompareTo(startTime) >= 0 || currentTime.CompareTo(endTime) <= 0) {
					return true;
				}
				return false;
			}
		}

		public static bool IsBefore(this DateTime dateTime, Time time) {
			var currentTime = dateTime.TimeOfTheDay();
			//currentTime should be lesser than time
			return currentTime.CompareTo(time) < 0;
		}

		public static bool IsAfter(this DateTime dateTime, Time time) {
			var currentTime = dateTime.TimeOfTheDay();
			//currentTime should be greater than time
			return currentTime.CompareTo(time) > 0;
		}

		public static Time ToTimeOfDay(this string timeValueString) {
			return Time.Parse(timeValueString);
		}
	}
}
