#region License

// 
// Copyright (c) 2011-2012, João Matos Silva <kappy@acydburne.com.pt>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 

#endregion

using System;
using DateTimeExtensions.TimeOfDay;

namespace DateTimeExtensions
{
    public static class TimeExtensions
    {
        /// <summary>
        /// Adds a specified Time to a DateTime.
        /// </summary>
        /// <param name="dateTime">The base DateTime.</param>
        /// <param name="timeToAdd">The Time to add.</param>
        /// <returns>A DateTime with the added time.</returns>
        public static DateTime AddTime(this DateTime dateTime, Time timeToAdd)
        {
            if (timeToAdd == null) throw new ArgumentNullException(nameof(timeToAdd));
            return dateTime.AddSeconds(timeToAdd.Second)
                           .AddMinutes(timeToAdd.Minute)
                           .AddHours(timeToAdd.Hour);
        }

        /// <summary>
        /// Sets the time of a DateTime to a specified Time, keeping the original date.
        /// </summary>
        /// <param name="dateTime">The base DateTime.</param>
        /// <param name="timeToAdd">The Time to set.</param>
        /// <returns>A DateTime with the set time.</returns>
        public static DateTime SetTime(this DateTime dateTime, Time timeToAdd)
        {
            if (timeToAdd == null) throw new ArgumentNullException(nameof(timeToAdd));
            return AddTime(dateTime.Date, timeToAdd);
        }

        /// <summary>
        /// Gets the Time representation of a DateTime's time component.
        /// </summary>
        /// <param name="dateTime">The DateTime to extract the time from.</param>
        /// <returns>A Time instance representing the time component.</returns>
        public static Time TimeOfTheDay(this DateTime dateTime)
        {
            return new Time(dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        /// <summary>
        /// Checks if a DateTime's time is between two specified times.
        /// </summary>
        /// <param name="dateTime">The DateTime to check.</param>
        /// <param name="startTime">The start Time of the range.</param>
        /// <param name="endTime">The end Time of the range.</param>
        /// <returns>True if the time is between startTime and endTime, otherwise false.</returns>
        public static bool IsBetween(this DateTime dateTime, Time startTime, Time endTime)
        {
            if (startTime == null || endTime == null) throw new ArgumentNullException();

            var currentTime = dateTime.TimeOfTheDay();

            // Simplified conditional logic
            return startTime.CompareTo(endTime) <= 0
                ? currentTime.CompareTo(startTime) >= 0 && currentTime.CompareTo(endTime) <= 0
                : currentTime.CompareTo(startTime) >= 0 || currentTime.CompareTo(endTime) <= 0;
        }

        /// <summary>
        /// Checks if a DateTime's time is before a specified time.
        /// </summary>
        /// <param name="dateTime">The DateTime to check.</param>
        /// <param name="time">The Time to compare against.</param>
        /// <returns>True if the DateTime's time is before the specified time, otherwise false.</returns>
        public static bool IsBefore(this DateTime dateTime, Time time)
        {
            if (time == null) throw new ArgumentNullException(nameof(time));
            return dateTime.TimeOfTheDay().CompareTo(time) < 0;
        }

        /// <summary>
        /// Checks if a DateTime's time is after a specified time.
        /// </summary>
        /// <param name="dateTime">The DateTime to check.</param>
        /// <param name="time">The Time to compare against.</param>
        /// <returns>True if the DateTime's time is after the specified time, otherwise false.</returns>
        public static bool IsAfter(this DateTime dateTime, Time time)
        {
            if (time == null) throw new ArgumentNullException(nameof(time));
            return dateTime.TimeOfTheDay().CompareTo(time) > 0;
        }

        /// <summary>
        /// Parses a string to a Time instance.
        /// </summary>
        /// <param name="timeValueString">The string representing the time.</param>
        /// <returns>A Time instance parsed from the string.</returns>
        public static Time ToTimeOfDay(this string timeValueString)
        {
            if (string.IsNullOrWhiteSpace(timeValueString))
                throw new ArgumentException("Time string cannot be null or whitespace.", nameof(timeValueString));

            return Time.TryParse(timeValueString, out var parsedTime)
                ? parsedTime
                : throw new FormatException($"Invalid time format: {timeValueString}");
        }
    }
}
