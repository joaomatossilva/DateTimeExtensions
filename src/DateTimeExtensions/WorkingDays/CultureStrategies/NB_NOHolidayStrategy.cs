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
//     [Locale("nb-NO")]
//     public class NB_NOHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
//     {
//         public NB_NOHolidayStrategy()
//         {
//             this.InnerCalendarDays.Add(GlobalHolidays.NewYear);
//             this.InnerCalendarDays.Add(ChristianHolidays.MaundyThursday);
//             this.InnerCalendarDays.Add(ChristianHolidays.GoodFriday);
//             this.InnerCalendarDays.Add(ChristianHolidays.Easter);
//             this.InnerCalendarDays.Add(ChristianHolidays.EasterMonday);
//             this.InnerCalendarDays.Add(GlobalHolidays.InternationalWorkersDay);
//             this.InnerCalendarDays.Add(ConstitutionDay);
//             this.InnerCalendarDays.Add(ChristianHolidays.Ascension);
//             this.InnerCalendarDays.Add(ChristianHolidays.Pentecost);
//             this.InnerCalendarDays.Add(ChristianHolidays.PentecostMonday);
//             this.InnerCalendarDays.Add(ChristianHolidays.Christmas);
//             this.InnerCalendarDays.Add(ChristianHolidays.StStephansDay);
//         }
//
//         private static Holiday constituionDay;
//
//         public static Holiday ConstitutionDay
//         {
//             get
//             {
//                 if (constituionDay == null)
//                 {
//                     constituionDay = new FixedHoliday("Constitution Day", 5, 17);
//                 }
//                 return constituionDay;
//             }
//         }
//     }
// }