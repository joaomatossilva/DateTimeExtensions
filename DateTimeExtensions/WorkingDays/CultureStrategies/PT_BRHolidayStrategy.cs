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
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("pt-BR")]
    public class PT_BRHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public PT_BRHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.Carnival);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(ChristianHolidays.Easter);
            this.InnerHolidays.Add(ChristianHolidays.CorpusChristi);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(ChristianHolidays.DayOfTheDead);
            this.InnerHolidays.Add(TiradentesDay);
            this.InnerHolidays.Add(IndependanceDay);
            this.InnerHolidays.Add(OurLadyOfAparecida);
            this.InnerHolidays.Add(RepublicDay);
        }

        private static Holiday tiradentesDay;

        public static Holiday TiradentesDay
        {
            get
            {
                if (tiradentesDay == null)
                {
                    tiradentesDay = new FixedHoliday("TiradentesDay", 4, 21);
                }
                return tiradentesDay;
            }
        }

        private static Holiday independanceDay;

        public static Holiday IndependanceDay
        {
            get
            {
                if (independanceDay == null)
                {
                    independanceDay = new FixedHoliday("IndependanceDay", 9, 7);
                }
                return independanceDay;
            }
        }

        private static Holiday ourLadyOfAparecida;

        public static Holiday OurLadyOfAparecida
        {
            get
            {
                if (ourLadyOfAparecida == null)
                {
                    ourLadyOfAparecida = new FixedHoliday("OurLadyOfAparecida", 10, 12);
                }
                return ourLadyOfAparecida;
            }
        }

        private static Holiday republicDay;

        public static Holiday RepublicDay
        {
            get
            {
                if (republicDay == null)
                {
                    republicDay = new FixedHoliday("RepublicDay", 11, 15);
                }
                return republicDay;
            }
        }
    }
}