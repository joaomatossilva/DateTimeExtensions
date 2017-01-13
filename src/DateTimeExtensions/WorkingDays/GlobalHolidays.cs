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

namespace DateTimeExtensions.WorkingDays
{
    public static class GlobalHolidays
    {
        private static Holiday internationalWorkersDay;

        public static Holiday InternationalWorkersDay
        {
            get
            {
                if (internationalWorkersDay == null)
                {
                    internationalWorkersDay = new FixedHoliday("InternationalWorkerDay", 5, 1);
                }
                return internationalWorkersDay;
            }
        }

        private static Holiday stPatricksDay;

        public static Holiday StPatricsDay
        {
            get
            {
                if (stPatricksDay == null)
                {
                    stPatricksDay = new FixedHoliday("St. Patric's Day", 3, 17);
                }
                return stPatricksDay;
            }
        }

        private static Holiday veteransDay;

        public static Holiday VeteransDay
        {
            get
            {
                if (veteransDay == null)
                {
                    veteransDay = new FixedHoliday("Veterans Day", 11, 11);
                }
                return veteransDay;
            }
        }

        private static Holiday boxingDay;

        public static Holiday BoxingDay
        {
            get
            {
                if (boxingDay == null)
                {
                    boxingDay = new FixedHoliday("Boxing Day", 12, 26);
                }
                return boxingDay;
            }
        }

        private static Holiday mayDay;

        public static Holiday MayDay
        {
            get
            {
                if (mayDay == null)
                {
                    mayDay = new FixedHoliday("MayDay", 5, 1);
                }
                return mayDay;
            }
        }

        //Midsummer Eve - Friday between 19 June and 25 June
        private static Holiday midsummerEve;

        public static Holiday MidsummerEve
        {
            get
            {
                if (midsummerEve == null)
                {
                    midsummerEve = new NthDayOfWeekAfterDayHoliday("Midsummer Eve", 1, DayOfWeek.Friday, 6, 19);
                }
                return midsummerEve;
            }
        }

        //MidSummer Day - Saturday between 20 June and 26 June
        private static Holiday midsummerDay;

        public static Holiday MidsummerDay
        {
            get
            {
                if (midsummerDay == null)
                {
                    midsummerDay = new NthDayOfWeekAfterDayHoliday("Midsummer Day", 1, DayOfWeek.Saturday, 6, 20);
                }
                return midsummerDay;
            }
        }

        //New Year's Eve - 31 December
        private static Holiday newYearsEve;

        public static Holiday NewYearsEve
        {
            get
            {
                if (newYearsEve == null)
                {
                    newYearsEve = new FixedHoliday("New Year's Eve", 12, 31);
                }
                return newYearsEve;
            }
        }

        private static Holiday newYear;

        public static Holiday NewYear
        {
            get
            {
                if (newYear == null)
                {
                    newYear = new FixedHoliday("NewYear", 1, 1);
                }
                return newYear;
            }
        }
    }
}