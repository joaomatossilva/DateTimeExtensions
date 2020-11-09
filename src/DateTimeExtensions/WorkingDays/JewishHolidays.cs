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

        private static readonly Lazy<NamedDay> RoshHashanahLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Rosh Hashanah", new FixedDayStrategy(1, 1, HebrewCalendar)));
        public static NamedDay RoshHashanah => RoshHashanahLazy.Value;
        
        private static readonly Lazy<NamedDay> RoshHashanahSecondDayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Rosh Hashanah", new FixedDayStrategy(1, 2, HebrewCalendar)));
        public static NamedDay RoshHashanahSecondDay => RoshHashanahSecondDayLazy.Value;

        private static readonly Lazy<NamedDay> YomKippurLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Yom Kippur", new FixedDayStrategy(1, 10, HebrewCalendar)));
        public static NamedDay YomKippur => YomKippurLazy.Value;

        private static readonly Lazy<NamedDay> SukkotLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Sukkot", new FixedDayStrategy(1, 15, HebrewCalendar)));
        public static NamedDay Sukkot => SukkotLazy.Value;

        private static readonly Lazy<NamedDay> ShminiAtzeretLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Shmini Atzeret", new FixedDayStrategy(1, 22, HebrewCalendar)));
        public static NamedDay ShminiAtzeret => ShminiAtzeretLazy.Value;

        private static readonly Lazy<NamedDay> ShminiTorahLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Shmini Torah", new FixedDayStrategy(1, 23, HebrewCalendar)));
        public static NamedDay ShminiTorah => ShminiTorahLazy.Value;
        
        private static readonly Lazy<NamedDay> PesachLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Pesach", new FixedDayStrategy(7, 15, HebrewCalendar)));
        public static NamedDay Pesach => PesachLazy.Value;

        private static readonly Lazy<NamedDay> ShviiShelPesachLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Shvi'i shel Pesach", new FixedDayStrategy(7, 21, HebrewCalendar)));
        public static NamedDay ShviiShelPesach => ShviiShelPesachLazy.Value;

        private static readonly Lazy<NamedDay> ShavuotLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Shavuot", new FixedDayStrategy(9, 6, HebrewCalendar)));
        public static NamedDay Shavuot => ShavuotLazy.Value;
        
        private static readonly Lazy<NamedDay> TuBishvatLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Tu Bishvat", new FixedDayStrategy(5, 15, HebrewCalendar)));
        public static NamedDay TuBishvat => TuBishvatLazy.Value;
    }
}