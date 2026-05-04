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
        protected IList<NamedDay> InnerObservances { get; } = new List<NamedDay>();

        private readonly ConcurrentLazyDictionary<int, IDictionary<DateTime, NamedDay>> observancesCache = new();

        public bool IsHoliDay(DateTime day)
        {
            var map = observancesCache.GetOrAdd(day.Year, () => BuildObservancesMap(day.Year));
            return map.Any(m => m.Key.Date == day.Date);
        }

        protected virtual IDictionary<DateTime, NamedDay> BuildObservancesMap(int year)
        {
            return this.InnerObservances.Select(h => new {Date = h.GetInstance(year), NamedDay = h})
                .Where(h => h.Date.HasValue)
                .GroupBy(h => h.Date).Select(g => new {Date = g.Key, g.First().NamedDay})
                .ToDictionary(k => k.Date.Value, v => v.NamedDay);
        }

        public virtual IEnumerable<NamedDay> Observances => InnerObservances.AsEnumerable();

        public virtual IEnumerable<NamedDay> GetObservancesOfYear(int year)
        {
            var map = observancesCache.GetOrAdd(year, () => BuildObservancesMap(year));
            return map.Select(m => m.Value);
        }
    }
}
