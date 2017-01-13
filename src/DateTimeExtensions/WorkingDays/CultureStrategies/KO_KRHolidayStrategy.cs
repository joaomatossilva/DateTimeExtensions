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
using System.Globalization;
using System.Linq;
using System.Text;
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("ko-KR")]
    public class KO_KRHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        private static readonly Calendar KoreanLunisolarCalendar = new KoreanLunisolarCalendar();

        public KO_KRHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(Samiljeol);
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay);
            this.InnerHolidays.Add(SeokgaTansinil);
            this.InnerHolidays.Add(Hyeonchungil);
            this.InnerHolidays.Add(Gwangbokjeol);
            this.InnerHolidays.Add(Gaecheonjeol);
            this.InnerHolidays.Add(Hangulnal);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);

            // Add these later for substitute holiday rule application when overlapped with other holidays.
            this.InnerHolidays.Add(Seolnal);
            this.InnerHolidays.Add(Chuseok);
            this.InnerHolidays.Add(Eorininal);
        }

        protected override IDictionary<DateTime, Holiday> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Holiday> holidayMap = new Dictionary<DateTime, Holiday>();
            foreach (var innerHoliday in InnerHolidays)
            {
                var date = innerHoliday.GetInstance(year);
                if (date.HasValue)
                {
                    if (innerHoliday == Seolnal || innerHoliday == Chuseok) {
                        DateTime[] holidays = new DateTime[] { 
                            date.Value.AddDays(-1),
                            date.Value, 
                            date.Value.AddDays(1)
                        };
                        AddSubstituteHoliday(holidayMap, holidays, innerHoliday);
                        foreach (DateTime holiday in holidays)
                        {
                            holidayMap.Add(holiday, innerHoliday);
                        }
                    }
                    else if (innerHoliday == Eorininal)
                    {
                        // Special substitute holiday rule for Eorininal(May 5, children's day)
                        // effective since Oct. 29, 2013.
                        DateTime childrensDay = date.Value;
                        Holiday overlappedHoliday = null;
                        while (childrensDay.DayOfWeek == DayOfWeek.Saturday ||
                                childrensDay.DayOfWeek == DayOfWeek.Sunday ||
                                holidayMap.TryGetValue(childrensDay, out overlappedHoliday))
                        {
                            childrensDay = childrensDay.AddDays(1);
                        }
                        holidayMap.Add(childrensDay, innerHoliday);
                    }
                    else
                    {
                        holidayMap.Add(date.Value, innerHoliday);
                    }
                }
            }
            return holidayMap;
        }

        // Special substitute holiday rule for Seol(lunisolar new year) and Chuseok(15th of 8th lunisolar month)
        // effective since Oct. 29, 2013.
        private void AddSubstituteHoliday(IDictionary<DateTime, Holiday> holidayMap, DateTime[] dates, Holiday holiday)
        {
            foreach (DateTime date in dates)
            {
                Holiday overlappedHoliday = null;
                if (date.DayOfWeek == DayOfWeek.Sunday || 
                    holidayMap.TryGetValue(date, out overlappedHoliday) && overlappedHoliday != holiday)
                {
                    DateTime substituteDay = dates.Last().AddDays(1);
                    while (substituteDay.DayOfWeek == DayOfWeek.Sunday ||
                            holidayMap.TryGetValue(date, out overlappedHoliday) && overlappedHoliday != holiday)
                    {
                        substituteDay = substituteDay.AddDays(1);
                    }
                    holidayMap.Add(substituteDay, holiday);
                }
            }
        }

        private static Holiday seolnal;

        public static Holiday Seolnal
        {
            get
            {
                if (seolnal == null)
                {
                    seolnal = new FixedHoliday("Seolnal", 1, 1, KoreanLunisolarCalendar);
                }
                return seolnal;
            }
        }

        private static Holiday samiljeol;

        public static Holiday Samiljeol
        {
            get
            {
                if (samiljeol == null)
                {
                    samiljeol = new FixedHoliday("Samiljeol", 3, 1);
                }
                return samiljeol;
            }
        }

        private static Holiday eorininal;

        public static Holiday Eorininal
        {
            get
            {
                if (eorininal == null)
                {
                    eorininal = new FixedHoliday("Eorininal", 5, 5);
                }
                return eorininal;
            }
        }

        private static Holiday seokgatansinil;

        public static Holiday SeokgaTansinil
        {
            get
            {
                if (seokgatansinil == null)
                {
                    seokgatansinil = new FixedHoliday("SeokgaTansinil", 4, 8, KoreanLunisolarCalendar);
                }
                return seokgatansinil;
            }
        }

        private static Holiday hyeonchungil;

        public static Holiday Hyeonchungil
        {
            get
            {
                if (hyeonchungil == null)
                {
                    hyeonchungil = new FixedHoliday("Hyeonchungil", 6, 6);
                }
                return hyeonchungil;
            }
        }

        private static Holiday gwangbokjeol;

        public static Holiday Gwangbokjeol
        {
            get
            {
                if (gwangbokjeol == null)
                {
                    gwangbokjeol = new FixedHoliday("Gwangbokjeol", 8, 15);
                }
                return gwangbokjeol;
            }
        }

        private static Holiday chuseok;

        public static Holiday Chuseok
        {
            get
            {
                if (chuseok == null)
                {
                    chuseok = new FixedHoliday("Chuseok", 8, 15, KoreanLunisolarCalendar);
                }
                return chuseok;
            }
        }

        private static Holiday gaecheonjeol;

        public static Holiday Gaecheonjeol
        {
            get
            {
                if (gaecheonjeol == null)
                {
                    gaecheonjeol = new FixedHoliday("Gaecheonjeol", 10, 3);
                }
                return gaecheonjeol;
            }
        }

        private static Holiday hangulnal;

        public static Holiday Hangulnal
        {
            get
            {
                if (hangulnal == null)
                {
                    hangulnal = new FixedHoliday("Hangulnal", 10, 9);
                }
                return hangulnal;
            }
        }
    }
}