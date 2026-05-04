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
    public class NL_BEHolidayStrategy : HolidayStrategyBase, IObservancesStrategy
    {
        public NL_BEHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(ChristianHolidays.Easter);
            this.InnerObservances.AddHoliday(ChristianHolidays.EasterMonday);
            this.InnerObservances.AddHoliday(LabourDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Ascension);
            this.InnerObservances.AddHoliday(ChristianHolidays.Pentecost);
            this.InnerObservances.AddHoliday(ChristianHolidays.PentecostMonday);
            this.InnerObservances.AddHoliday(NationalHoliday);
            this.InnerObservances.AddHoliday(ChristianHolidays.Assumption);
            this.InnerObservances.AddHoliday(ChristianHolidays.AllSaints);
            this.InnerObservances.AddHoliday(Armistice);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
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
