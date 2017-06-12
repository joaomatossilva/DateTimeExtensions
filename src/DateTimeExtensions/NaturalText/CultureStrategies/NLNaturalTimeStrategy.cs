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

namespace DateTimeExtensions.NaturalText.CultureStrategies
{
    [Locale("nl-NL")]
    [Locale("nl-BE")]
    public class NLNaturalTimeStrategyBase : NaturalTimeStrategyBase
    {
        private const string PluralDayText = "dagen";

        private const string PluralMinuteText = "minuten";

        private const string PluralSecondText = "seconden";

        private const string PluralMonthText = "maanden";

        protected override string YearText
        {
            get { return "jaar"; }
        }

        protected override string MonthText
        {
            get { return "maand"; }
        }

        protected override string DayText
        {
            get { return "dag"; }
        }

        protected override string HourText
        {
            get { return "uur"; }
        }

        protected override string MinuteText
        {
            get { return "minuut"; }
        }

        protected override string SecondText
        {
            get { return "seconde"; }
        }

        protected override string GetYearsText(int value)
        {
            return string.Format("{0} {1}", value, this.YearText);
        }

        protected override string GetMonthsText(int value)
        {
            return string.Format("{0} {1}", value, value == 1 ? this.MonthText : PluralMonthText);
        }

        protected override string GetDaysText(int value)
        {
            return string.Format("{0} {1}", value, value == 1 ? this.DayText : PluralDayText);
        }

        protected override string GetHoursText(int value)
        {
            return string.Format("{0} {1}", value, this.HourText);
        }

        protected override string GetMinutesText(int value)
        {
            return string.Format("{0} {1}", value, value == 1 ? this.MinuteText : PluralMinuteText);
        }

        protected override string GetSecondsText(int value)
        {
            return string.Format("{0} {1}", value, value == 1 ? this.SecondText : PluralSecondText);
        }


        protected override string Pluralize(string text, int value)
        {
            // Pluralization is dealt with on a case-by-case basis.
            throw new NotImplementedException();
        }
    }
}