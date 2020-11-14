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

        public bool IsHoliday(DateTime day) => GetObservancesMap(day.Year)
            .Any(m => m.Key.Date == day.Date);

        protected virtual IEnumerable<KeyValuePair<DateTime, CalendarDay>> GetYearObservances(int year)
        {
            return from innerCalendarDay in InnerCalendarDays
                let day = innerCalendarDay.Day.GetInstance(year)
                where day != null
                select new KeyValuePair<DateTime, CalendarDay>((DateTime) day, innerCalendarDay);
        }
        
        private IDictionary<DateTime, CalendarDay> GetObservancesMap(int year)
        {
            IDictionary<DateTime, CalendarDay> Builder(int yearToMap) => GetYearObservances(yearToMap)
                .GroupBy(h => h.Key)
                .Select(g => new {Date = g.Key, CalendarDay = g.First().Value})
                .ToDictionary(k => k.Date, v => v.CalendarDay);

            return calendarDaysObservancesCache.GetOrAdd(year, () => Builder(year));
        }

        public virtual IEnumerable<CalendarDay> Days => InnerCalendarDays.AsEnumerable();

        public virtual IEnumerable<CalendarDay> GetAllCalendarDaysOfYear(int year) =>
            GetObservancesMap(year).Select(m => m.Value);
    }
}