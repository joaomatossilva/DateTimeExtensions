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
    [Locale("nb-NO")]
    public class NB_NOHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public NB_NOHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.MaundyThursday);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(ChristianHolidays.Easter);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(ConstitutionDay);
            this.InnerHolidays.Add(ChristianHolidays.Ascension);
            this.InnerHolidays.Add(ChristianHolidays.Pentecost);
            this.InnerHolidays.Add(ChristianHolidays.PentecostMonday);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(ChristianHolidays.StStephansDay);
        }

        private static Holiday constituionDay;

        public static Holiday ConstitutionDay
        {
            get
            {
                if (constituionDay == null)
                {
                    constituionDay = new FixedHoliday("Constitution Day", 5, 17);
                }
                return constituionDay;
            }
        }
    }
}