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
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(HumanRightsDay);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(FamilyDay);
            this.InnerHolidays.Add(FreedomDay);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(YouthDay);
            this.InnerHolidays.Add(NationalWomansDay);
            this.InnerHolidays.Add(HeritageDay);
            this.InnerHolidays.Add(DayOfReconciliation);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(DayOfGoodwill);
        }

        protected override IDictionary<DateTime, Holiday> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Holiday> holidayMap = new Dictionary<DateTime, Holiday>();
            foreach (var innerHoliday in InnerHolidays)
            {
                var date = innerHoliday.GetInstance(year);
                if (date.HasValue)
                {
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
        private static Holiday humanRightsDay;

        public static Holiday HumanRightsDay
        {
            get
            {
                if (humanRightsDay == null)
                {
                    humanRightsDay = new FixedHoliday("Human Right's Day", 3, 21);
                }
                return humanRightsDay;
            }
        }

        //First Monday after Easter Sunday - Family Day
        private static Holiday familyDay;

        public static Holiday FamilyDay
        {
            get
            {
                if (familyDay == null)
                {
                    familyDay = new EasterBasedHoliday("Family Day", 1);
                }
                return familyDay;
            }
        }

        //27th April - Freedom Day
        private static Holiday freedomDay;

        public static Holiday FreedomDay
        {
            get
            {
                if (freedomDay == null)
                {
                    freedomDay = new FixedHoliday("Freedom Day", 4, 27);
                }
                return freedomDay;
            }
        }

        //16th June - Youth Day
        private static Holiday youthDay;

        public static Holiday YouthDay
        {
            get
            {
                if (youthDay == null)
                {
                    youthDay = new FixedHoliday("Youth Day", 6, 16);
                }
                return youthDay;
            }
        }

        //9 August - National Woman's Day
        private static Holiday nationalWomansDay;

        public static Holiday NationalWomansDay
        {
            get
            {
                if (nationalWomansDay == null)
                {
                    nationalWomansDay = new FixedHoliday("National Woman's Day", 8, 9);
                }
                return nationalWomansDay;
            }
        }

        //24 September - Heritage Day
        private static Holiday heritageDay;

        public static Holiday HeritageDay
        {
            get
            {
                if (heritageDay == null)
                {
                    heritageDay = new FixedHoliday("Heritage Day", 9, 24);
                }
                return heritageDay;
            }
        }

        //16 December - Day of Reconciliation
        private static Holiday dayOfReconciliation;

        public static Holiday DayOfReconciliation
        {
            get
            {
                if (dayOfReconciliation == null)
                {
                    dayOfReconciliation = new FixedHoliday("Day of Reconciliation", 12, 16);
                }
                return dayOfReconciliation;
            }
        }

        //26 December - Day of Goodwill
        private static Holiday dayOfGoodwill;

        public static Holiday DayOfGoodwill
        {
            get
            {
                if (dayOfGoodwill == null)
                {
                    dayOfGoodwill = new FixedHoliday("Day of Goodwill", 12, 26);
                }
                return dayOfGoodwill;
            }
        }
    }
}