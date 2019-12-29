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
        private const int DAYS_IN_LEAP_YEAR = 366;
        private const int DAYS_IN_YEAR = 365;
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
            Days = dateDiff.Days;

            var year = startDate.Year;
            var daysToSubstract = (new DateTime(year + 1, 1, 1) - startDate).Days; //days to the end of the year
            var isAddExtraDays = false;
            
            //Round days, for fast counting years, and remember that
            if (isAddExtraDays = (Days - daysToSubstract > 0))
            {
                Days -= daysToSubstract;
                year++;
            }
            
            //Count all full years, simple substract days in year from total days count
            while (Days - DaysInYear(year) >= 0)
            {
                Days -= DaysInYear(year++);
                ++Years;
            }

            //If we are used rounding, return difference
            if (isAddExtraDays)
            {
                Days += daysToSubstract;
            }

            var month = endDate.Month;
            year = endDate.Year;

            //Afterall, count all months by substracting days in month
            while ((Days - DateTime.DaysInMonth(endDate.Year, month)) >= 0 && month > 0)
            {
                Days -= DateTime.DaysInMonth(endDate.Year, month--);
                ++Months;

                if (month == 0)
                {
                    --year;
                    month = MONTHS_IN_YEAR;
                }
            }

            //In some cases (when we are not using fast years counting), total months count is bigger or equals 12
            if (Months >= MONTHS_IN_YEAR)
            {
                Years += (Months / MONTHS_IN_YEAR);
                Months %= MONTHS_IN_YEAR;
            }
        }

        public int Years { get; private set; }

        public int Months { get; private set; }

        public int Days { get; private set; }

        public int Hours { get; private set; }

        public int Minutes { get; private set; }

        public int Seconds { get; private set; }

        public int Milliseconds { get; private set; }

        /// <summary>
        /// Return number of days in a given year
        /// </summary>
        /// <param name="year">Year to inspect</param>
        /// <returns>Number of days</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int DaysInYear(int year)
        {
            return DateTime.IsLeapYear(year) ? DAYS_IN_LEAP_YEAR : DAYS_IN_YEAR;
        }
    }
}