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

namespace DateTimeExtensions.WorkingDays.OccurrencesCalculators
{
    public class EasterDayStrategy : ICalculateDayStrategy
    {
        private readonly ConcurrentLazyDictionary<int, DateTime> dayCache;

        private EasterDayStrategy()
        {
            dayCache = new ConcurrentLazyDictionary<int, DateTime>();
        }
        
        private static readonly Lazy<ICalculateDayStrategy> InstanceLazy = new Lazy<ICalculateDayStrategy>(() => 
            new EasterDayStrategy());

        public static ICalculateDayStrategy Instance => InstanceLazy.Value;

        public DateTime? GetInstance(int year)
        {
            return dayCache.GetOrAdd(year, () => EasterCalculator.CalculateEasterDate(year));
        }

        public bool IsInstanceOf(DateTime date)
        {
            var day = GetInstance(date.Year);
            return day.HasValue && date.Month == day.Value.Month && date.Day == day.Value.Day;
        }

        private static class EasterCalculator
        {
            private static ConcurrentLazyDictionary<int, DateTime> easterPerYear;

            static EasterCalculator()
            {
                easterPerYear = new ConcurrentLazyDictionary<int, DateTime>();
            }

            public static DateTime CalculateEasterDate(int year)
            {
                return easterPerYear.GetOrAdd(year, () => GetEasterDate(year));
            }

            //Algoritm downloaded from http://tiagoe.blogspot.com/2007/10/easter-calculation-in-c.html
            private static DateTime GetEasterDate(int year)
            {
                int a, b, c, d, e, f, g, h, i, k, l, m, p, q;

                if (year >= 1583)
                {
                    //Gregorian Calendar Easter 

                    DivRem(year, 19, out a);
                    b = DivRem(year, 100, out c);
                    d = DivRem(b, 4, out e);
                    f = DivRem(b + 8, 25);
                    g = DivRem(b - f + 1, 3);
                    DivRem(19*a + b - d - g + 15, 30, out h);
                    i = DivRem(c, 4, out k);
                    DivRem(32 + 2*e + 2*i - h - k, 7, out l);
                    m = DivRem(a + 11*h + 22*l, 451);
                    p = DivRem(h + l - 7*m + 114, 31, out q);

                    return new DateTime(year, p, q + 1);
                }
                else
                {
                    //Julian Calendar 

                    DivRem(year, 4, out a);
                    DivRem(year, 7, out b);
                    DivRem(year, 19, out c);
                    DivRem(19*c + 15, 30, out d);
                    DivRem(2*a + 4*b - d + 34, 7, out e);
                    f = DivRem(d + e + 114, 31, out g);

                    return new DateTime(year, f, g + 1);
                }
            }

            private static int DivRem(int a, int b, out int result)
            {
                result = a % b;
                return a / b;
            }
            
            private static int DivRem(int a, int b)
            {
                return a / b;
            }
        }
    }
}