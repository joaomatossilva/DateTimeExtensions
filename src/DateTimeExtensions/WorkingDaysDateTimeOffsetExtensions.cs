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

using DateTimeExtensions.WorkingDays;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DateTimeExtensions
{
    public static class WorkingDaysDateTimeOffsetExtensions
    {
        /// <summary>
        /// Adds or subctracts the value in <paramref name="workingDays"/> as working days to <paramref name="day"/>. 
        /// </summary>
        /// <remarks>
        /// This algorithm is only efficient for small values of workingDays.
        /// </remarks>
        /// <param name="day">The starting day.</param>
        /// <param name="workingDays">The number of working days to be added or subtracted.</param>
        /// <param name="workingDayCultureInfo">The culture of working days to be used in the calculation. See <seealso cref="WorkingDayCultureInfo"/> for more information.</param>
        /// <returns>Returns a DateTimeOffset representing a date 
        /// with <paramref name="workingDays"/> added or subctracted to <paramref name="day"/>
        /// </returns>
        public static DateTimeOffset AddWorkingDays(this DateTimeOffset day, int workingDays,
            IWorkingDayCultureInfo workingDayCultureInfo)
        {
            return day.Date.AddWorkingDays(workingDays, workingDayCultureInfo);
        }

        /// <summary>
        /// Adds or subctracts the number in <paramref name="workingDays"/> as working days to <paramref name="day"/> using the default <seealso cref="IWorkingDayCultureInfo"/>. 
        /// </summary>
        /// <remarks>
        /// This algorithm is only efficient for small values of workingDays
        /// </remarks>
        /// <param name="day">The starting day.</param>
        /// <param name="workingDays">The number of working days to be added or subtracted.</param>
        /// <returns>Returns a <typeref name="DateTimeOffset"/> representing a date 
        /// with <paramref name="workingDays"/> added or subctracted to <paramref name="day"/>
        /// </returns>
        public static DateTimeOffset AddWorkingDays(this DateTimeOffset day, int workingDays)
        {
            return AddWorkingDays(day, workingDays, new WorkingDayCultureInfo());
        }

        /// <summary>
        /// Calculates the Workingdays in the range <paramref name="from"/> / <paramref name="to"/>
        /// </summary>
        /// <param name="from">The starting day.</param>
        /// <param name="to">The end day.</param>
        /// <param name="workingDayCultureInfo">The culture of working days to be used in the calculation. See <seealso cref="WorkingDayCultureInfo"/> for more information.</param>
        /// <returns>the number of Workingdays in the range <paramref name="from"/> / <paramref name="to"/></returns>
        public static int GetWorkingDays(this DateTimeOffset from, DateTimeOffset to, WorkingDayCultureInfo workingDayCultureInfo)
        {
            return from.Date.GetWorkingDays(to.Date, workingDayCultureInfo);
        }

        /// <summary>
        /// Calculates the Workingdays in the range <paramref name="from"/> / <paramref name="to"/>
        /// </summary>
        /// <param name="from">The starting day.</param>
        /// <param name="to">The end day.</param>        
        /// <returns>the number of Workingdays in the range <paramref name="from"/> / <paramref name="to"/></returns>
        public static int GetWorkingDays(this DateTimeOffset from, DateTimeOffset to)
        {
            return GetWorkingDays(from, to, new WorkingDayCultureInfo());
        }

        /// <summary>
        /// Checks if a specific day is an holiday day, using the default <seealso cref="IWorkingDayCultureInfo"/>, desregarding
        /// the day of the week.
        /// </summary>
        /// <param name="day">The day from calendar to check</param>
        /// <returns></returns>
        public static bool IsWorkingDay(this DateTimeOffset day)
        {
            var workingDayCultureInfo = new WorkingDayCultureInfo();
            return IsWorkingDay(day, workingDayCultureInfo);
        }

        /// <summary>
        /// Checks if a specific day is an holiday desregarding the day of the week.
        /// </summary>
        /// <param name="day">The day from calendar to check</param>
        /// <param name="workingDayCultureInfo">The <seealso cref="IWorkingDayCultureInfo"/> used the check if the day is a working day</param>
        /// <returns></returns>
        public static bool IsHoliday(this DateTimeOffset day, IWorkingDayCultureInfo workingDayCultureInfo)
        {
            return day.Date.IsHoliday(workingDayCultureInfo);
        }

        /// <summary>
        /// Checks if a specific day is a working day, using the default <seealso cref="IWorkingDayCultureInfo"/>.
        /// </summary>
        /// <param name="day">The day from calendar to check</param>
        /// <returns></returns>
        public static bool IsHoliday(this DateTimeOffset day)
        {
            var workingDayCultureInfo = new WorkingDayCultureInfo();
            return IsHoliday(day, workingDayCultureInfo);
        }

        /// <summary>
        /// Checks if a specific day is a working day.
        /// </summary>
        /// <param name="day">The day from calendar to check</param>
        /// <param name="workingDayCultureInfo">The <seealso cref="IWorkingDayCultureInfo"/> used the check if the day is a working day</param>
        /// <returns></returns>
        public static bool IsWorkingDay(this DateTimeOffset day, IWorkingDayCultureInfo workingDayCultureInfo)
        {
            return day.Date.IsWorkingDay(workingDayCultureInfo);
        }

        /// <summary>
        /// Retrieves the holidays that have and are still ocouring on the <paramref name="day" /> year, using the default <seealso cref="IWorkingDayCultureInfo"/>. 
        /// </summary>
        /// <param name="day">The day used to gat the year from.</param>
        /// <returns>Returns a dictionary with the instance of the holiday observed on the year, and the holiday that gave it the observance.</returns>
        public static IDictionary<DateTimeOffset, Holiday> AllYearHolidays(this DateTimeOffset day)
        {
            var workingDayCultureInfo = new WorkingDayCultureInfo();
            return AllYearHolidays(day, workingDayCultureInfo);
        }

        /// <summary>
        /// Retrieves the holidays that have and are still ocouring on the <paramref name="day" /> year. 
        /// </summary>
        /// <param name="day">The day used to gat the year from.</param>
        /// <param name="workingDayCultureInfo">The <seealso cref="IWorkingDayCultureInfo"/> used the get the holidays.</param>
        /// <returns>Returns a dictionary with the instance of the holiday observed on the year, and the holiday that gave it the observance.</returns>
        public static IDictionary<DateTimeOffset, Holiday> AllYearHolidays(this DateTimeOffset day,
            IWorkingDayCultureInfo workingDayCultureInfo)
        {
            return day.Date.AllYearHolidays(workingDayCultureInfo).ToDictionary(x => (DateTimeOffset)x.Key, x => x.Value);
        }
    }
}