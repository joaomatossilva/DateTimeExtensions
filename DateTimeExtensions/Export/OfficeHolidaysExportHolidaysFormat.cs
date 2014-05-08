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
using System.IO;
using System.Linq;
using System.Text;
using DateTimeExtensions.WorkingDays;

namespace DateTimeExtensions.Export
{
    public class OfficeHolidaysExportHolidaysFormat : IExportHolidaysFormat
    {
        private const string HolidayLineFormat = "{0}, {1:yyyy'/'MM'/'dd}";
        private const string HeaderLineFomat = "[{0}] {1}";

        public void Export(WorkingDayCultureInfo dateTimeCultureInfo, int year, TextWriter writer)
        {
            var holidays = dateTimeCultureInfo.GetHolidaysOfYear(year);
            writer.WriteLine(HeaderLineFomat, dateTimeCultureInfo.Name, holidays.Count());
            foreach (var holiday in holidays)
            {
                var instance = holiday.GetInstance(year);
                if (instance.HasValue)
                {
                    writer.WriteLine(HolidayLineFormat, holiday.Name, instance);
                }
            }
        }
    }
}