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
    [Locale("en-KE")]
    public class EN_KEHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_KEHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(MadarakaDay);
            this.InnerObservances.AddHoliday(MashujaaDay);
            this.InnerObservances.AddHoliday(JamhuriDay);
            this.InnerObservances.AddHoliday(MoiDay);
            this.InnerObservances.AddHoliday(HudumaDay);
            this.InnerObservances.AddHoliday(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.AddHoliday(GlobalHolidays.BoxingDay);
        }

        // 1 June - Madaraka Day
        private static NamedDay madarakaDay;
        public static NamedDay MadarakaDay
        {
            get
            {
                if (madarakaDay == null)
                {
                    madarakaDay = new NamedDay("Madaraka Day", new FixedDayResolver(6, 1));
                }
                return madarakaDay;
            }
        }

        // 20 October - Mashujaa Day
        private static NamedDay mashujaaDay;
        public static NamedDay MashujaaDay
        {
            get
            {
                if (mashujaaDay == null)
                {
                    mashujaaDay = new NamedDay("Mashujaa Day", new FixedDayResolver(10, 20));
                }
                return mashujaaDay;
            }
        }

        // 12 December - Jamhuri Day
        private static NamedDay jamhuriDay;
        public static NamedDay JamhuriDay
        {
            get
            {
                if (jamhuriDay == null)
                {
                    jamhuriDay = new NamedDay("Jamhuri Day", new FixedDayResolver(12, 12));
                }
                return jamhuriDay;
            }
        }

        // 10 October - Moi Day
        private static NamedDay moiDay;
        public static NamedDay MoiDay
        {
            get
            {
                if (moiDay == null)
                {
                    moiDay = new NamedDay("Moi Day", new FixedDayResolver(10, 10));
                }
                return moiDay;
            }
        }

        // 10 October - Huduma Day (alternative to Moi Day)
        private static NamedDay hudumaDay;
        public static NamedDay HudumaDay
        {
            get
            {
                if (hudumaDay == null)
                {
                    hudumaDay = new NamedDay("Huduma Day", new FixedDayResolver(10, 10));
                }
                return hudumaDay;
            }
        }

        // 26 December - Boxing Day
        private static NamedDay boxingDay;
        public static NamedDay BoxingDay
        {
            get
            {
                if (boxingDay == null)
                {
                    boxingDay = new NamedDay("Boxing Day", new FixedDayResolver(12, 26));
                }
                return boxingDay;
            }
        }

    }
}
