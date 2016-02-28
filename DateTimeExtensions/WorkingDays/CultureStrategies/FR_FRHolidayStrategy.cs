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
        public FR_FRHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(ChristianHolidays.Ascension);
            this.InnerHolidays.Add(ChristianHolidays.AllSaints);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);

            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(GlobalHolidays.VeteransDay);
            this.InnerHolidays.Add(VictoryInEuropeDay);
            this.InnerHolidays.Add(BastilleDay);
            this.InnerHolidays.Add(StEtienne);
        }

        private static Holiday victoryInEuropeDay;

        public static Holiday VictoryInEuropeDay
        {
            get
            {
                if (victoryInEuropeDay == null)
                {
                    victoryInEuropeDay = new FixedHoliday("Victory in Europe Day", 5, 8);
                }
                return victoryInEuropeDay;
            }
        }

        private static Holiday bastilleDay;

        public static Holiday BastilleDay
        {
            get
            {
                if (bastilleDay == null)
                {
                    bastilleDay = new FixedHoliday("Bastille Day", 7, 14);
                }
                return bastilleDay;
            }
        }

        private static Holiday stEtienne;

        public static Holiday StEtienne
        {
            get
            {
                if (stEtienne == null)
                {
                    stEtienne = new FixedHoliday("St Etienne", 12, 26);
                }
                return stEtienne;
            }
        }
    }
}