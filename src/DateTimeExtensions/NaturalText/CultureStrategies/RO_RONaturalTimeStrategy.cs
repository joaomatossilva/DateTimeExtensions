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

namespace DateTimeExtensions.NaturalText.CultureStrategies
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Public_holidays_in_Romania
    /// https://ro.wikipedia.org/wiki/S%C4%83rb%C4%83tori_publice_%C3%AEn_Rom%C3%A2nia
    /// </summary>
    [Locale("ro-RO")]
    public class RO_RONaturalTimeStrategy: NaturalTimeStrategyBase
    {
        protected override string YearText
        {
            get { return "an"; }
        }

        protected override string MonthText
        {
            get { return "luna"; }
        }

        protected override string DayText
        {
            get { return "zi"; }
        }

        protected override string HourText
        {
            get { return "ora"; }
        }

        protected override string MinuteText
        {
            get { return "minut"; }
        }

        protected override string SecondText
        {
            get { return "secunda"; }
        }

        protected override string Pluralize(string text, int value)
        {
            if (text.Equals("an", StringComparison.OrdinalIgnoreCase))
            {
                return "ani";
            }
            if (text.Equals("luna", StringComparison.OrdinalIgnoreCase))
            {
                return "luni";
            }
            if (text.Equals("zi", StringComparison.OrdinalIgnoreCase))
            {
                return "zile";
            }
            if (text.Equals("ora", StringComparison.OrdinalIgnoreCase))
            {
                return "ore";
            }
            if (text.Equals("minut", StringComparison.OrdinalIgnoreCase))
            {
                return text + "e";
            }
            if (text.Equals("secunda", StringComparison.OrdinalIgnoreCase))
            {
                return "secunde";
            }
            return base.Pluralize(text, value);
        }
    }
}