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
    [Locale("en-JM")]
    public class EN_JMHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_JMHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(ChristianHolidays.AshWednesday);
            

            this.InnerHolidays.Add(GlobalHolidays.BoxingDay);
            this.InnerHolidays.Add(MayDayBank);
            
        }

        //1st Monday in May	- May Day Bank Holiday
        private static Holiday mayDayBank;

        public static Holiday MayDayBank
        {
            get
            {
                if (mayDayBank == null)
                {
                    mayDayBank = new NthDayOfWeekInMonthHoliday("May Day Bank", 1, DayOfWeek.Monday, 5,
                        CountDirection.FromFirst);
                }
                return mayDayBank;
            }
        }      
    }
}