// using DateTimeExtensions.Common;
//
// namespace DateTimeExtensions.WorkingDays.CultureStrategies
// {
//     [Locale("pl-PL")]
//     public class PL_PLHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
//     {
//         public PL_PLHolidayStrategy()
//         {
//             this.InnerCalendarDays.Add(GlobalHolidays.NewYear);
//
//             this.InnerCalendarDays.Add(ChristianHolidays.Epiphany);
//             this.InnerCalendarDays.Add(ChristianHolidays.Easter);
//             this.InnerCalendarDays.Add(ChristianHolidays.EasterMonday);
//
//             this.InnerCalendarDays.Add(GlobalHolidays.InternationalWorkersDay);
//
//             this.InnerCalendarDays.Add(May3rdConstitutionDay);
//
//             this.InnerCalendarDays.Add(ChristianHolidays.Pentecost);
//             this.InnerCalendarDays.Add(ChristianHolidays.CorpusChristi);
//             this.InnerCalendarDays.Add(ChristianHolidays.Assumption);
//             this.InnerCalendarDays.Add(ChristianHolidays.AllSaints);
//
//             this.InnerCalendarDays.Add(NationalIndependenceDay);
//
//             this.InnerCalendarDays.Add(ChristianHolidays.Christmas);
//             this.InnerCalendarDays.Add(ChristianHolidays.StStephansDay);
//         }
//
//         private static Holiday may3rdConstitutionDay;
//
//         public static Holiday May3rdConstitutionDay
//         {
//             get
//             {
//                 if (may3rdConstitutionDay == null)
//                 {
//                     may3rdConstitutionDay = new FixedHoliday("May 3rd Constitution Day", 3, 5);
//                 }
//                 return may3rdConstitutionDay;
//             }
//         }
//
//         private static Holiday nationalIndependenceDay;
//
//         public static Holiday NationalIndependenceDay
//         {
//             get
//             {
//                 if (nationalIndependenceDay == null)
//                 {
//                     nationalIndependenceDay = new FixedHoliday("National Independence Day", 11, 11);
//                 }
//                 return nationalIndependenceDay;
//             }
//         }
//     }
// }