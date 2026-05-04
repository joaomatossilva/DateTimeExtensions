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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("nb-NO")]
    public class NB_NOHolidayStrategy : HolidayStrategyBase, IObservancesStrategy
    {
        public NB_NOHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(ChristianHolidays.MaundyThursday);
            this.InnerObservances.AddHoliday(ChristianHolidays.GoodFriday);
            this.InnerObservances.AddHoliday(ChristianHolidays.Easter);
            this.InnerObservances.AddHoliday(ChristianHolidays.EasterMonday);
            this.InnerObservances.AddHoliday(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.AddHoliday(ConstitutionDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Ascension);
            this.InnerObservances.AddHoliday(ChristianHolidays.Pentecost);
            this.InnerObservances.AddHoliday(ChristianHolidays.PentecostMonday);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
            this.InnerObservances.AddHoliday(ChristianHolidays.StStephansDay);
        }

        private static NamedDay constituionDay;

        public static NamedDay ConstitutionDay
        {
            get
            {
                if (constituionDay == null)
                {
                    constituionDay = new NamedDay("Constitution Day", new FixedDayResolver(5, 17));
                }
                return constituionDay;
            }
        }
    }
}
