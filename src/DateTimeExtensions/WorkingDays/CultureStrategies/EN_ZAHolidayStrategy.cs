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
    [Locale("en-ZA")]
    public class EN_ZAHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_ZAHolidayStrategy()
        {
            this.InnerObservances.Add(GlobalHolidays.NewYear);
            this.InnerObservances.Add(HumanRightsDay);
            this.InnerObservances.Add(ChristianHolidays.GoodFriday);
            this.InnerObservances.Add(FamilyDay);
            this.InnerObservances.Add(FreedomDay);
            this.InnerObservances.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.Add(YouthDay);
            this.InnerObservances.Add(NationalWomansDay);
            this.InnerObservances.Add(HeritageDay);
            this.InnerObservances.Add(DayOfReconciliation);
            this.InnerObservances.Add(ChristianHolidays.Christmas);
            this.InnerObservances.Add(DayOfGoodwill);
        }

        protected override IDictionary<DateTime, NamedDay> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, NamedDay> holidayMap = new Dictionary<DateTime, NamedDay>();
            foreach (var innerHoliday in InnerObservances)
            {
                 var date = innerHoliday.GetInstance(year);
                    if (date.HasValue)
                    {
                        if (holidayMap.ContainsKey(date.Value))
                            // Check to see if holiday falling on the Sunday then moves to the monday, and there is another holiday scheduled for the monday
                            // Update the NamedDay Name of the Monday
                            holidayMap[date.Value] = innerHoliday;
                        else
                            holidayMap.Add(date.Value, innerHoliday);
                            //if the holiday is a sunday, the holiday is observed on next monday
                            if (date.Value.DayOfWeek == DayOfWeek.Sunday)
                            {
                                holidayMap.AddIfInexistent(date.Value.AddDays(1), innerHoliday);
                            }
                    }
            }
            return holidayMap;
        }

        //21 March - Human Right's Day		
        private static NamedDay humanRightsDay;

        public static NamedDay HumanRightsDay
        {
            get
            {
                if (humanRightsDay == null)
                {
                    humanRightsDay = new NamedDay("Human Right's Day", new FixedDayResolver(3, 21));
                }
                return humanRightsDay;
            }
        }

        //First Monday after Easter Sunday - Family Day
        private static NamedDay familyDay;

        public static NamedDay FamilyDay
        {
            get
            {
                if (familyDay == null)
                {
                    familyDay = new NamedDay("Family Day", new EasterBasedDayResolver(1));
                }
                return familyDay;
            }
        }

        //27th April - Freedom Day
        private static NamedDay freedomDay;

        public static NamedDay FreedomDay
        {
            get
            {
                if (freedomDay == null)
                {
                    freedomDay = new NamedDay("Freedom Day", new FixedDayResolver(4, 27));
                }
                return freedomDay;
            }
        }

        //16th June - Youth Day
        private static NamedDay youthDay;

        public static NamedDay YouthDay
        {
            get
            {
                if (youthDay == null)
                {
                    youthDay = new NamedDay("Youth Day", new FixedDayResolver(6, 16));
                }
                return youthDay;
            }
        }

        //9 August - National Woman's Day
        private static NamedDay nationalWomansDay;

        public static NamedDay NationalWomansDay
        {
            get
            {
                if (nationalWomansDay == null)
                {
                    nationalWomansDay = new NamedDay("National Woman's Day", new FixedDayResolver(8, 9));
                }
                return nationalWomansDay;
            }
        }

        //24 September - Heritage Day
        private static NamedDay heritageDay;

        public static NamedDay HeritageDay
        {
            get
            {
                if (heritageDay == null)
                {
                    heritageDay = new NamedDay("Heritage Day", new FixedDayResolver(9, 24));
                }
                return heritageDay;
            }
        }

        //16 December - Day of Reconciliation
        private static NamedDay dayOfReconciliation;

        public static NamedDay DayOfReconciliation
        {
            get
            {
                if (dayOfReconciliation == null)
                {
                    dayOfReconciliation = new NamedDay("Day of Reconciliation", new FixedDayResolver(12, 16));
                }
                return dayOfReconciliation;
            }
        }

        //26 December - Day of Goodwill
        private static NamedDay dayOfGoodwill;

        public static NamedDay DayOfGoodwill
        {
            get
            {
                if (dayOfGoodwill == null)
                {
                    dayOfGoodwill = new NamedDay("Day of Goodwill", new FixedDayResolver(12, 26));
                }
                return dayOfGoodwill;
            }
        }
    }
}
