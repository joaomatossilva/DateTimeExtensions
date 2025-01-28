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

namespace DateTimeExtensions.WorkingDays
{
    public class DayInYear
    {
        public DayInYear(int month, int day) : this(month, day, new GregorianCalendar()) { }

        public DayInYear(int month, int day, Calendar calendar)
        {
            Month = month;
            Day = day;
            Calendar = calendar ?? throw new ArgumentNullException(nameof(calendar));
        }

        public int Day { get; private set; }
        public int Month { get; private set; }
        public Calendar Calendar { get; private set; }

        public DateTime GetDayOnYear(int year)
        {
            // Directly create the target date in the provided year, avoiding redundant calendar adjustments
            DateTime dayInstance = Calendar.ToDateTime(year, Month, Day, 0, 0, 0, 0);
            
            // If the date is in the previous year (due to the calendar system), adjust by adding a year
            if (dayInstance.Year < year)
            {
                dayInstance = dayInstance.AddYears(1);
            }

            return dayInstance;
        }

        public bool IsTheSameDay(DateTime day)
        {
            // Simply compare the month and day values to avoid unnecessary object creation
            return day.Month == Month && day.Day == Day;
        }
    }
}
