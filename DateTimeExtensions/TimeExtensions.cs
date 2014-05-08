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
    public static class TimeExtensions
    {
        public static DateTime AddTime(this DateTime dateTime, Time timeToAdd)
        {
            return dateTime.AddSeconds(timeToAdd.Second).AddMinutes(timeToAdd.Minute).AddHours(timeToAdd.Hour);
        }

        public static DateTime SetTime(this DateTime dateTime, Time timeToAdd)
        {
            return AddTime(dateTime.Date, timeToAdd);
        }

        public static Time TimeOfTheDay(this DateTime dateTime)
        {
            return new Time(dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        public static bool IsBetween(this DateTime dateTime, Time startTime, Time endTime)
        {
            var currentTime = dateTime.TimeOfTheDay();
            //start time is lesser or equal than end time
            if (startTime.CompareTo(endTime) <= 0)
            {
                //currentTime should be between start time and end time
                if (currentTime.CompareTo(startTime) >= 0 && currentTime.CompareTo(endTime) <= 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                //currentTime should be between end time time and start time
                if (currentTime.CompareTo(startTime) >= 0 || currentTime.CompareTo(endTime) <= 0)
                {
                    return true;
                }
                return false;
            }
        }

        public static bool IsBefore(this DateTime dateTime, Time time)
        {
            var currentTime = dateTime.TimeOfTheDay();
            //currentTime should be lesser than time
            return currentTime.CompareTo(time) < 0;
        }

        public static bool IsAfter(this DateTime dateTime, Time time)
        {
            var currentTime = dateTime.TimeOfTheDay();
            //currentTime should be greater than time
            return currentTime.CompareTo(time) > 0;
        }

        public static Time ToTimeOfDay(this string timeValueString)
        {
            return Time.Parse(timeValueString);
        }
    }
}