// using DateTimeExtensions.Common;
//
// namespace DateTimeExtensions.WorkingDays.CultureStrategies
// {
//     [Locale("en-GD")]
//     [Locale("gd-GD")]
//     public class ScotlandHolidayStrategy : HolidayStrategyBase
//     {
//         public ScotlandHolidayStrategy()
//         {
//             this.InnerCalendarDays.Add(GlobalHolidays.NewYear);
//             this.InnerCalendarDays.Add(NewYearHoliday);
//             this.InnerCalendarDays.Add(ChristianHolidays.GoodFriday);
//             this.InnerCalendarDays.Add(EN_GBHolidayStrategy.MayDayBank);
//             this.InnerCalendarDays.Add(EN_GBHolidayStrategy.SpringBank);
//             this.InnerCalendarDays.Add(EN_GBHolidayStrategy.LateSummerBank);
//             this.InnerCalendarDays.Add(StAndrewsDay);
//             this.InnerCalendarDays.Add(ChristianHolidays.Christmas);
//             this.InnerCalendarDays.Add(EN_GBHolidayStrategy.BoxingDay);
//         }
//
//         // 2nd January - New Year Holiday
//         private static Holiday newYearHoliday;
//
//         public static Holiday NewYearHoliday
//         {
//             get { return newYearHoliday ?? (newYearHoliday = new FixedHoliday("New Year Holiday", 1, 2)); }
//         }
//
//         // 30 November - St. Andrew's Day
//         private static Holiday stAndrewsDay;
//
//         public static Holiday StAndrewsDay
//         {
//             get { return stAndrewsDay ?? (stAndrewsDay = new FixedHoliday("St. Andrew's Day", 11, 30)); }
//         }
//     }
// }