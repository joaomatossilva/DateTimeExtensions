using System;
using DateTimeExtensions;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = DateTime.Now.IsWorkingDay(new WorkingDayCultureInfo("tr-TR"));
            var n1=new DateTime(2022,5,19).IsHoliday(new WorkingDayCultureInfo("tr-TR"));

            var tatil=new TurkishHolidayStrategy().Holidays;

            foreach (var holiday in tatil)
            {
                var k = holiday;
                var kk = holiday.GetInstance(2030);
                var d = kk.Value.DayOfWeek;
                var endOfSubat = DateTime.Now;
            }
            Console.WriteLine("Hello World!");
        }
    }
}
