using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class ChineseHolidaysTests
    {
        [Test]
        public void SpringFetivalTests()
        {
            var springFestivalHoliday = ChineseHolidayStrategy.SpringFestival;

            var observanceIn2015 = springFestivalHoliday.GetInstance(2015);
            Assert.AreEqual(new DateTime(2015, 2, 19), observanceIn2015);

            var observanceIn2016 = springFestivalHoliday.GetInstance(2016);
            Assert.AreEqual(new DateTime(2016, 2, 8), observanceIn2016);

            var observanceIn2017 = springFestivalHoliday.GetInstance(2017);
            Assert.AreEqual(new DateTime(2017, 1, 28), observanceIn2017);
        }

        [Test]
        public void TombSweepingDayTests()
        {
            var tombSweepingDayHoliday = ChineseHolidayStrategy.TombSweepingDay;

            var observanceIn2015 = tombSweepingDayHoliday.GetInstance(2015);
            Assert.AreEqual(new DateTime(2015, 4, 5), observanceIn2015);

            var observanceIn2016 = tombSweepingDayHoliday.GetInstance(2016);
            Assert.AreEqual(new DateTime(2016, 4, 2), observanceIn2016);

            var observanceIn2017 = tombSweepingDayHoliday.GetInstance(2017);
            Assert.AreEqual(new DateTime(2017, 4, 5), observanceIn2017);
        }

        public void CanGetChineseHolidaysListIn2016()
        {
            var cultureInfo = new WorkingDayCultureInfo("zh-CN");
            Assert.IsNotNull(cultureInfo);
            var holidays = cultureInfo.GetHolidaysOfYear(2016);
            Assert.AreEqual(7, holidays.Count());
        }
    }
}
