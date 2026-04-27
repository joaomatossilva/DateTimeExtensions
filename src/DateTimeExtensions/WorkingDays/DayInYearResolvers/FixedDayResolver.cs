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
using System.Globalization;

namespace DateTimeExtensions.WorkingDays.DayInYearResolvers
{
    /// <summary>
    /// Representation of a calendar day that occurs on the same date every year.
    /// </summary>
    public class FixedDayResolver : IDayResolver
    {
        private readonly Func<int, DateTime?> holidayResolver;

        public FixedDayResolver(Func<int, DateTime?> holidayResolver)
        {
            this.holidayResolver = holidayResolver;
        }

        public FixedDayResolver(DayInYear day)
            : this(year => day.GetDayOnYear(year))
        {
        }

        public FixedDayResolver(int month, int day, Calendar calendar)
            : this(year => new DayInYear(month, day, calendar).GetDayOnYear(year))
        {
        }

        public FixedDayResolver(int month, int day)
            : this(month, day, new GregorianCalendar())
        {
        }

        public DateTime? GetInstance(int year)
        {
            return holidayResolver(year);
        }

        public bool IsInstanceOf(DateTime date)
        {
            var holidayDate = this.holidayResolver(date.Year);
            return holidayDate != null && holidayDate.Value.Date == date.Date;
        }
    }
}