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
    public class NthDayAfterDayStrategy : ICalculateDayStrategy
    {
        private readonly int count;
        private readonly ICalculateDayStrategy baseCalculatorStrategy;
        private readonly ConcurrentLazyDictionary<int, DateTime?> dayCache;

        public NthDayAfterDayStrategy(int count, int month, int day)
            : this(count, new FixedDayStrategy(month, day))
        {
        }

        public NthDayAfterDayStrategy(int count, DayInYear dayInYear)
            : this(count, new FixedDayStrategy(dayInYear))
        {
        }

        public NthDayAfterDayStrategy(int count, ICalculateDayStrategy baseCalculatorStrategy)
        {
            if (count == 0)
            {
                throw new ArgumentException("count must not be 0", nameof(count));
            }

            this.count = count;
            this.baseCalculatorStrategy = baseCalculatorStrategy ?? throw new ArgumentException("baseCalculatorStrategy cannot be null", nameof(baseCalculatorStrategy));
            dayCache = new ConcurrentLazyDictionary<int, DateTime?>();
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

        private DateTime? CalculateDayInYear(int year) =>
            baseCalculatorStrategy.GetInstance(year)?.AddDays(count);
    }
}