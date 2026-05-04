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

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    public class RussianHolidayStrategy : HolidayStrategyBase
    {
        public RussianHolidayStrategy()
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(OrtodoxChristmas);
            this.InnerObservances.Add(DefenderOfTheFatherland);
        }

        protected override IDictionary<DateTime, NamedDay> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, NamedDay> holidayMap = new Dictionary<DateTime, NamedDay>();
            // New year -> 1/1 until 6/1
            holidayMap.Add(GlobalHolidays.NewYear.GetInstance(year).Value, GlobalHolidays.NewYear);
            for (int day = 2; day <= 6; day++)
            {
                holidayMap.Add(new DateTime(year, 1, day), GlobalHolidays.NewYear);
            }
            // Christmas 7/1 until 10/1
            holidayMap.Add(OrtodoxChristmas.GetInstance(year).Value, OrtodoxChristmas);
            for (int day = 8; day <= 10; day++)
            {
                holidayMap.Add(new DateTime(year, 1, day), OrtodoxChristmas);
            }

            holidayMap.Add(DefenderOfTheFatherland.GetInstance(year).Value, DefenderOfTheFatherland);
            return holidayMap;
        }

        private NamedDay ortodoxChristmas;

        public NamedDay OrtodoxChristmas
        {
            get
            {
                if (ortodoxChristmas != null)
                {
                    ortodoxChristmas = new NamedDay("Ortodox Christmas", new FixedDayResolver(1, 7));
                }
                return ortodoxChristmas;
            }
        }

        private NamedDay defenderOfTheFatherland;

        public NamedDay DefenderOfTheFatherland
        {
            get
            {
                if (defenderOfTheFatherland != null)
                {
                    defenderOfTheFatherland = new NamedDay("Defender Of The Fatherland", new FixedDayResolver(2, 23));
                }
                return defenderOfTheFatherland;
            }
        }
    }
}