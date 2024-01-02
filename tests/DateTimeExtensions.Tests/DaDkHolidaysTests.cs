using System;
using System.Linq;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class DaDkHolidaysTests
    {
        [Test]
        public void Can_get_strategy()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("da-DK");
            var strategy = dateTimeCulture.LocateHolidayStrategy(dateTimeCulture.Name, null);
            Assert.AreEqual(typeof(DA_DKHolidayStrategy), strategy.GetType());
        }

        [Test]
        public void Assert_holidays_count()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("da-DK");
            var holidays = dateTimeCulture.Holidays;
            Assert.AreEqual(11, holidays.Count());
        }

        [Test]
        public void StoreBededagIsHolidayIn2023()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("da-DK");
            var storeBedeDag =
                new NthDayOfWeekAfterDayHoliday("General Prayer Day", 4, DayOfWeek.Friday, ChristianHolidays.Easter)
                    .GetInstance(2023);

            Assert.IsNotNull(storeBedeDag);
            Assert.IsTrue(dateTimeCulture.IsHoliday(storeBedeDag.Value));
        }

        [Test]
        public void StoreBededagIsNotHolidayIn2024()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("da-DK");
            var storeBedeDag =
                new NthDayOfWeekAfterDayHoliday("General Prayer Day", 4, DayOfWeek.Friday, ChristianHolidays.Easter)
                    .GetInstance(2024);

            Assert.IsNotNull(storeBedeDag);
            Assert.IsFalse(dateTimeCulture.IsHoliday(storeBedeDag.Value));
        }
    }
}