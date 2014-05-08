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

namespace DateTimeExtensions.WorkingDays
{
    public enum CountDirection
    {
        FromFirst,
        FromLast
    };

    public class NthDayOfWeekInMonthHoliday : Holiday
    {
        private int count;
        private DayOfWeek dayOfWeek;
        private CountDirection direction;
        private int month;
        private IDictionary<int, DateTime> dayCache;

        public NthDayOfWeekInMonthHoliday(string name, int count, DayOfWeek dayOfWeek, int month,
            CountDirection direction)
            : base(name)
        {
            this.count = count;
            this.dayOfWeek = dayOfWeek;
            this.month = month;
            this.direction = direction;
            dayCache = new Dictionary<int, DateTime>();
        }

        public override DateTime? GetInstance(int year)
        {
            if (dayCache.ContainsKey(year))
            {
                return dayCache[year];
            }
            var day = CalculateDayInYear(year);
            dayCache.Add(year, day);
            return day;
        }

        public override bool IsInstanceOf(DateTime date)
        {
            var day = GetInstance(date.Year);
            return day.HasValue && date.Month == day.Value.Month && date.Day == day.Value.Day;
        }

        private DateTime CalculateDayInYear(int year)
        {
            if (direction == CountDirection.FromFirst)
            {
                DateTime firstDayInMonth = new DateTime(year, month, 1);
                var dayOfWeekInMonth = firstDayInMonth.FirstDayOfWeekOfTheMonth(dayOfWeek);
                int daysOffset = 7*(count - 1);
                return dayOfWeekInMonth.AddDays(daysOffset);
            }
            else
            {
                DateTime lastDayInMonth = new DateTime(year, month, 1);
                lastDayInMonth = lastDayInMonth.LastDayOfTheMonth();
                var dayOfWeekInMonth = lastDayInMonth.LastDayOfWeekOfTheMonth(dayOfWeek);
                int daysOffset = -7*(count - 1);
                return dayOfWeekInMonth.AddDays(daysOffset);
            }
        }
    }
}