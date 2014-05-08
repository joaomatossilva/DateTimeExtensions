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
using System.Globalization;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.WorkingDays
{
    public class FixedHoliday : Holiday
    {
        private readonly DayInYear day;

        public FixedHoliday(string name, DayInYear day)
            : base(name)
        {
            this.day = day;
        }

        public FixedHoliday(string name, int month, int day, Calendar calendar)
            : base(name)
        {
            this.day = new DayInYear(month, day, calendar);
        }

        public FixedHoliday(string name, int month, int day)
            : this(name, month, day, new GregorianCalendar())
        {
        }

        public override DateTime? GetInstance(int year)
        {
            return day.GetDayOnYear(year);
        }

        public override bool IsInstanceOf(DateTime date)
        {
            return day.IsTheSameDay(date);
        }
    }
}