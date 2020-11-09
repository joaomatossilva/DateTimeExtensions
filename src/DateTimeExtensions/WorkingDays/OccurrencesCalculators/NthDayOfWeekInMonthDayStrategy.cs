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

namespace DateTimeExtensions.WorkingDays.OccurrencesCalculators
{
    public enum CountDirection
    {
        FromFirst,
        FromLast
    };

    public class NthDayOfWeekInMonthDayStrategy : ICalculateDayStrategy
    {
        private readonly int count;
        private readonly DayOfWeek dayOfWeek;
        private readonly CountDirection direction;
        private readonly int month;
        private readonly ConcurrentLazyDictionary<int, DateTime> dayCache;

        public NthDayOfWeekInMonthDayStrategy(int count, DayOfWeek dayOfWeek, int month, CountDirection direction)
        {
            this.count = count;
            this.dayOfWeek = dayOfWeek;
            this.month = month;
            this.direction = direction;
            dayCache = new ConcurrentLazyDictionary<int, DateTime>();
        }

        public DateTime? GetInstance(int year)
        {
            return dayCache.GetOrAdd(year, () => CalculateDayInYear(year));
        }

        public bool IsInstanceOf(DateTime date)
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