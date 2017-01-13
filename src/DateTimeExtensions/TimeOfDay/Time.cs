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
using System.Threading;

namespace DateTimeExtensions.TimeOfDay
{
    public struct Time : IComparable<Time>
    {
        //TODO: netstandart 1.1 don't support RegexOptions.Compiled, but a compiler directive for futher versions might enable this
        //private readonly static Regex ParseRegex = new Regex(@"^(0*[0-9]|1[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$", RegexOptions.Compiled);
        private readonly static Regex ParseRegex = new Regex(@"^(0*[0-9]|1[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$");

        private string formatString;

        public string FormatString
        {
            get { return this.formatString; }
        }

        private int hour;

        public int Hour
        {
            get { return this.hour; }
        }

        private int minute;

        public int Minute
        {
            get { return this.minute; }
        }

        private int second;

        public int Second
        {
            get { return this.second; }
        }

        public Time(int hour = 0, int minute = 0, int second = 0, string formatString = "")
        {
            if (formatString == string.Empty)
                this.formatString = CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
            else
                this.formatString = formatString;

            this.hour = hour;
            this.minute = minute;
            this.second = second;
            EnsureHour(hour);
            EnsureMinute(minute);
            EnsureSecond(second);
        }

        private void EnsureHour(int value)
        {
            if (value < 0 || value > 23)
            {
                throw new ArgumentException("Valid hours must be between 0 and 23", "value");
            }
        }

        private void EnsureMinute(int value)
        {
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Valid minutes must be between 0 and 59", "value");
            }
        }

        private void EnsureSecond(int value)
        {
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Valid seconds must be between 0 and 59", "value");
            }
        }

        public override string ToString()
        {
            var today = DateTime.Today;
            var dateTime = new DateTime(today.Year, today.Month, today.Day, hour, minute, second);
            return dateTime.ToString(FormatString);
        }

        public int CompareTo(Time other)
        {
            //Compare Hours
            var hoursDiff = this.Hour.CompareTo(other.Hour);
            if (hoursDiff != 0)
            {
                return hoursDiff;
            }

            //Hours are the same, so compare minutes
            var minutesDiff = this.Minute.CompareTo(other.Minute);
            if (minutesDiff != 0)
            {
                return minutesDiff;
            }

            //minutes are the same so compare seconds
            var secondsDiff = this.Second.CompareTo(other.Second);
            if (secondsDiff != 0)
            {
                return secondsDiff;
            }

            //seconds are the same. Other is equal.
            return 0;
        }

        public static Time Parse(string valueString)
        {
            var match = ParseRegex.Match(valueString);
            if (!match.Success || match.Groups.Count != 4)
            {
                throw new ArgumentException("Value string was not a correct time format", "valueString");
            }
            return new Time(
                int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value));
        }
    }
}