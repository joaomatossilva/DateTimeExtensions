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
    [Locale("it-IT")]
    public class IT_ITHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public IT_ITHolidayStrategy()
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(ChristianHolidays.Epiphany);
            this.InnerObservances.Add(ChristianHolidays.EasterMonday);
            this.InnerObservances.Add(LiberationDay);
            this.InnerObservances.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.Add(RepublicDay);
            this.InnerObservances.Add(ChristianHolidays.Assumption);
            this.InnerObservances.Add(ChristianHolidays.AllSaints);
            this.InnerObservances.Add(ChristianHolidays.ImaculateConception);
            this.InnerObservances.Add(ChristianHolidays.Christmas);
            this.InnerObservances.Add(ChristianHolidays.StStephansDay);
        }

        //2 June - Republic Day
        private static NamedDay republicDay;

        public static NamedDay RepublicDay
        {
            get
            {
                if (republicDay == null)
                {
                    republicDay = new NamedDay("Republic Day", new FixedDayResolver(6, 2));
                }
                return republicDay;
            }
        }
        
        //25 April - Liberation Day
        private static NamedDay liberationDay;

        public static NamedDay LiberationDay
        {
            get
            {
                if (liberationDay == null)
                {
                    liberationDay = new NamedDay("Liberation Day", new FixedDayResolver(4, 25));
                }
                return liberationDay;
            }
        }
    }
}
