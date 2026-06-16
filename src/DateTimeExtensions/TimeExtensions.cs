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
        /// Returns a new DateTime instance with the added Time
        /// </summary>
        public static DateTime AddTime(this DateTime dateTime, Time timeToAdd)
        {
            TimeSpan timeSpan = new(timeToAdd.Hour, timeToAdd.Minute, timeToAdd.Second);
            return dateTime.Add(timeSpan);
        }

        /// <summary>
        /// Returns a new DateTime instance with the given Time
        /// </summary>
        public static DateTime SetTime(this DateTime dateTime, Time timeToAdd)
        {
            return new DateTime(
                year: dateTime.Year,
                month: dateTime.Month,
                day: dateTime.Day,
                hour: timeToAdd.Hour,
                minute: timeToAdd.Minute,
                second: timeToAdd.Second);
        }

        /// <summary>
        /// Converts the DateTime into a Time instance
        /// </summary>
        public static Time TimeOfTheDay(this DateTime dateTime)
        {
            return new Time(dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        /// <summary>
        /// Checks if the DateTime is between the starting Time and the ending Time. 
        /// The result is inverted if startTime comes after endTime.
        /// </summary>
        public static bool IsBetween(this DateTime dateTime, Time startTime, Time endTime)
        {
            var currentTime = dateTime.TimeOfTheDay();

            // start time is lesser or equal than end time
            if (startTime <= endTime)
            {
                // currentTime should be between start time and end time
                return startTime <= currentTime && currentTime <= endTime;
            }
            else
            {
                // currentTime should not be between start time and end time
                return currentTime <= endTime || startTime <= currentTime;
            }
        }

        /// <summary>
        /// Checks if DateTime comes before the given Time
        /// </summary>
        public static bool IsBefore(this DateTime dateTime, Time time)
        {
            return dateTime.TimeOfTheDay() < time;
        }

        /// <summary>
        /// Checks if DateTime comes after the given Time
        /// </summary>
        public static bool IsAfter(this DateTime dateTime, Time time)
        {
            return dateTime.TimeOfTheDay() > time;
        }

        public static Time ToTimeOfDay(this string timeValueString)
        {
            return Time.Parse(timeValueString);
        }
    }
}