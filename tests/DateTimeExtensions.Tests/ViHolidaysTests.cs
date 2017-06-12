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
    public class ViHolidaysTests
    {
        private WorkingDayCultureInfo dateTimeCulture;

        #region test cases
        private static readonly List<DateTime> HungKingsCases = new List<DateTime>()
            {
                new DateTime(2015,3,10),
                new DateTime(2112,3,10),
                new DateTime(2014,3,10),
                new DateTime(2022,3,10),
                new DateTime(2017,3,10),
            };

        private static readonly List<DateTime> LiberationCases = new List<DateTime>()
            {
                new DateTime(2015,4,30),
                new DateTime(2112,4,30),
                new DateTime(2014,4,30),
                new DateTime(2022,4,30),
                new DateTime(2017,4,30),
            };
        private static readonly List<DateTime> InternationalWorkersCases = new List<DateTime>()
            {
                new DateTime(2015,5,1),
                new DateTime(2112,5,1),
                new DateTime(2014,5,1),
                new DateTime(2022,5,1),
                new DateTime(2017,5,1),
            };
        private static readonly List<DateTime> NationalCases = new List<DateTime>()
            {
                new DateTime(2015,9,2),
                new DateTime(2112,9,2),
                new DateTime(2014,9,2),
                new DateTime(2022,9,2),
                new DateTime(2017,9,2),
            };

        private static readonly List<DateTime> NewYearCases = new List<DateTime>()
            {
                new DateTime(2015,1,1),
                new DateTime(2112,1,1),
                new DateTime(2014,1,1),
                new DateTime(2022,1,1),
                new DateTime(2017,1,1),
            };
        #endregion

        [SetUp]
        public void Init()
        {
            dateTimeCulture = new WorkingDayCultureInfo("vi-VN");
        }

        [Test]
        public void ShouldGetViVnStrategy()
        {
            var strategy = dateTimeCulture.LocateHolidayStrategy(dateTimeCulture.Name, null);
            Assert.AreEqual(typeof(ViVNHolidayStrategy), strategy.GetType());
        }

        [Test, TestCaseSource(nameof(HungKingsCases))]
        public void ShouldBeHungKingsCommemorationsDay(DateTime holiday)
        {
            Assert.IsTrue(dateTimeCulture.IsHoliday(holiday));
        }

        [Test, TestCaseSource(nameof(LiberationCases))]
        public void ShouldBeLiberationDay(DateTime holiday)
        {
            Assert.IsTrue(dateTimeCulture.IsHoliday(holiday));
        }

        [Test, TestCaseSource(nameof(InternationalWorkersCases))]
        public void ShouldBeInternationalWorkersDay(DateTime holiday)
        {
            Assert.IsTrue(dateTimeCulture.IsHoliday(holiday));
        }

        [Test, TestCaseSource(nameof(NationalCases))]
        public void ShouldBeNationalDay(DateTime holiday)
        {
            Assert.IsTrue(dateTimeCulture.IsHoliday(holiday));
        }

        [Test, TestCaseSource(nameof(NewYearCases))]
        public void ShouldBeNewYearDay(DateTime holiday)
        {
            Assert.IsTrue(dateTimeCulture.IsHoliday(holiday));
        }

        [Test]
        public void VietNamPublicHolidaysShouldBe5()
        {
            var holidays = dateTimeCulture.Holidays;
            Assert.IsTrue(5 == holidays.Count());
        }

    }
}