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
using System.Globalization;
using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays.CultureStrategies;

namespace DateTimeExtensions.WorkingDays
{
    public class WorkingDayCultureInfo : IWorkingDayCultureInfo
    {
        private string name;
        private IWorkingDayOfWeekStrategy workingDayOfWeekStrategy;
        private IHolidayStrategy holidayStrategy;

        public WorkingDayCultureInfo() : this(CultureInfo.CurrentCulture.Name)
        {
        }

        public WorkingDayCultureInfo(string name)
        {
            this.name = name;
            this.LocateWorkingDayOfWeekStrategy = DefaultLocateWorkingDayOfWeekStrategy;
            this.LocateHolidayStrategy = DefaultLocateHolidayStrategy;
        }

        public bool IsHoliday(DateTime date)
        {
            return holidayStrategy.IsHoliDay(date);
        }

        public bool IsWorkingDay(DateTime date)
        {
            if (!this.workingDayOfWeekStrategy.IsWorkingDay(date.DayOfWeek))
            {
                return false;
            }
            return !IsHoliday(date);
        }

        public bool IsWorkingDay(DayOfWeek dayOfWeek)
        {
            return this.workingDayOfWeekStrategy.IsWorkingDay(dayOfWeek);
        }

        public IEnumerable<Holiday> Holidays
        {
            get { return this.holidayStrategy.Holidays; }
        }

        public IEnumerable<Holiday> GetHolidaysOfYear(int year)
        {
            return this.holidayStrategy.GetHolidaysOfYear(year);
        }

        public string Name
        {
            get { return name; }
        }

        private Func<string, IWorkingDayOfWeekStrategy> locateWorkingDayOfWeekStrategy;

        public Func<string, IWorkingDayOfWeekStrategy> LocateWorkingDayOfWeekStrategy
        {
            get { return locateWorkingDayOfWeekStrategy; }
            set
            {
                if (value != null)
                {
                    locateWorkingDayOfWeekStrategy = value;
                    workingDayOfWeekStrategy = locateWorkingDayOfWeekStrategy(name);
                }
                else
                {
                    throw new ArgumentNullException("value");
                }
            }
        }

        private Func<string, IHolidayStrategy> locateHolidayWeekStrategy;

        public Func<string, IHolidayStrategy> LocateHolidayStrategy
        {
            get { return locateHolidayWeekStrategy; }
            set
            {
                if (value != null)
                {
                    locateHolidayWeekStrategy = value;
                    holidayStrategy = locateHolidayWeekStrategy(name);
                }
                else
                {
                    throw new ArgumentNullException("value");
                }
            }
        }

        public static readonly Func<string, IHolidayStrategy> DefaultLocateHolidayStrategy =
            name =>
                LocaleImplementationLocator.FindImplementationOf<IHolidayStrategy>(name) ?? new DefaultHolidayStrategy();

        public static readonly Func<string, IWorkingDayOfWeekStrategy> DefaultLocateWorkingDayOfWeekStrategy =
            name =>
                LocaleImplementationLocator.FindImplementationOf<IWorkingDayOfWeekStrategy>(name) ??
                new DefaultWorkingDayOfWeekStrategy();
    }
}