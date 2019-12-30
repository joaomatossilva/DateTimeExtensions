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
using System.Runtime.CompilerServices;

namespace DateTimeExtensions.NaturalText
{
    public struct DateDiff
    {
        private const int MONTHS_IN_YEAR = 12;

        public DateDiff(DateTime startDate, DateTime endDate) : this()
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("endDate cannot be lesser then startDate");
            }

            //First, take difference between dates 
            var dateDiff = endDate - startDate;

            Milliseconds = dateDiff.Milliseconds;
            Seconds = dateDiff.Seconds;
            Minutes = dateDiff.Minutes;
            Hours = dateDiff.Hours;

            int totalMonth = GetProlepticMonth(endDate) - GetProlepticMonth(startDate);
            Days = endDate.Day - startDate.Day;

            if (Days < 0)
            {
                --totalMonth;
                var calcDate = startDate.AddMonths(totalMonth);
                Days = (endDate - calcDate).Days;
            }

            Years = totalMonth / MONTHS_IN_YEAR;
            Months = totalMonth % MONTHS_IN_YEAR;
        }

        public int Years { get; private set; }

        public int Months { get; private set; }

        public int Days { get; private set; }

        public int Hours { get; private set; }

        public int Minutes { get; private set; }

        public int Seconds { get; private set; }

        public int Milliseconds { get; private set; }

        /// <summary>
        /// Get total month count - 1
        /// </summary>
        /// <param name="dateObj">Date obj for calculate</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int GetProlepticMonth(DateTime dateObj)
        {
            return dateObj.Year * MONTHS_IN_YEAR + dateObj.Month - 1;
        }
    }
}