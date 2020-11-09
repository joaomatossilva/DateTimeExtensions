// #region License
//
// // 
// // Copyright (c) 2011-2012, João Matos Silva <kappy@acydburne.com.pt>
// // 
// // Licensed under the Apache License, Version 2.0 (the "License");
// // you may not use this file except in compliance with the License.
// // You may obtain a copy of the License at
// //
// //   http://www.apache.org/licenses/LICENSE-2.0
// //
// // Unless required by applicable law or agreed to in writing, software
// // distributed under the License is distributed on an "AS IS" BASIS,
// // WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// // See the License for the specific language governing permissions and
// // limitations under the License.
// // 
//
// #endregion
//
// using System;
// using DateTimeExtensions.Common;
//
// namespace DateTimeExtensions.WorkingDays.CultureStrategies
// {
//     [Locale("nl-NL")]
//     public class NL_NLHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
//     {
//         public NL_NLHolidayStrategy()
//         {
//             this.InnerCalendarDays.Add(GlobalHolidays.NewYear);
//             this.InnerCalendarDays.Add(ChristianHolidays.GoodFriday);
//             this.InnerCalendarDays.Add(ChristianHolidays.Easter);
//             this.InnerCalendarDays.Add(ChristianHolidays.EasterMonday);
//             this.InnerCalendarDays.Add(Kingsday);
//             this.InnerCalendarDays.Add(LiberationDay);
//             this.InnerCalendarDays.Add(ChristianHolidays.Ascension);
//             this.InnerCalendarDays.Add(ChristianHolidays.Pentecost);
//             this.InnerCalendarDays.Add(ChristianHolidays.PentecostMonday);
//             this.InnerCalendarDays.Add(ChristianHolidays.Christmas);
//             this.InnerCalendarDays.Add(GlobalHolidays.BoxingDay);
//         }
//
//         // 1885-1948: 31 August
//         // 1949-2013: 30 April
//         // 2014-    : 27 April
//         private static Holiday kingsday;
//
//         public static Holiday Kingsday
//         {
//             get
//             {
//                 if (kingsday == null)
//                 {
//                     kingsday = new FixedHoliday("Kingsday", year =>
//                     {
//                         if (year >= 2014)
//                         {
//                             return new DateTime(year, 4, 27);
//                         }
//
//                         if (year >= 1949)
//                         {
//                             return new DateTime(year, 4, 30);
//                         }
//
//                         if (year >= 1885)
//                         {
//                             return new DateTime(year, 8, 31);
//                         }
//
//                         return null;
//                     });
//                 }
//                 return kingsday;
//             }
//         }
//
//         //after 2000, Liberation Day only ocours 5 in 5 years
//         private static Holiday liberationDay;
//
//         public static Holiday LiberationDay
//         {
//             get
//             {
//                 if (liberationDay == null)
//                 {
//                     liberationDay = new YearDependantHoliday(year => (year <= 2000 || year%5 == 0),
//                         new FixedHoliday("Liberation Day", 5, 5));
//                 }
//                 return liberationDay;
//             }
//         }
//     }
// }