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
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(MadarakaDay);
            this.InnerHolidays.Add(MashujaaDay);
            this.InnerHolidays.Add(JamhuriDay);
            this.InnerHolidays.Add(MoiDay);
            this.InnerHolidays.Add(HudumaDay);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(GlobalHolidays.BoxingDay);
        }

        // 1 June - Madaraka Day
        private static Holiday madarakaDay;
        public static Holiday MadarakaDay
        {
            get
            {
                if (madarakaDay == null)
                {
                    madarakaDay = new FixedHoliday("Madaraka Day", 6, 1);
                }
                return madarakaDay;
            }
        }

        // 20 October - Mashujaa Day
        private static Holiday mashujaaDay;
        public static Holiday MashujaaDay
        {
            get
            {
                if (mashujaaDay == null)
                {
                    mashujaaDay = new FixedHoliday("Mashujaa Day", 10, 20);
                }
                return mashujaaDay;
            }
        }

        // 12 December - Jamhuri Day
        private static Holiday jamhuriDay;
        public static Holiday JamhuriDay
        {
            get
            {
                if (jamhuriDay == null)
                {
                    jamhuriDay = new FixedHoliday("Jamhuri Day", 12, 12);
                }
                return jamhuriDay;
            }
        }

        // 10 October - Moi Day
        private static Holiday moiDay;
        public static Holiday MoiDay
        {
            get
            {
                if (moiDay == null)
                {
                    moiDay = new FixedHoliday("Moi Day", 10, 10);
                }
                return moiDay;
            }
        }

        // 10 October - Huduma Day (alternative to Moi Day)
        private static Holiday hudumaDay;
        public static Holiday HudumaDay
        {
            get
            {
                if (hudumaDay == null)
                {
                    hudumaDay = new FixedHoliday("Huduma Day", 10, 10);
                }
                return hudumaDay;
            }
        }

        // 26 December - Boxing Day
        private static Holiday boxingDay;
        public static Holiday BoxingDay
        {
            get
            {
                if (boxingDay == null)
                {
                    boxingDay = new FixedHoliday("Boxing Day", 12, 26);
                }
                return boxingDay;
            }
        }

    }
}
