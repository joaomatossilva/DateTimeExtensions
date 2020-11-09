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
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using DateTimeExtensions.Common;
//
// namespace DateTimeExtensions.WorkingDays.CultureStrategies
// {
//     [Locale("it-IT")]
//     public class IT_ITHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
//     {
//         public IT_ITHolidayStrategy()
//         {
//             this.InnerCalendarDays.Add(GlobalHolidays.NewYear);
//             this.InnerCalendarDays.Add(ChristianHolidays.Epiphany);
//             this.InnerCalendarDays.Add(ChristianHolidays.EasterMonday);
//             this.InnerCalendarDays.Add(GlobalHolidays.InternationalWorkersDay);
//             this.InnerCalendarDays.Add(RepublicDay);
//             this.InnerCalendarDays.Add(ChristianHolidays.Assumption);
//             this.InnerCalendarDays.Add(ChristianHolidays.AllSaints);
//             this.InnerCalendarDays.Add(ChristianHolidays.ImaculateConception);
//             this.InnerCalendarDays.Add(ChristianHolidays.Christmas);
//             this.InnerCalendarDays.Add(ChristianHolidays.StStephansDay);
//         }
//
//         //2 June - Republic Day
//         private static Holiday republicDay;
//
//         public static Holiday RepublicDay
//         {
//             get
//             {
//                 if (republicDay == null)
//                 {
//                     republicDay = new FixedHoliday("Republic Day", 6, 2);
//                 }
//                 return republicDay;
//             }
//         }
//     }
// }