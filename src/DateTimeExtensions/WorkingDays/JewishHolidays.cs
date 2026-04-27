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
using DateTimeExtensions.WorkingDays.DayInYearResolvers;

namespace DateTimeExtensions.WorkingDays
{
    public static class JewishHolidays
    {
        private static readonly Calendar HebrewCalendar = new HebrewCalendar();

        private static NamedDay roshHashanah;

        public static NamedDay RoshHashanah
        {
            get
            {
                return roshHashanah ??
                       (roshHashanah = new NamedDay("Rosh Hashanah", new FixedDayResolver(new DayInYear(1, 1, HebrewCalendar))));
            }
        }

        private static NamedDay roshHashanahSecondDay;

        public static NamedDay RoshHashanahSecondDay
        {
            get
            {
                return roshHashanahSecondDay ??
                       (roshHashanahSecondDay = new NamedDay("Rosh Hashanah", new FixedDayResolver(new DayInYear(1, 2, HebrewCalendar))));
            }
        }

        private static NamedDay yomKippur;

        public static NamedDay YomKippur
        {
            get
            {
                return yomKippur ?? (yomKippur = new NamedDay("Yom Kippur", new FixedDayResolver(new DayInYear(1, 10, HebrewCalendar))));
            }
        }

        private static NamedDay sukkot;

        public static NamedDay Sukkot
        {
            get { return sukkot ?? (sukkot = new NamedDay("Sukkot", new FixedDayResolver(new DayInYear(1, 15, HebrewCalendar)))); }
        }

        private static NamedDay shminiAtzeret;

        public static NamedDay ShminiAtzeret
        {
            get
            {
                return shminiAtzeret ??
                       (shminiAtzeret = new NamedDay("Shmini Atzeret", new FixedDayResolver(new DayInYear(1, 22, HebrewCalendar))));
            }
        }

        private static NamedDay shminiTorah;

        public static NamedDay ShminiTorah
        {
            get
            {
                return shminiTorah ??
                       (shminiTorah = new NamedDay("Shmini Torah", new FixedDayResolver(new DayInYear(1, 23, HebrewCalendar))));
            }
        }

        private static NamedDay pesach;

        public static NamedDay Pesach
        {
            get { return pesach ?? (pesach = new NamedDay("Pesach", new FixedDayResolver(new DayInYear(7, 15, HebrewCalendar)))); }
        }

        private static NamedDay shviiShelPesach;

        public static NamedDay ShviiShelPesach
        {
            get
            {
                return shviiShelPesach ??
                       (shviiShelPesach = new NamedDay("Shvi'i shel Pesach", new FixedDayResolver(new DayInYear(7, 21, HebrewCalendar))));
            }
        }

        private static NamedDay shavuot;

        public static NamedDay Shavuot
        {
            get { return shavuot ?? (shavuot = new NamedDay("Shavuot", new FixedDayResolver(new DayInYear(9, 6, HebrewCalendar)))); }
        }

        private static NamedDay tuBishvat;

        public static NamedDay TuBishvat
        {
            get
            {
                return tuBishvat ?? (tuBishvat = new NamedDay("Tu Bishvat", new FixedDayResolver(new DayInYear(5, 15, HebrewCalendar))));
            }
        }
    }
}
