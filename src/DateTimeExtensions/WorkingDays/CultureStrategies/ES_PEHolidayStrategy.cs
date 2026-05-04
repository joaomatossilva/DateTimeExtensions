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
using System.Collections.Generic;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("es-PE")]
    public class ES_PEHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        private readonly static IEnumerable<NamedDay> fixedHolidays = new NamedDay[]
        {
            GlobalHolidays.NewYear,
            GlobalHolidays.InternationalWorkersDay,
            FlagDay,
            FarmersDay,
            ChristianHolidays.StsPeterAndPaul,
            IndependenceDay,
            ChristianHolidays.Assumption,
            ChristianHolidays.StRoseOfLima,
            BattleofAngamos,
            NationalDignityDay,
            ChristianHolidays.AllSaints,
            ChristianHolidays.DayOfTheDead,
            ChristianHolidays.ImaculateConception,
            BattleOfAyacucho,
            ChristianHolidays.ChristmasEve,
            ChristianHolidays.Christmas,
            GlobalHolidays.NewYearsEve
        };
        public ES_PEHolidayStrategy()
        {
            foreach(var i in fixedHolidays)
            {
                this.InnerObservances.AddHoliday(i);
            }
        }

        private static NamedDay flagDay;

        public static NamedDay FlagDay
        {
            get
            {
                if(flagDay == null) 
                {
                    flagDay = new NamedDay("The Flag Day", new FixedDayResolver(6, 7));
                }
                return flagDay;
            }
        }
        private static NamedDay farmersDay;
        
        public static NamedDay FarmersDay
        {
            get
            {
                if(farmersDay == null)
                {
                    farmersDay = new NamedDay("The farmers day", new FixedDayResolver(6, 14));
                }
                return farmersDay;
            }
        }

        private static NamedDay independenceDay;

        public static NamedDay IndependenceDay
        {
            get
            {
                if(independenceDay == null)
                {
                    independenceDay = new NamedDay("Independece Day", new FixedDayResolver(7, 28));
                }
                return independenceDay;
            }
        }

        private static NamedDay battleofAngamos;

        public static NamedDay BattleofAngamos
        {
            get
            {
                if(battleofAngamos == null)
                {
                    battleofAngamos = new NamedDay("The Battle of Angamos", new FixedDayResolver(10, 8));
                }
                return battleofAngamos;
            }
        }

        private static NamedDay nationalDignityDay;

        public static NamedDay NationalDignityDay
        {
            get
            {
                if(nationalDignityDay == null)
                {
                    nationalDignityDay = new NamedDay("The National Dignity Day", new FixedDayResolver(10, 9));
                }
                return nationalDignityDay;
            }
        }

        private static NamedDay battleOfAyacucho;
        public static NamedDay BattleOfAyacucho
        {
            get
            {
                if(battleOfAyacucho == null)
                {
                    battleOfAyacucho = new NamedDay("The Battle of Ayacucho", new FixedDayResolver(12, 9));
                }
                return battleOfAyacucho;
            }
        }
    }
}
