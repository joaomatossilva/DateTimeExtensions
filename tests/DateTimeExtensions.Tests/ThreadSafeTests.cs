using DateTimeExtensions.WorkingDays;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class ThreadSafeTests
    {
        [Test]
        public void AddWorkingDays_MultipleThreads_CanCalculate()
        {
            //Arrange
            var culture = new WorkingDayCultureInfo("en-US");
            var startDate = new DateTime(2018,5,1);

            //Act
            Parallel.ForEach(Enumerable.Range(1,10), (i) => startDate.AddWorkingDays(i, culture));
        }

        [Test]
        public void CheckEaster_MultipleThreads()
        {
            Parallel.ForEach(Enumerable.Range(1, 10), (i) => ascencion_is_39_days_after_easter());
        }

        private void ascencion_is_39_days_after_easter()
        {
            var year = 2025;
            var easterDate = new DateTime(2025, 4, 20);

            var ascencionHoliday = ChristianHolidays.Ascension;
            var ascencion = ascencionHoliday.GetInstance(year);
            Assert.IsTrue(ascencion.HasValue);
            Assert.AreEqual(DayOfWeek.Thursday, ascencion.Value.DayOfWeek);

            //source: http://en.wikipedia.org/wiki/Ascension_Day
            // Ascension Day is traditionally celebrated on a Thursday, the fortieth day of Easter
            // again, easter day is included
            Assert.AreEqual(easterDate.AddDays(39), ascencion.Value);
        }
    }
}
