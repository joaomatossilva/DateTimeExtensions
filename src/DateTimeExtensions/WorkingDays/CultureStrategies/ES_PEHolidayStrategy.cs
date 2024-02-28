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
        private readonly static IEnumerable<Holiday> fixedHolidays = new Holiday[]
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
                this.InnerHolidays.Add(i);
            }
        }

        private static Holiday flagDay;

        public static Holiday FlagDay
        {
            get
            {
                if(flagDay == null) 
                {
                    flagDay = new FixedHoliday("The Flag Day", 6, 7);
                }
                return flagDay;
            }
        }
        private static Holiday farmersDay;
        
        public static Holiday FarmersDay
        {
            get
            {
                if(farmersDay == null)
                {
                    farmersDay = new FixedHoliday("The farmers day", 6, 14);
                }
                return farmersDay;
            }
        }

        private static Holiday independenceDay;

        public static Holiday IndependenceDay
        {
            get
            {
                if(independenceDay == null)
                {
                    independenceDay = new FixedHoliday("Independece Day", 7, 28);
                }
                return independenceDay;
            }
        }

        private static Holiday battleofAngamos;

        public static Holiday BattleofAngamos
        {
            get
            {
                if(battleofAngamos == null)
                {
                    battleofAngamos = new FixedHoliday("The Battle of Angamos", 10, 8);
                }
                return battleofAngamos;
            }
        }

        private static Holiday nationalDignityDay;

        public static Holiday NationalDignityDay
        {
            get
            {
                if(nationalDignityDay == null)
                {
                    nationalDignityDay = new FixedHoliday("The National Dignity Day", 10, 9);
                }
                return nationalDignityDay;
            }
        }

        private static Holiday battleOfAyacucho;
        public static Holiday BattleOfAyacucho
        {
            get
            {
                if(battleOfAyacucho == null)
                {
                    battleOfAyacucho = new FixedHoliday("The Battle of Ayacucho", 12, 9);
                }
                return battleOfAyacucho;
            }
        }
    }
}
