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
//     [Locale("nl-BE")]
//     public class NL_BEHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
//     {
//         public NL_BEHolidayStrategy()
//         {
//             this.InnerCalendarDays.Add(GlobalHolidays.NewYear);
//             this.InnerCalendarDays.Add(ChristianHolidays.Easter);
//             this.InnerCalendarDays.Add(ChristianHolidays.EasterMonday);
//             this.InnerCalendarDays.Add(LabourDay);
//             this.InnerCalendarDays.Add(ChristianHolidays.Ascension);
//             this.InnerCalendarDays.Add(ChristianHolidays.Pentecost);
//             this.InnerCalendarDays.Add(ChristianHolidays.PentecostMonday);
//             this.InnerCalendarDays.Add(NationalHoliday);
//             this.InnerCalendarDays.Add(ChristianHolidays.Assumption);
//             this.InnerCalendarDays.Add(ChristianHolidays.AllSaints);
//             this.InnerCalendarDays.Add(Armistice);
//             this.InnerCalendarDays.Add(ChristianHolidays.Christmas);
//         }
//
//         private static Holiday labourDay;
//
//         public static Holiday LabourDay
//         {
//             get
//             {
//                 if (labourDay == null)
//                 {
//                     labourDay = new FixedHoliday("LabourDay", 5,1);
//                 }
//                 return labourDay;
//             }
//         }
//
//         private static Holiday nationalHoliday;
//
//         public static Holiday NationalHoliday
//         {
//             get
//             {
//                 if (nationalHoliday == null)
//                 {
//                     nationalHoliday = new FixedHoliday("Belgium_NationalHoliday", 7, 21);
//                 }
//                 return nationalHoliday;
//             }
//         }
//
//         private static Holiday armistice;
//
//         public static Holiday Armistice
//         {
//             get
//             {
//                 if (armistice == null)
//                 {
//                     armistice = new FixedHoliday("Armistice", 11, 11);
//                 }
//                 return armistice;
//             }
//         }
//     }
// }