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
using DateTimeExtensions.WorkingDays.DayInYearResolvers;

namespace DateTimeExtensions.WorkingDays
{
    public static class GlobalHolidays
    {
        private static NamedDay internationalWorkersDay;

        public static NamedDay InternationalWorkersDay
        {
            get
            {
                if (internationalWorkersDay == null)
                {
                    internationalWorkersDay = new NamedDay("InternationalWorkerDay", new FixedDayResolver(5, 1));
                }
                return internationalWorkersDay;
            }
        }

        private static NamedDay stPatricksDay;

        public static NamedDay StPatricsDay
        {
            get
            {
                if (stPatricksDay == null)
                {
                    stPatricksDay = new NamedDay("St. Patric's Day", new FixedDayResolver(3, 17));
                }
                return stPatricksDay;
            }
        }

        private static NamedDay veteransDay;

        public static NamedDay VeteransDay
        {
            get
            {
                if (veteransDay == null)
                {
                    veteransDay = new NamedDay("Veterans Day", new FixedDayResolver(11, 11));
                }
                return veteransDay;
            }
        }

        private static NamedDay boxingDay;

        public static NamedDay BoxingDay
        {
            get
            {
                if (boxingDay == null)
                {
                    boxingDay = new NamedDay("Boxing Day", new FixedDayResolver(12, 26));
                }
                return boxingDay;
            }
        }

        private static NamedDay mayDay;

        public static NamedDay MayDay
        {
            get
            {
                if (mayDay == null)
                {
                    mayDay = new NamedDay("MayDay", new FixedDayResolver(5, 1));
                }
                return mayDay;
            }
        }

        //Midsummer Eve - Friday between 19 June and 25 June
        private static NamedDay midsummerEve;

        public static NamedDay MidsummerEve
        {
            get
            {
                if (midsummerEve == null)
                {
                    midsummerEve = new NamedDay("Midsummer Eve", new NthDayOfWeekAfterDayResolver(1, DayOfWeek.Friday, 6, 19));
                }
                return midsummerEve;
            }
        }

        //MidSummer Day - Saturday between 20 June and 26 June
        private static NamedDay midsummerDay;

        public static NamedDay MidsummerDay
        {
            get
            {
                if (midsummerDay == null)
                {
                    midsummerDay = new NamedDay("Midsummer Day", new NthDayOfWeekAfterDayResolver(1, DayOfWeek.Saturday, 6, 20));
                }
                return midsummerDay;
            }
        }

        //New Year's Eve - 31 December
        private static NamedDay newYearsEve;

        public static NamedDay NewYearsEve
        {
            get
            {
                if (newYearsEve == null)
                {
                    newYearsEve = new NamedDay("New Year's Eve", new FixedDayResolver(12, 31));
                }
                return newYearsEve;
            }
        }

        private static NamedDay newYear;

        public static NamedDay NewYear
        {
            get
            {
                if (newYear == null)
                {
                    newYear = new NamedDay("NewYear", new FixedDayResolver(1, 1));
                }
                return newYear;
            }
        }
    }
}
