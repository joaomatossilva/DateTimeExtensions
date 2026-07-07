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
using System.Globalization;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;

namespace DateTimeExtensions.TimeOfDay
{
    public readonly struct Time : IComparable<Time>, IEquatable<Time>
    {
        //TODO: netstandart 1.1 don't support RegexOptions.Compiled, but a compiler directive for futher versions might enable this
        //private readonly static Regex ParseRegex = new Regex(@"^(0*[0-9]|1[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$", RegexOptions.Compiled);
        private readonly static Regex ParseRegex = new(@"^(0*[0-9]|1[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$");

        private readonly string _formatString;
        public string FormatString => _formatString ?? string.Empty;
        /* Without the null forgiving operator or the backing field, 'default' will
            produce an instance with a null '_formatString', creating problems for ToString().
            TODO: Would be best to remove both the backing field and it's property, passing
            the argument directly to ToString (modifies the public API) */

        public int Hour { get; }

        public int Minute { get; }

        public int Second { get; }

        public static Time Midnight { get; } = default; // 00:00:00

        public static Time MinValue { get; } = default; // 00:00:00

        public static Time Noon { get; } = new(12, 0, 0);

        public static Time MaxValue { get; } = new(23, 59, 59);

        public Time(int hour = 0, int minute = 0, int second = 0, string formatString = "")
        {
            _formatString = formatString == string.Empty
                ? CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern
                : formatString;

            EnsureHour(hour);
            EnsureMinute(minute);
            EnsureSecond(second);

            Hour = hour;
            Minute = minute;
            Second = second;
        }

        private static void EnsureHour(int value)
        {
            if (value < 0 || value > 23)
            {
                throw new ArgumentException("Valid hours must be between 0 and 23", nameof(value));
            }
        }

        private static void EnsureMinute(int value)
        {
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Valid minutes must be between 0 and 59", nameof(value));
            }
        }

        private static void EnsureSecond(int value)
        {
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Valid seconds must be between 0 and 59", nameof(value));
            }
        }

        public override string ToString()
        {
            return ToString(FormatString);
        }

        public string ToString(string formatString)
        {
            if (formatString is null)
            {
                throw new ArgumentNullException(nameof(formatString));
            }

            var today = DateTime.Today;
            var dateTime = new DateTime(today.Year, today.Month, today.Day, Hour, Minute, Second);
            return dateTime.ToString(formatString);
        }

        public int CompareTo(Time other)
        {
            // Compare Hours
            if (Hour != other.Hour)
            {
                return Hour - other.Hour;
            }

            // Hours are the same, so compare minutes
            if (Minute != other.Minute)
            {
                return Minute - other.Minute;
            }

            // Minutes are the same so compare seconds
            if (Second != other.Second)
            {
                return Second - other.Second;
            }

            //seconds are the same. Other is equal.
            return 0;
        }

        /// <summary>
        /// Converts the string representation of the time of the day into a Time type.
        /// The return will indicate success or failure
        /// </summary>
        /// <returns>true if the conversion was successful, false otherwise</returns>
        public static bool TryParse(string valueString, out Time time)
        {
            time = default;

            if (valueString is null)
            {
                return false;
            }

            var match = ParseRegex.Match(valueString);

            if (!match.Success || match.Groups.Count != 4
                || !int.TryParse(match.Groups[1].Value, out int hour)
                || !int.TryParse(match.Groups[2].Value, out int minute)
                || !int.TryParse(match.Groups[3].Value, out int second))
            {
                return false;
            }

            time = new(hour, minute, second);

            return true;
        }

        /// <summary>
        /// Converts the string representation of the time of the day into a Time type.
        /// </summary>
        /// <returns>The Time type representing the given string</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static Time Parse(string valueString)
        {
            if (valueString is null)
            {
                throw new ArgumentNullException(nameof(valueString));
            }

            if (!TryParse(valueString, out Time time))
            {
                throw new ArgumentException("Value string was not a correct time format", nameof(valueString));
            }

            return time;
        }

        public bool Equals(Time other) => CompareTo(other) == 0;

        public override bool Equals([NotNullWhen(true)] object obj) => obj is Time other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Hour, Minute, Second);

        public static bool operator ==(Time left, Time right) => left.Equals(right);

        public static bool operator !=(Time left, Time right) => !left.Equals(right);

        public static bool operator >(Time left, Time right) => left.CompareTo(right) > 0;

        public static bool operator <(Time left, Time right) => left.CompareTo(right) < 0;

        public static bool operator >=(Time left, Time right) => left.CompareTo(right) >= 0;

        public static bool operator <=(Time left, Time right) => left.CompareTo(right) <= 0;
    }
}