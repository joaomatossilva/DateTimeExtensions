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
using DateTimeExtensions.NaturalText;

namespace DateTimeExtensions
{
    public static class NaturalTimeExtensions
    {
        public static string ToNaturalText(this DateTime fromDate, DateTime toDate, INaturalTextCultureInfo cultureInfo)
        {
            return ToNaturalText(fromDate, toDate, true, cultureInfo);
        }

        public static string ToNaturalText(this DateTime fromDate, DateTime toDate)
        {
            return ToNaturalText(fromDate, toDate, true, new NaturalTextCultureInfo());
        }

        public static string ToNaturalText(this DateTime fromDate, DateTime toDate, bool round,
            INaturalTextCultureInfo cultureInfo)
        {
            var dateDiff = fromDate.GetDiff(toDate);
            return cultureInfo.ToNaturalText(dateDiff, round);
        }

        public static string ToNaturalText(this DateTime fromDate, DateTime toDate, bool round)
        {
            return ToNaturalText(fromDate, toDate, round, new NaturalTextCultureInfo());
        }

        public static string ToExactNaturalText(this DateTime fromDate, DateTime toDate,
            INaturalTextCultureInfo cultureInfo)
        {
            var dateDiff = fromDate.GetDiff(toDate);
            return cultureInfo.ToExactNaturalText(dateDiff);
        }

        public static string ToExactNaturalText(this DateTime fromDate, DateTime toDate)
        {
            return ToExactNaturalText(fromDate, toDate, new NaturalTextCultureInfo());
        }

        public static DateDiff GetDiff(this DateTime fromDate, DateTime toDate)
        {
            return toDate >= fromDate ? new DateDiff(fromDate, toDate) : new DateDiff(toDate, fromDate);
        }
    }
}