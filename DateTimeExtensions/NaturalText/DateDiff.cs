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

namespace DateTimeExtensions.NaturalText
{
    public struct DateDiff
    {
        private const int DAYS_IN_MONTH = 30;
        private const int DAYS_IN_YEAR = 365;
        private const int MONTHS_IN_YEAR = 12;

        public DateDiff(DateTime startDate, DateTime endDate) : this()
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("endDate cannot be lesser then startDate");
            }

            var span = endDate.Subtract(startDate);
            Seconds = span.Seconds;
            Minutes = span.Minutes;
            Hours = span.Hours;

            if (endDate.Hour < startDate.Hour)
            {
                Days--;
            }
            if (endDate.Day >= startDate.Day)
            {
                Days += endDate.Day - startDate.Day;
            }
            else
            {
                Months--;
                var daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
                Days += daysInMonth - startDate.Day + endDate.Day;
            }

            if (endDate.Month >= startDate.Month)
            {
                Months += endDate.Month - startDate.Month;
            }
            else
            {
                Months += MONTHS_IN_YEAR - startDate.Month + endDate.Month;
                Years--;
            }

            if (endDate.Year >= startDate.Year)
            {
                Years += endDate.Year - startDate.Year;
            }
        }

        public int Years { get; private set; }

        public int Months { get; private set; }

        public int Days { get; private set; }

        public int Hours { get; private set; }

        public int Minutes { get; private set; }

        public int Seconds { get; private set; }
    }
}