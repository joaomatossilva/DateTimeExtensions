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
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;

namespace DateTimeExtensions.WorkingDays
{
    public static class JewishHolidays
    {
        private static readonly Calendar HebrewCalendar = new HebrewCalendar();

        public static NamedDayInitializer RoshHashanah { get; } = new NamedDayInitializer(() =>
            new NamedDay("Rosh Hashanah", new FixedDayStrategy(1, 1, HebrewCalendar)));
        
        public static NamedDayInitializer RoshHashanahSecondDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("Rosh Hashanah", new FixedDayStrategy(1, 2, HebrewCalendar)));

        public static NamedDayInitializer YomKippur { get; } = new NamedDayInitializer(() =>
            new NamedDay("Yom Kippur", new FixedDayStrategy(1, 10, HebrewCalendar)));

        public static NamedDayInitializer Sukkot { get; } = new NamedDayInitializer(() =>
            new NamedDay("Sukkot", new FixedDayStrategy(1, 15, HebrewCalendar)));

        public static NamedDayInitializer ShminiAtzeret { get; } = new NamedDayInitializer(() =>
            new NamedDay("Shmini Atzeret", new FixedDayStrategy(1, 22, HebrewCalendar)));

        public static NamedDayInitializer ShminiTorah { get; } = new NamedDayInitializer(() =>
            new NamedDay("Shmini Torah", new FixedDayStrategy(1, 23, HebrewCalendar)));
        
        public static NamedDayInitializer Pesach { get; } = new NamedDayInitializer(() =>
            new NamedDay("Pesach", new FixedDayStrategy(7, 15, HebrewCalendar)));

        public static NamedDayInitializer ShviiShelPesach { get; } = new NamedDayInitializer(() =>
            new NamedDay("Shvi'i shel Pesach", new FixedDayStrategy(7, 21, HebrewCalendar)));

        public static NamedDayInitializer Shavuot { get; } = new NamedDayInitializer(() =>
            new NamedDay("Shavuot", new FixedDayStrategy(9, 6, HebrewCalendar)));
        
        public static NamedDayInitializer TuBishvat { get; } = new NamedDayInitializer(() =>
            new NamedDay("Tu Bishvat", new FixedDayStrategy(5, 15, HebrewCalendar)));
    }
}