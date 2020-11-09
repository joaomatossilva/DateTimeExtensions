using System.Linq;

namespace DateTimeExtensions.Tests.Extensibility
{
    using System;
    using Common;
    using NUnit.Framework;
    using WorkingDays;
    using WorkingDays.CultureStrategies;

    public class CustomCultureInfoTests
    {

        public class MyCustomCultureInfo : WorkingDayCultureInfo
        {
            public MyCustomCultureInfo()
            {
                //just return our custom Strategy
                LocateHolidayStrategy = (name, region) =>
                    new MyCustomWorkingDayStrategy();
            }
        }

        [Locale("MyCustom")]
        public class MyCustomWorkingDayStrategy : EN_USHolidayStrategy
        {
            public MyCustomWorkingDayStrategy()
            {
                var columbusHoliday = this.InnerCalendarDays.First(x => x.Day == ColumbusDay);
                this.InnerCalendarDays.Remove(columbusHoliday);
            }
        }

        [Test]
        public void ColumbusDayNotAnHoliday()
        {
            var date = new DateTime(2020, 10, 12); //second monday on October
            var workingDayCultureInfo = new MyCustomCultureInfo();
            var defaultWorkingDayCultureInfo = new WorkingDayCultureInfo("en-US");

            Assert.IsFalse(date.IsHoliday(workingDayCultureInfo));
            Assert.IsTrue(date.IsHoliday(defaultWorkingDayCultureInfo));
        }
    }
}