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
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(Samiljeol);
            this.InnerObservances.AddHoliday(GlobalHolidays.InternationalWorkersDay);
            this.InnerObservances.AddHoliday(SeokgaTansinil);
            this.InnerObservances.AddHoliday(Hyeonchungil);
            this.InnerObservances.AddHoliday(Gwangbokjeol);
            this.InnerObservances.AddHoliday(Gaecheonjeol);
            this.InnerObservances.AddHoliday(Hangulnal);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);

            // Add these later for substitute holiday rule application when overlapped with other holidays.
            this.InnerObservances.AddHoliday(Seolnal);
            this.InnerObservances.AddHoliday(Chuseok);
            this.InnerObservances.AddHoliday(Eorininal);
        }

        protected override IDictionary<DateTime, Observance> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Observance> holidayMap = new Dictionary<DateTime, Observance>();
            foreach (var innerHoliday in InnerObservances)
            {
                var date = innerHoliday.CalendarDay.GetInstance(year);
                if (date.HasValue)
                {
                    if (innerHoliday.CalendarDay == Seolnal || innerHoliday.CalendarDay == Chuseok) {
                        DateTime[] holidays = new DateTime[] { 
                            date.Value.AddDays(-1),
                            date.Value, 
                            date.Value.AddDays(1)
                        };
                        AddSubstituteHoliday(holidayMap, holidays, innerHoliday.CalendarDay);
                        foreach (DateTime holiday in holidays)
                        {
                            holidayMap.Add(holiday, new Observance(new NamedDay(innerHoliday.CalendarDay.Name, new FixedDayResolver(holiday.Month, holiday.Day)), true));
                        }
                    }
                    else if (innerHoliday.CalendarDay == Eorininal)
                    {
                        // Special substitute holiday rule for Eorininal(May 5, children's day)
                        // effective since Oct. 29, 2013.
                        DateTime childrensDay = date.Value;
                        Observance overlappedHoliday = null;
                        while (childrensDay.DayOfWeek == DayOfWeek.Saturday ||
                                childrensDay.DayOfWeek == DayOfWeek.Sunday ||
                                holidayMap.TryGetValue(childrensDay, out overlappedHoliday))
                        {
                            childrensDay = childrensDay.AddDays(1);
                        }
                        holidayMap.Add(childrensDay, new Observance(new NamedDay(innerHoliday.CalendarDay.Name, new FixedDayResolver(childrensDay.Month, childrensDay.Day)), true));
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
        private void AddSubstituteHoliday(IDictionary<DateTime, Observance> holidayMap, DateTime[] dates, NamedDay holiday)
        {
            foreach (DateTime date in dates)
            {
                Observance overlappedHoliday = null;
                if (date.DayOfWeek == DayOfWeek.Sunday || 
                    holidayMap.TryGetValue(date, out overlappedHoliday) && overlappedHoliday.CalendarDay != holiday)
                {
                    DateTime substituteDay = dates.Last().AddDays(1);
                    while (substituteDay.DayOfWeek == DayOfWeek.Sunday ||
                            holidayMap.TryGetValue(date, out overlappedHoliday) && overlappedHoliday.CalendarDay != holiday)
                    {
                        substituteDay = substituteDay.AddDays(1);
                    }
                    holidayMap.Add(substituteDay, new Observance(new NamedDay(holiday.Name, new FixedDayResolver(substituteDay.Month, substituteDay.Day)), true));
                }
            }
        }

        private static NamedDay seolnal;

        public static NamedDay Seolnal
        {
            get
            {
                if (seolnal == null)
                {
                    seolnal = new NamedDay("Seolnal", new FixedDayResolver(1, 1, KoreanLunisolarCalendar));
                }
                return seolnal;
            }
        }

        private static NamedDay samiljeol;

        public static NamedDay Samiljeol
        {
            get
            {
                if (samiljeol == null)
                {
                    samiljeol = new NamedDay("Samiljeol", new FixedDayResolver(3, 1));
                }
                return samiljeol;
            }
        }

        private static NamedDay eorininal;

        public static NamedDay Eorininal
        {
            get
            {
                if (eorininal == null)
                {
                    eorininal = new NamedDay("Eorininal", new FixedDayResolver(5, 5));
                }
                return eorininal;
            }
        }

        private static NamedDay seokgatansinil;

        public static NamedDay SeokgaTansinil
        {
            get
            {
                if (seokgatansinil == null)
                {
                    seokgatansinil = new NamedDay("SeokgaTansinil", new FixedDayResolver(4, 8, KoreanLunisolarCalendar));
                }
                return seokgatansinil;
            }
        }

        private static NamedDay hyeonchungil;

        public static NamedDay Hyeonchungil
        {
            get
            {
                if (hyeonchungil == null)
                {
                    hyeonchungil = new NamedDay("Hyeonchungil", new FixedDayResolver(6, 6));
                }
                return hyeonchungil;
            }
        }

        private static NamedDay gwangbokjeol;

        public static NamedDay Gwangbokjeol
        {
            get
            {
                if (gwangbokjeol == null)
                {
                    gwangbokjeol = new NamedDay("Gwangbokjeol", new FixedDayResolver(8, 15));
                }
                return gwangbokjeol;
            }
        }

        private static NamedDay chuseok;

        public static NamedDay Chuseok
        {
            get
            {
                if (chuseok == null)
                {
                    chuseok = new NamedDay("Chuseok", new FixedDayResolver(8, 15, KoreanLunisolarCalendar));
                }
                return chuseok;
            }
        }

        private static NamedDay gaecheonjeol;

        public static NamedDay Gaecheonjeol
        {
            get
            {
                if (gaecheonjeol == null)
                {
                    gaecheonjeol = new NamedDay("Gaecheonjeol", new FixedDayResolver(10, 3));
                }
                return gaecheonjeol;
            }
        }

        private static NamedDay hangulnal;

        public static NamedDay Hangulnal
        {
            get
            {
                if (hangulnal == null)
                {
                    hangulnal = new NamedDay("Hangulnal", new FixedDayResolver(10, 9));
                }
                return hangulnal;
            }
        }
    }
}
