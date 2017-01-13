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

namespace DateTimeExtensions.WorkingDays
{
    public class FixedHoliday : Holiday
    {
        private readonly Func<int, DateTime?> holidayResolver;

        public FixedHoliday(string name, Func<int, DateTime?> holidayResolver)
            : base(name)
        {
            this.holidayResolver = holidayResolver;
        }

        public FixedHoliday(string name, DayInYear day)
            : this(name, year => day.GetDayOnYear(year))
        {
        }

        public FixedHoliday(string name, int month, int day, Calendar calendar)
            : this(name, year => new DayInYear(month, day, calendar).GetDayOnYear(year))
        {
        }

        public FixedHoliday(string name, int month, int day)
            : this(name, month, day, new GregorianCalendar())
        {
        }

        public override DateTime? GetInstance(int year)
        {
            return holidayResolver(year);
        }

        public override bool IsInstanceOf(DateTime date)
        {
            var holidayDate = this.holidayResolver(date.Year);
            return holidayDate != null && holidayDate.Value.Date == date.Date;
        }
    }
}