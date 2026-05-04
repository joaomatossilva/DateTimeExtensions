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
    [Locale("fr-FR")]
    public class FR_FRHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public FR_FRHolidayStrategy(string region)
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(ChristianHolidays.EasterMonday);
            this.InnerObservances.Add(ChristianHolidays.Ascension);
            this.InnerObservances.Add(ChristianHolidays.AllSaints);
            this.InnerObservances.Add(ChristianHolidays.Christmas);
            this.InnerObservances.Add(ChristianHolidays.Assumption);
            this.InnerObservances.Add(ChristianHolidays.PentecostMonday);

            this.InnerObservances.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.Add(GlobalHolidays.VeteransDay);
            this.InnerObservances.Add(VictoryInEuropeDay);
            this.InnerObservances.Add(BastilleDay);

            if (string.IsNullOrEmpty(region))
            {
                return;
            }

            if (region == "Alsace" || region == "Lorraine")
            {
                this.InnerObservances.Add(StStephensDay);
                this.InnerObservances.Add(ChristianHolidays.GoodFriday);
            }
        }

        private static NamedDay victoryInEuropeDay;

        public static NamedDay VictoryInEuropeDay
        {
            get
            {
                if (victoryInEuropeDay == null)
                {
                    victoryInEuropeDay = new NamedDay("Victory in Europe Day", new FixedDayResolver(5, 8));
                }
                return victoryInEuropeDay;
            }
        }

        private static NamedDay bastilleDay;

        public static NamedDay BastilleDay
        {
            get
            {
                if (bastilleDay == null)
                {
                    bastilleDay = new NamedDay("Bastille Day", new FixedDayResolver(7, 14));
                }
                return bastilleDay;
            }
        }

        private static NamedDay stStephensDay;

        public static NamedDay StStephensDay
        {
            get
            {
                if (stStephensDay == null)
                {
                    stStephensDay = new NamedDay("St Stephen's Day", new FixedDayResolver(12, 26));
                }
                return stStephensDay;
            }
        }
    }
}