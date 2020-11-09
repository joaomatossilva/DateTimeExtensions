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

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("da-DK")]
    public class DA_DKHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public DA_DKHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.MaundyThursday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.GoodFriday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Easter));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.EasterMonday));
            this.InnerCalendarDays.Add(new Holiday(GeneralPrayerDay));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Ascension));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Pentecost));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.PentecostMonday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));
            this.InnerCalendarDays.Add(new Holiday(SecondDayOfChristmas));
        }

        public static NamedDayInitializer SecondDayOfChristmas { get; } = new NamedDayInitializer(() =>
            new NamedDay("Christmas (2nd Day)", new FixedDayStrategy(Month.December, 26)));
        
        //source: http://en.wikipedia.org/wiki/Store_Bededag
        // Store Bededag, translated literally as Great Prayer Day or more loosely as General Prayer Day, "All Prayers" Day, Great Day of Prayers or Common Prayer Day,
        //is a Danish holiday celebrated on the 4th Friday after Easter
        public static NamedDayInitializer GeneralPrayerDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("General Prayer Day", new NthDayOfWeekAfterDayStrategy(4, DayOfWeek.Friday, EasterDayStrategy.Instance)));
    }
}