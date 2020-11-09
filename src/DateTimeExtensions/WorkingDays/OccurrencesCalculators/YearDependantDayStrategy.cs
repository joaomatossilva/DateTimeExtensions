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

namespace DateTimeExtensions.WorkingDays.OccurrencesCalculators
{
    public class YearDependantDayStrategy : ICalculateDayStrategy
    {
        private readonly Func<int, bool> yearCondition;
        private readonly ICalculateDayStrategy baseCalculateDayStrategy;

        public YearDependantDayStrategy(Func<int, bool> yearCondition, ICalculateDayStrategy baseCalculateDayStrategy)
        {
            this.yearCondition = yearCondition;
            this.baseCalculateDayStrategy = baseCalculateDayStrategy;
        }

        public DateTime? GetInstance(int year) =>
            this.yearCondition(year) ? this.baseCalculateDayStrategy.GetInstance(year) : null;

        public bool IsInstanceOf(DateTime date) =>
            this.yearCondition(date.Year) && this.baseCalculateDayStrategy.IsInstanceOf(date);
    }
}