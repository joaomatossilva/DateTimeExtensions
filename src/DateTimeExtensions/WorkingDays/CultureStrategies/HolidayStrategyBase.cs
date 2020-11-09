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

using DateTimeExtensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    public abstract class HolidayStrategyBase : IHolidayStrategy
    {
        protected readonly IList<CalendarDay> InnerCalendarDays;

        private readonly ConcurrentLazyDictionary<int, IDictionary<DateTime, CalendarDay>> calendarDaysObservancesCache;

        protected HolidayStrategyBase()
        {
            calendarDaysObservancesCache = new ConcurrentLazyDictionary<int, IDictionary<DateTime, CalendarDay>>();
            this.InnerCalendarDays = new List<CalendarDay>();
        }

        public bool IsHoliDay(DateTime day)
        {
            var map = calendarDaysObservancesCache.GetOrAdd(day.Year, () => BuildObservancesMap(day.Year));
            return map.Any(m => m.Key.Date == day.Date);
        }

        protected virtual IDictionary<DateTime, CalendarDay> BuildObservancesMap(int year)
        {
            return this.InnerCalendarDays.Select(h => new {Date = h.Day.GetInstance(year), Holiday = h})
                .Where(h => h.Date.HasValue)
                .GroupBy(h => h.Date).Select(g => new {Date = g.Key, g.First().Holiday})
                .ToDictionary(k => k.Date.Value, v => v.Holiday);
        }

        public virtual IEnumerable<CalendarDay> Days
        {
            get { return InnerCalendarDays.AsEnumerable(); }
        }

        public virtual IEnumerable<CalendarDay> GetAllCalendarDaysOfYear(int year)
        {
            var map = calendarDaysObservancesCache.GetOrAdd(year, () => BuildObservancesMap(year));
            return map.Select(m => m.Value);
        }
    }
}