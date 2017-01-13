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

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    public abstract class HolidayStrategyBase : IHolidayStrategy
    {
        protected readonly IList<Holiday> InnerHolidays;

        private readonly IDictionary<int, IDictionary<DateTime, Holiday>> holidaysObservancesCache;

        protected HolidayStrategyBase()
        {
            holidaysObservancesCache = new Dictionary<int, IDictionary<DateTime, Holiday>>();
            this.InnerHolidays = new List<Holiday>();
        }

        public bool IsHoliDay(DateTime day)
        {
            this.CheckYearHasMap(day.Year);
            return holidaysObservancesCache[day.Year].Any(m => m.Key.Date == day.Date);
        }

        private void CheckYearHasMap(int year)
        {
            if (!holidaysObservancesCache.ContainsKey(year))
            {
                holidaysObservancesCache.Add(year, this.BuildObservancesMap(year));
            }
        }

        protected virtual IDictionary<DateTime, Holiday> BuildObservancesMap(int year)
        {
            return this.InnerHolidays.Select(h => new {Date = h.GetInstance(year), Holiday = h})
                .Where(h => h.Date.HasValue)
                .GroupBy(h => h.Date).Select(g => new {Date = g.Key, g.First().Holiday})
                .ToDictionary(k => k.Date.Value, v => v.Holiday);
        }

        public virtual IEnumerable<Holiday> Holidays
        {
            get { return InnerHolidays.AsEnumerable(); }
        }

        public virtual IEnumerable<Holiday> GetHolidaysOfYear(int year)
        {
            this.CheckYearHasMap(year);
            return holidaysObservancesCache[year].Select(m => m.Value);
        }
    }
}