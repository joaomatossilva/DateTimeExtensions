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
using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;

namespace DateTimeExtensions.WorkingDays
{
    public static class ChristianHolidays
    {
        private static readonly Lazy<NamedDay> ChristmasLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Christmas", new FixedDayStrategy(Month.December, 25)));
        public static NamedDay Christmas => ChristmasLazy.Value;

        private static readonly Lazy<NamedDay> EpiphanyLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Epiphany", new FixedDayStrategy(Month.January, 6)));
        public static NamedDay Epiphany => EpiphanyLazy.Value;
        
        private static readonly Lazy<NamedDay> AssumptionLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Assumption", new FixedDayStrategy(Month.August, 15)));
        public static NamedDay Assumption => AssumptionLazy.Value;
        
        private static readonly Lazy<NamedDay> AllSaintsLazy = new Lazy<NamedDay>(() => 
            new NamedDay("AllSaints", new FixedDayStrategy(Month.November, 1)));
        public static NamedDay AllSaints => AllSaintsLazy.Value;

        private static readonly Lazy<NamedDay> DayOfTheDeadLazy = new Lazy<NamedDay>(() => 
            new NamedDay("DayOfTheDead", new FixedDayStrategy(Month.November, 2)));
        public static NamedDay DayOfTheDead => DayOfTheDeadLazy.Value;       

        private static readonly Lazy<NamedDay> ImaculateConceptionLazy = new Lazy<NamedDay>(() => 
            new NamedDay("ImaculateConception", new FixedDayStrategy(Month.December, 8)));
        public static NamedDay ImaculateConception => ImaculateConceptionLazy.Value;   

        private static readonly Lazy<NamedDay> EasterLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Easter", EasterDayStrategy.Instance));
        public static NamedDay Easter => EasterLazy.Value;  

        private static readonly Lazy<NamedDay> CarnivalLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Carnival", new NthDayAfterDayStrategy(-47, EasterDayStrategy.Instance)));
        public static NamedDay Carnival => CarnivalLazy.Value; 

        //source: http://en.wikipedia.org/wiki/Palm_Sunday
        //Palm Sunday is a Christian moveable feast that falls on the Sunday before Easter
        private static readonly Lazy<NamedDay> PalmSundayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("PalmSunday", new NthDayOfWeekAfterDayStrategy(-1, DayOfWeek.Sunday, EasterDayStrategy.Instance)));
        public static NamedDay PalmSunday => PalmSundayLazy.Value;
        
        private static readonly Lazy<NamedDay> MaundyThursdayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("MaundyThursday", new NthDayAfterDayStrategy(-3, EasterDayStrategy.Instance)));
        public static NamedDay MaundyThursday => MaundyThursdayLazy.Value;
        
        private static readonly Lazy<NamedDay> GoodFridayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("GoodFriday", new NthDayAfterDayStrategy(-2, EasterDayStrategy.Instance)));
        public static NamedDay GoodFriday => GoodFridayLazy.Value;
        
        private static readonly Lazy<NamedDay> EasterMondayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("EasterMonday", new NthDayAfterDayStrategy(1, EasterDayStrategy.Instance)));
        public static NamedDay EasterMonday => EasterMondayLazy.Value;
        
        private static readonly Lazy<NamedDay> EasterSaturdayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("EasterSaturday", new NthDayAfterDayStrategy(-1, EasterDayStrategy.Instance)));
        public static NamedDay EasterSaturday => EasterSaturdayLazy.Value;

        private static readonly Lazy<NamedDay> CorpusChristiLazy = new Lazy<NamedDay>(() => 
            new NamedDay("CorpusChristi", new NthDayAfterDayStrategy(60, EasterDayStrategy.Instance)));
        public static NamedDay CorpusChristi => CorpusChristiLazy.Value;
        
        //source: http://en.wikipedia.org/wiki/Pentecost
        //50 days after Easter (inclusive of Easter Day). In other words, it falls on the eighth Sunday, counting Easter Day 
        //Also know as Whit Sunday, Whitsun, Whit
        private static readonly Lazy<NamedDay> PentecostLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Pentecost", new NthDayAfterDayStrategy(49, EasterDayStrategy.Instance)));
        public static NamedDay Pentecost => PentecostLazy.Value;

        //Also known as Whit monday
        private static readonly Lazy<NamedDay> PentecostMondayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("PentecostMonday", new NthDayAfterDayStrategy(50, EasterDayStrategy.Instance)));
        public static NamedDay PentecostMonday => PentecostMondayLazy.Value;

        //source: http://en.wikipedia.org/wiki/Ascension_Day
        // Ascension Day is traditionally celebrated on a Thursday, the fortieth day of Easter
        // again, easter day is included
        private static readonly Lazy<NamedDay> AscensionLazy = new Lazy<NamedDay>(() => 
            new NamedDay("Ascension", new NthDayAfterDayStrategy(39, EasterDayStrategy.Instance)));
        public static NamedDay Ascension => AscensionLazy.Value;
            
        private static readonly Lazy<NamedDay> ChristmasEveLazy = new Lazy<NamedDay>(() => 
            new NamedDay("ChristmasEve", new FixedDayStrategy(Month.December, 24)));
        public static NamedDay ChristmasEve => ChristmasEveLazy.Value;
        
        private static readonly Lazy<NamedDay> StStephansDayLazy = new Lazy<NamedDay>(() => 
            new NamedDay("StStephansDay", new FixedDayStrategy(Month.December, 26)));
        public static NamedDay StStephansDay => StStephansDayLazy.Value;
    }
}