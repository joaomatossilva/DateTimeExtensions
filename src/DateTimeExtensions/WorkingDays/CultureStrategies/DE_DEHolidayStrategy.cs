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

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("de-DE")]
    public class DE_DEHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public DE_DEHolidayStrategy()
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(ChristianHolidays.GoodFriday);
            this.InnerObservances.Add(ChristianHolidays.EasterMonday);
            this.InnerObservances.Add(ChristianHolidays.Ascension);
            this.InnerObservances.Add(ChristianHolidays.Pentecost);
            this.InnerObservances.Add(ChristianHolidays.PentecostMonday);
            this.InnerObservances.Add(ChristianHolidays.Christmas);

            this.InnerObservances.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.Add(GermanUnityDay);
            this.InnerObservances.Add(ChristianHolidays.StStephansDay);
        }

        private static NamedDay germanUnityDay;

        public static NamedDay GermanUnityDay
        {
            get
            {
                if (germanUnityDay == null)
                {
                    germanUnityDay = new NamedDay("GermanUnityDay", new FixedDayResolver(10, 3));
                }
                return germanUnityDay;
            }
        }
    }
}