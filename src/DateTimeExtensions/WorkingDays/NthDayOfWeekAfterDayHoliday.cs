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
    public class NthDayOfWeekAfterDayHoliday : Holiday
    {
        private readonly DayOfWeek dayOfWeek;
        private readonly int count;
        private readonly Holiday baseHoliday;
        private readonly IDictionary<int, DateTime?> dayCache;

        public NthDayOfWeekAfterDayHoliday(string name, int count, DayOfWeek dayOfWeek, int month, int day)
            : this(name, count, dayOfWeek, new FixedHoliday(name, month, day))
        {
        }

        public NthDayOfWeekAfterDayHoliday(string name, int count, DayOfWeek dayOfWeek, DayInYear dayInYear)
            : this(name, count, dayOfWeek, new FixedHoliday(name, dayInYear))
        {
        }

        public NthDayOfWeekAfterDayHoliday(string name, int count, DayOfWeek dayOfWeek, Holiday baseHoliday)
            : base(name)
        {
            if (count == 0)
            {
                throw new ArgumentException("count must not be 0", "count");
            }
            if (baseHoliday == null)
            {
                throw new ArgumentException("baseHoliday cannot be null", "baseHoliday");
            }
            this.count = count;
            this.dayOfWeek = dayOfWeek;
            this.baseHoliday = baseHoliday;
            dayCache = new Dictionary<int, DateTime?>();
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

        private DateTime? CalculateDayInYear(int year)
        {
            var startDate = baseHoliday.GetInstance(year);
            if (!startDate.HasValue)
            {
                return null;
            }
            /* this block should be uncomment if we should count the start day inclusive
             * example: 1st Sunday after easter. should count the next sunday, or the easter sunday? for now it makes more sence the next sunday
            if(startDate.Value.DayOfWeek == dayOfWeek && (count == -1 || count == 1))
            {
                return startDate;
            }
             */
            if (count > 0)
            {
                startDate = startDate.Value.NextDayOfWeek(dayOfWeek);
            }
            else
            {
                startDate = startDate.Value.LastDayOfWeek(dayOfWeek);
            }
            return startDate.Value.AddDays((count > 0 ? count - 1 : count + 1)*7);
        }
    }
}