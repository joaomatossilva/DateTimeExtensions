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

        private static NamedDay tiradentesDay;

        public static NamedDay TiradentesDay
        {
            get
            {
                if (tiradentesDay == null)
                {
                    tiradentesDay = new NamedDay("TiradentesDay", new FixedDayResolver(4, 21));
                }
                return tiradentesDay;
            }
        }

        private static NamedDay independanceDay;

        public static NamedDay IndependanceDay
        {
            get
            {
                if (independanceDay == null)
                {
                    independanceDay = new NamedDay("IndependanceDay", new FixedDayResolver(9, 7));
                }
                return independanceDay;
            }
        }

        private static NamedDay ourLadyOfAparecida;

        public static NamedDay OurLadyOfAparecida
        {
            get
            {
                if (ourLadyOfAparecida == null)
                {
                    ourLadyOfAparecida = new NamedDay("OurLadyOfAparecida", new FixedDayResolver(10, 12));
                }
                return ourLadyOfAparecida;
            }
        }

        private static NamedDay republicDay;

        public static NamedDay RepublicDay
        {
            get
            {
                if (republicDay == null)
                {
                    republicDay = new NamedDay("RepublicDay", new FixedDayResolver(11, 15));
                }
                return republicDay;
            }
        }
    }
}