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
using DateTimeExtensions.WorkingDays.RegionIdentifiers;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("pt-PT")]
    public class PT_PTHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public PT_PTHolidayStrategy(string region)
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(ChristianHolidays.GoodFriday);
            this.InnerObservances.Add(ChristianHolidays.Easter);
            this.InnerObservances.Add(ChristianHolidays.ImaculateConception);
            this.InnerObservances.Add(ChristianHolidays.Assumption);
            this.InnerObservances.Add(new NamedDay(
                ChristianHolidays.CorpusChristi.Name,
                new YearDependantDayResolver(year => year < 2013 || year >= 2016, ChristianHolidays.CorpusChristi.Resolver)));
            this.InnerObservances.Add(new NamedDay(
                ChristianHolidays.AllSaints.Name,
                new YearDependantDayResolver(year => year < 2013 || year >= 2016, ChristianHolidays.AllSaints.Resolver)));
            this.InnerObservances.Add(ChristianHolidays.Christmas);

            this.InnerObservances.Add(FreedomDay);
            this.InnerObservances.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.Add(PortugalDay);
            this.InnerObservances.Add(new NamedDay(
                RepublicDay.Name,
                new YearDependantDayResolver(year => year < 2013 || year >= 2016, RepublicDay.Resolver)));
            this.InnerObservances.Add(new NamedDay(
                RestorationOfIndependance.Name,
                new YearDependantDayResolver(year => year < 2013 || year >= 2016, RestorationOfIndependance.Resolver)));

            if (string.IsNullOrEmpty(region))
            {
                return;
            }

            switch (region)
            {
                case PortugalRegion.Lisboa:
                   this.InnerObservances.Add(StAntonio);
                    break;
                case PortugalRegion.Porto:
                    this.InnerObservances.Add(StJoao);
                    break;
                case PortugalRegion.CasteloBranco:
                    this.InnerObservances.Add(SraMercules);
                    break;
            }
        }

        private static NamedDay freedomDay;

        public static NamedDay FreedomDay
        {
            get
            {
                if (freedomDay == null)
                {
                    freedomDay = new NamedDay("Portugal_FreedomDay", new FixedDayResolver(4, 25));
                }
                return freedomDay;
            }
        }

        private static NamedDay portugalDay;

        public static NamedDay PortugalDay
        {
            get
            {
                if (portugalDay == null)
                {
                    portugalDay = new NamedDay("Portugal_PortugalDay", new FixedDayResolver(6, 10));
                }
                return portugalDay;
            }
        }

        private static NamedDay republicDay;

        public static NamedDay RepublicDay
        {
            get
            {
                if (republicDay == null)
                {
                    republicDay = new NamedDay("Portugal_RepublicDay", new FixedDayResolver(10, 5));
                }
                return republicDay;
            }
        }

        private static NamedDay restorationOfIndependance;

        public static NamedDay RestorationOfIndependance
        {
            get
            {
                if (restorationOfIndependance == null)
                {
                    restorationOfIndependance = new NamedDay("Portugal_RestorationIndependance", new FixedDayResolver(12, 1));
                }
                return restorationOfIndependance;
            }
        }

        private static readonly Lazy<NamedDay> StAntonioInstance = new Lazy<NamedDay>(() => new NamedDay("Portugal_SantoAntonio", new FixedDayResolver(6, 13)));
        public static NamedDay StAntonio => StAntonioInstance.Value;

        private static readonly Lazy<NamedDay> StJoaoInstance = new Lazy<NamedDay>(() => new NamedDay("Portugal_SaoJoao", new FixedDayResolver(6, 24)));
        public static NamedDay StJoao => StJoaoInstance.Value;

        private static readonly Lazy<NamedDay> SraMerculesInstance = new Lazy<NamedDay>(() => new NamedDay("Portugal_SraMercules", new EasterBasedDayResolver(9)));
        public static NamedDay SraMercules => SraMerculesInstance.Value;
    }
}
