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
    [Locale("vi-VN")]
    public class ViVNHolidayStrategy : HolidayStrategyBase
    {
        public ViVNHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(HungKingsCommemorations);
            this.InnerObservances.AddHoliday(LiberationDay);
            this.InnerObservances.AddHoliday(InternationalWorkersDay);
            this.InnerObservances.AddHoliday(NationalDay);
            this.InnerObservances.AddHoliday(NewYear);
        }

        private static NamedDay hungKingsCommemorations;
        public static NamedDay HungKingsCommemorations
        {
            get
            {
                if (hungKingsCommemorations == null)
                {
                    hungKingsCommemorations = new NamedDay("HungKingsCommemorations", new FixedDayResolver(3, 10));
                }
                return hungKingsCommemorations;
            }
        }

        private static NamedDay liberationDay;
        public static NamedDay LiberationDay
        {
            get
            {
                if (liberationDay == null)
                {
                    liberationDay = new NamedDay("LiberationDay", new FixedDayResolver(4, 30));
                }
                return liberationDay;
            }
        }

        private static NamedDay internationalWorkersDay;
        public static NamedDay InternationalWorkersDay
        {
            get
            {
                if (internationalWorkersDay == null)
                {
                    internationalWorkersDay = new NamedDay("InternationalWorkersDay", new FixedDayResolver(5, 1));
                }
                return internationalWorkersDay;
            }
        }

        private static NamedDay nationalDay;
        public static NamedDay NationalDay
        {
            get
            {
                if (nationalDay == null)
                {
                    nationalDay = new NamedDay("NationalDay", new FixedDayResolver(9, 2));
                }
                return nationalDay;
            }
        }

        private static NamedDay newYear;
        public static NamedDay NewYear
        {
            get
            {
                if (newYear==null)
                {
                    newYear = new NamedDay("NewYear", new FixedDayResolver(1, 1));
                }
                return newYear;
            }
        }
    }
}
