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
    [Locale("pt-PT")]
    public class PT_PTHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public PT_PTHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(ChristianHolidays.Easter);
            this.InnerHolidays.Add(ChristianHolidays.ImaculateConception);
            this.InnerHolidays.Add(ChristianHolidays.Assumption);
            this.InnerHolidays.Add(new YearDependantHoliday(year => year < 2013 || year >= 2016, ChristianHolidays.CorpusChristi));
            this.InnerHolidays.Add(new YearDependantHoliday(year => year < 2013 || year >= 2016, ChristianHolidays.AllSaints));
            this.InnerHolidays.Add(ChristianHolidays.Christmas);

            this.InnerHolidays.Add(FreedomDay);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(PortugalDay);
            this.InnerHolidays.Add(new YearDependantHoliday(year => year < 2013 || year >= 2016, RepublicDay));
            this.InnerHolidays.Add(new YearDependantHoliday(year => year < 2013 || year >= 2016, RestorationOfIndependance));
        }

        private static Holiday freedomDay;

        public static Holiday FreedomDay
        {
            get
            {
                if (freedomDay == null)
                {
                    freedomDay = new FixedHoliday("Portugal_FreedomDay", 4, 25);
                }
                return freedomDay;
            }
        }

        private static Holiday portugalDay;

        public static Holiday PortugalDay
        {
            get
            {
                if (portugalDay == null)
                {
                    portugalDay = new FixedHoliday("Portugal_PortugalDay", 6, 10);
                }
                return portugalDay;
            }
        }

        private static Holiday republicDay;

        public static Holiday RepublicDay
        {
            get
            {
                if (republicDay == null)
                {
                    republicDay = new FixedHoliday("Portugal_RepublicDay", 10, 5);
                }
                return republicDay;
            }
        }

        private static Holiday restorationOfIndependance;

        public static Holiday RestorationOfIndependance
        {
            get
            {
                if (restorationOfIndependance == null)
                {
                    restorationOfIndependance = new FixedHoliday("Portugal_RestorationIndependance", 12, 1);
                }
                return restorationOfIndependance;
            }
        }
    }
}