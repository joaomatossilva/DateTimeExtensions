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

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("nl-BE")]
    public class NL_BEHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public NL_BEHolidayStrategy()
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(ChristianHolidays.Easter);
            this.InnerObservances.Add(ChristianHolidays.EasterMonday);
            this.InnerObservances.Add(LabourDay);
            this.InnerObservances.Add(ChristianHolidays.Ascension);
            this.InnerObservances.Add(ChristianHolidays.Pentecost);
            this.InnerObservances.Add(ChristianHolidays.PentecostMonday);
            this.InnerObservances.Add(NationalHoliday);
            this.InnerObservances.Add(ChristianHolidays.Assumption);
            this.InnerObservances.Add(ChristianHolidays.AllSaints);
            this.InnerObservances.Add(Armistice);
            this.InnerObservances.Add(ChristianHolidays.Christmas);
        }

        private static NamedDay labourDay;

        public static NamedDay LabourDay
        {
            get
            {
                if (labourDay == null)
                {
                    labourDay = new NamedDay("LabourDay", new FixedDayResolver(5, 1));
                }
                return labourDay;
            }
        }

        private static NamedDay nationalHoliday;

        public static NamedDay NationalHoliday
        {
            get
            {
                if (nationalHoliday == null)
                {
                    nationalHoliday = new NamedDay("Belgium_NationalHoliday", new FixedDayResolver(7, 21));
                }
                return nationalHoliday;
            }
        }

        private static NamedDay armistice;

        public static NamedDay Armistice
        {
            get
            {
                if (armistice == null)
                {
                    armistice = new NamedDay("Armistice", new FixedDayResolver(11, 11));
                }
                return armistice;
            }
        }
    }
}