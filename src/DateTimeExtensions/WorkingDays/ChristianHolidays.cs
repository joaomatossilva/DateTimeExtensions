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
        public static NamedDayInitializer Christmas { get; } = new NamedDayInitializer(() =>
            new NamedDay("Christmas", new FixedDayStrategy(Month.December, 25)));

        public static NamedDayInitializer Epiphany { get; } = new NamedDayInitializer(() =>
            new NamedDay("Epiphany", new FixedDayStrategy(Month.January, 6)));

        public static NamedDayInitializer Assumption { get; } = new NamedDayInitializer(() =>
            new NamedDay("Assumption", new FixedDayStrategy(Month.August, 15)));

        public static NamedDayInitializer AllSaints { get; } = new NamedDayInitializer(() =>
            new NamedDay("AllSaints", new FixedDayStrategy(Month.November, 1)));

        public static NamedDayInitializer DayOfTheDead { get; } = new NamedDayInitializer(() =>
            new NamedDay("DayOfTheDead", new FixedDayStrategy(Month.November, 2)));

        public static NamedDayInitializer ImaculateConception { get; } = new NamedDayInitializer(() =>
            new NamedDay("ImaculateConception", new FixedDayStrategy(Month.December, 8)));

        public static NamedDayInitializer Easter { get; } = new NamedDayInitializer(() =>
            new NamedDay("Easter", EasterDayStrategy.Instance));

        public static NamedDayInitializer Carnival { get; } = new NamedDayInitializer(() =>
            new NamedDay("Carnival", new NthDayAfterDayStrategy(-47, EasterDayStrategy.Instance)));

        //source: http://en.wikipedia.org/wiki/Palm_Sunday
        //Palm Sunday is a Christian moveable feast that falls on the Sunday before Easter
        public static NamedDayInitializer PalmSunday { get; } = new NamedDayInitializer(() =>
            new NamedDay("PalmSunday", new NthDayOfWeekAfterDayStrategy(-1, DayOfWeek.Sunday, EasterDayStrategy.Instance)));

        public static NamedDayInitializer MaundyThursday { get; } = new NamedDayInitializer(() =>
            new NamedDay("MaundyThursday", new NthDayAfterDayStrategy(-3, EasterDayStrategy.Instance)));

        public static NamedDayInitializer GoodFriday { get; } = new NamedDayInitializer(() =>
            new NamedDay("GoodFriday", new NthDayAfterDayStrategy(-2, EasterDayStrategy.Instance)));

        public static NamedDayInitializer EasterMonday { get; } = new NamedDayInitializer(() =>
            new NamedDay("EasterMonday", new NthDayAfterDayStrategy(1, EasterDayStrategy.Instance)));

        public static NamedDayInitializer EasterSaturday { get; } = new NamedDayInitializer(() =>
            new NamedDay("EasterSaturday", new NthDayAfterDayStrategy(-1, EasterDayStrategy.Instance)));

        public static NamedDayInitializer CorpusChristi { get; } = new NamedDayInitializer(() =>
            new NamedDay("CorpusChristi", new NthDayAfterDayStrategy(60, EasterDayStrategy.Instance)));

        public static NamedDayInitializer SacredHeart { get; } = new NamedDayInitializer(() =>
            new NamedDay("SacredHeart", new NthDayAfterDayStrategy(68, EasterDayStrategy.Instance)));

        //source: http://en.wikipedia.org/wiki/Pentecost
        //50 days after Easter (inclusive of Easter Day). In other words, it falls on the eighth Sunday, counting Easter Day
        //Also know as Whit Sunday, Whitsun, Whit
        public static NamedDayInitializer Pentecost { get; } = new NamedDayInitializer(() =>
            new NamedDay("Pentecost", new NthDayAfterDayStrategy(49, EasterDayStrategy.Instance)));

        //Also known as Whit monday
        public static NamedDayInitializer PentecostMonday { get; } = new NamedDayInitializer(() =>
            new NamedDay("PentecostMonday", new NthDayAfterDayStrategy(50, EasterDayStrategy.Instance)));

        //source: http://en.wikipedia.org/wiki/Ascension_Day
        // Ascension Day is traditionally celebrated on a Thursday, the fortieth day of Easter
        // again, easter day is included
        public static NamedDayInitializer Ascension { get; } = new NamedDayInitializer(() =>
            new NamedDay("Ascension", new NthDayAfterDayStrategy(39, EasterDayStrategy.Instance)));

        public static NamedDayInitializer ChristmasEve { get; } = new NamedDayInitializer(() =>
            new NamedDay("ChristmasEve", new FixedDayStrategy(Month.December, 24)));

        public static NamedDayInitializer StStephansDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("StStephansDay", new FixedDayStrategy(Month.December, 26)));

        public static NamedDayInitializer StJoseph { get; } = new NamedDayInitializer(() =>
            new NamedDay("StJosephDay", new FixedDayStrategy(Month.March, 19)));

        public static NamedDayInitializer StPeterStPaul { get; } = new NamedDayInitializer(() =>
            new NamedDay("StPeterStPaul", new FixedDayStrategy(Month.June, 29)));
    }
}