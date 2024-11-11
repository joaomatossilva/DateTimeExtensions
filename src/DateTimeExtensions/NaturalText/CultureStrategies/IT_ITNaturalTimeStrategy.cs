#region License

// 
// Copyright (c) 2011-2012, Jo�o Matos Silva <kappy@acydburne.com.pt>
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
    [Locale("it-IT")]
    public class IT_ITNaturalTimeStrategy : NaturalTimeStrategyBase
    {
        protected override string YearText
        {
            get { return "Anno"; }
        }

        protected override string MonthText
        {
            get { return "Mese"; }
        }

        protected override string DayText
        {
            get { return "Giorno"; }
        }

        protected override string HourText
        {
            get { return "Ora"; }
        }

        protected override string MinuteText
        {
            get { return "Minuto"; }
        }

        protected override string SecondText
        {
            get { return "Secondo"; }
        }

        protected override string Pluralize(string text, int value)
        {
            // referring to hours
            if (text.EndsWith("a"))
            {
                return text.Remove(text.Length -1, 1) + "e";
            }

            // referring to years, months, days, minutes and seconds
            return text.Remove(text.Length -1, 1) + "i";
        }
    }
}