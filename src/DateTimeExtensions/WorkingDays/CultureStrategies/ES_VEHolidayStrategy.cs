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
    [Locale("es-VE")]
    public class ES_VEHolidayStrategy : HolidayStrategyBase, IObservancesStrategy
    {
        public ES_VEHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(KingsDay);
            this.InnerObservances.AddHoliday(ConstitutionDay);
            this.InnerObservances.AddHoliday(SimonBolivarBirthDay);
            this.InnerObservances.AddHoliday(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.AddHoliday(IndependenceDay);
            this.InnerObservances.AddHoliday(JoseGregorioHernandezDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
        }


        // 6 January - Kings Day
        private static NamedDay kingsDay;
        public static NamedDay KingsDay
        {
            get
            {
                if (kingsDay == null)
                {
                    kingsDay = new NamedDay("Kings Day", new FixedDayResolver(6, 1));
                }
                return kingsDay;
            }
        }

        //First Monday of February - Constitution Day
        private static NamedDay constitutionDay;

        public static NamedDay ConstitutionDay
        {
            get
            {
                if (constitutionDay == null)
                {
                    constitutionDay = new NamedDay("Constitution Day", new NthDayOfWeekInMonthDayResolver(1, DayOfWeek.Monday, 2, CountDirection.FromFirst));
                }
                return constitutionDay;
            }
        }

        //24 July - Simon Bolívar Birthday
        private static NamedDay simonBolivarBithDay;

        public static NamedDay SimonBolivarBirthDay
        {
            get
            {
                if (simonBolivarBithDay == null)
                {
                    simonBolivarBithDay = new NamedDay("Simón Bolívar's Birthday", new FixedDayResolver(7, 24));
                }
                return simonBolivarBithDay;
            }
        }


        //5 July - Independence Day
        private static NamedDay independenceDay;

        public static NamedDay IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new NamedDay("Independence Day", new FixedDayResolver(7, 5));
                }
                return independenceDay;
            }
        }

        private static NamedDay joseGregorioHernandezDay;
        public static NamedDay JoseGregorioHernandezDay
        {
            get
            {
                if (joseGregorioHernandezDay == null)
                {
                    joseGregorioHernandezDay = new NamedDay("José Gregorio Hernández's  Day", new FixedDayResolver(26, 10));
                }
                return joseGregorioHernandezDay;
            }
        }

    }
}
