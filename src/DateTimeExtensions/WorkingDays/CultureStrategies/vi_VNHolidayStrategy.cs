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

using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays.OccurrencesCalculators;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("vi-VN")]
    public class ViVNHolidayStrategy : HolidayStrategyBase
    {
        public ViVNHolidayStrategy()
        {
            this.InnerCalendarDays.Add(new Holiday(HungKingsCommemorations));
            this.InnerCalendarDays.Add(new Holiday(LiberationDay));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.InternationalWorkersDay));
            this.InnerCalendarDays.Add(new Holiday(NationalDay));
            this.InnerCalendarDays.Add(new Holiday(GlobalHolidays.NewYear));
        }

        public static NamedDayInitializer HungKingsCommemorations { get; } = new NamedDayInitializer(() =>
            new NamedDay("HungKingsCommemorations", new FixedDayStrategy(Month.March, 10)));

        public static NamedDayInitializer LiberationDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("LiberationDay", new FixedDayStrategy(Month.April, 30)));

        public static NamedDayInitializer NationalDay { get; } = new NamedDayInitializer(() =>
            new NamedDay("NationalDay", new FixedDayStrategy(Month.September, 2)));
    }
}