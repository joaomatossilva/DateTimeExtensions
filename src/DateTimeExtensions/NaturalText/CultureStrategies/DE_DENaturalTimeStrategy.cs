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

namespace DateTimeExtensions.NaturalText.CultureStrategies
{
    [Locale("de-DE")]
    public class DE_DENaturalTimeStrategy : NaturalTimeStrategyBase
    {
        protected override string YearText
        {
            get { return "Jahr"; }
        }

        protected override string MonthText
        {
            get { return "Monat"; }
        }

        protected override string DayText
        {
            get { return "Tag"; }
        }

        protected override string HourText
        {
            get { return "Stunde"; }
        }

        protected override string MinuteText
        {
            get { return "Minute"; }
        }

        protected override string SecondText
        {
            get { return "Sekunde"; }
        }

        protected override string Pluralize(string text, int value)
        {
            if (text.EndsWith("e"))
            {
                return text + "n";
            }
            return text + "e";
        }
    }
}
