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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions.TimeOfDay;

namespace DateTimeExtensions
{
    public class Time : IComparable<Time>
    {
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public int Second { get; private set; }

        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public static bool TryParse(string timeValueString, out Time result)
        {
            result = null;
            var parts = timeValueString.Split(':');
            if (parts.Length != 3) return false;

            if (int.TryParse(parts[0], out int hour) &&
                int.TryParse(parts[1], out int minute) &&
                int.TryParse(parts[2], out int second))
            {
                result = new Time(hour, minute, second);
                return true;
            }

            return false;
        }

        public int CompareTo(Time other)
        {
            if (Hour != other.Hour) return Hour.CompareTo(other.Hour);
            if (Minute != other.Minute) return Minute.CompareTo(other.Minute);
            return Second.CompareTo(other.Second);
        }

        public static bool operator <(Time a, Time b) => a.CompareTo(b) < 0;
        public static bool operator >(Time a, Time b) => a.CompareTo(b) > 0;
        public static bool operator <=(Time a, Time b) => a.CompareTo(b) <= 0;
        public static bool operator >=(Time a, Time b) => a.CompareTo(b) >= 0;
        public static bool operator ==(Time a, Time b) => a.CompareTo(b) == 0;
        public static bool operator !=(Time a, Time b) => a.CompareTo(b) != 0;

        public override bool Equals(object obj)
        {
            if (obj is Time other)
            {
                return Hour == other.Hour && Minute == other.Minute && Second == other.Second;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + Hour.GetHashCode();
                hash = hash * 23 + Minute.GetHashCode();
                hash = hash * 23 + Second.GetHashCode();
                return hash;
            }
        }
    }

    public static class TimeExtensions
    {
        public static DateTime AddTime(this DateTime dateTime, Time timeToAdd)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, timeToAdd.Hour, timeToAdd.Minute, timeToAdd.Second);
        }

        public static DateTime SetTime(this DateTime dateTime, Time timeToAdd)
        {
            return dateTime.Date.AddTime(timeToAdd);
        }

        public static Time TimeOfTheDay(this DateTime dateTime)
        {
            return new Time(dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        public static bool IsBetween(this DateTime dateTime, Time startTime, Time endTime)
        {
            var currentTime = dateTime.TimeOfTheDay();
            return startTime <= endTime
                ? currentTime >= startTime && currentTime <= endTime
                : currentTime >= startTime || currentTime <= endTime;
        }

        public static bool IsBefore(this DateTime dateTime, Time time)
        {
            return dateTime.TimeOfTheDay() < time;
        }

        public static bool IsAfter(this DateTime dateTime, Time time)
        {
            return dateTime.TimeOfTheDay() > time;
        }

        public static Time ToTimeOfDay(this string timeValueString)
        {
            if (Time.TryParse(timeValueString, out Time result))
            {
                return result;
            }
            throw new FormatException("Invalid time format.");
        }
    }
}