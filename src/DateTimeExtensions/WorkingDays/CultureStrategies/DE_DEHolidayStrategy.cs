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
    [Locale("de-DE")]
    public class DE_DEHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public DE_DEHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.GoodFriday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.EasterMonday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Ascension));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Pentecost));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.PentecostMonday));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.Christmas));

            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.InternationalWorkersDay));
            this.InnerCalendarDays.Add(new Holiday(GermanUnityDay));
            this.InnerCalendarDays.Add(new Holiday(ChristianHolidays.StStephansDay));
        }
        
        public static NamedDayInitializer GermanUnityDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("GermanUnityDay", new FixedDayStrategy(Month.October, 3)));
    }
}