using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions;
using NUnit.Framework;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using Moq;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class GenericWorkingDayCultureInfoTests
    {
        [Test]
        public void can_locate_default_strategies()
        {
            string name = "foo";
            WorkingDayCultureInfo workingdayCultureInfo = new WorkingDayCultureInfo(name);
            Assert.IsTrue(name == workingdayCultureInfo.Name);
            Assert.IsInstanceOf<DefaultHolidayStrategy>(workingdayCultureInfo.LocateHolidayStrategy(name, null));
            Assert.IsInstanceOf<DefaultWorkingDayOfWeekStrategy>(
                workingdayCultureInfo.LocateWorkingDayOfWeekStrategy(name, null));
        }

        [Test]
        public void can_provide_custom_locator_holiday_dayOfWeek_strategy()
        {
            var mockHolidayStrategy = new Mock<IHolidayStrategy>();
            mockHolidayStrategy.Setup(x => x.IsHoliDay(It.IsAny<DateTime>())).Returns(true);

            var mockDayOfWeekStartegy = new Mock<IWorkingDayOfWeekStrategy>();
            mockDayOfWeekStartegy.Setup(x => x.IsWorkingDay(It.IsAny<DayOfWeek>())).Returns(true);

            WorkingDayCultureInfo workingdayCultureInfo = new WorkingDayCultureInfo()
            {
                LocateHolidayStrategy = (n, r) => { return mockHolidayStrategy.Object; },
                LocateWorkingDayOfWeekStrategy = (n, r) => { return mockDayOfWeekStartegy.Object; }
            };

            DateTime marchFirst = new DateTime(1991, 3, 1);
            Assert.IsTrue(marchFirst.IsHoliday(workingdayCultureInfo));
            Assert.IsFalse(marchFirst.IsWorkingDay(workingdayCultureInfo));
            mockHolidayStrategy.Verify(x => x.IsHoliDay(marchFirst), Times.AtLeastOnce);
            mockDayOfWeekStartegy.Verify(x => x.IsWorkingDay(marchFirst.DayOfWeek), Times.AtLeastOnce);
        }

        [Test]
        public void can_provide_custom_locator_dayOfWeek_strategy()
        {
            var mockDayOfWeekStartegy = new Mock<IWorkingDayOfWeekStrategy>();
            mockDayOfWeekStartegy.Setup(x => x.IsWorkingDay(It.IsAny<DayOfWeek>())).Returns(false);

            WorkingDayCultureInfo workingdayCultureInfo = new WorkingDayCultureInfo()
            {
                LocateWorkingDayOfWeekStrategy = (n, r) => { return mockDayOfWeekStartegy.Object; }
            };

            DateTime aThursday = new DateTime(2011, 5, 12);
            Assert.IsFalse(aThursday.IsWorkingDay(workingdayCultureInfo));
            Assert.IsFalse(aThursday.IsHoliday(workingdayCultureInfo));
            mockDayOfWeekStartegy.Verify(x => x.IsWorkingDay(aThursday.DayOfWeek), Times.AtLeastOnce);
        }

        [Test]
        public void picks_a_holiday_when_two_holidays_occur_on_the_same_date()
        {
            /* In 2005, Ascension day was on the fifth of May. That year, the fifth of may was
             * also a national public holiday (liberation day).	The holiday picker should not
             * fail, but it is arbritrary which one of the holidays it should return, so either
             * one is OK. HolidayStrategyBase.BuildObservancesMap should survive this.
             */

            var inTheNetherlands = new WorkingDayCultureInfo("nl-NL");
            var fifthOfMay = new DateTime(2005, 5, 5);

            Assert.That(fifthOfMay.IsHoliday(inTheNetherlands));
        }
    }
}