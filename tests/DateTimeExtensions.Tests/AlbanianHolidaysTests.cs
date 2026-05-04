using System;
using System.Linq;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class AlbanianHolidayTests
    {
        private WorkingDayCultureInfo albanianCulture;

        [SetUp]
        public void Setup()
        {
            albanianCulture = new WorkingDayCultureInfo("sq-AL");
        }

        [Test]
        public void FixedDateHolidays_AreCorrect()
        {
            Assert.IsTrue(albanianCulture.IsHoliday(new DateTime(2025, 1, 1)));

            Assert.IsTrue(albanianCulture.IsHoliday(new DateTime(2025, 1, 2)));

            Assert.IsTrue(albanianCulture.IsHoliday(new DateTime(2025, 3, 14)));

            Assert.IsTrue(albanianCulture.IsHoliday(new DateTime(2025, 3, 22)));
        }

        [Test]
        public void Easter_IsRecognized()
        {
            Assert.IsTrue(albanianCulture.IsHoliday(new DateTime(2025, 4, 20)));

            Assert.IsTrue(albanianCulture.IsHoliday(new DateTime(2025, 4, 20)));
        }

        [Test]
        public void HolidayCount_2025_IsCorrect()
        {
            var holidays2025 = albanianCulture.GetObservancesOfYear(2025).ToList();
            Assert.AreEqual(12, holidays2025.Count); // easters were both on the same day in 2025 resulting in 12 unique holidays
        }

        [Test]
        public void Strategy_Holidays_AreCorrect()
        {

            // Independence Day (November 28)
            var independenceDate = SQ_ALHolidayStrategy.IndependenceDay.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 11, 28), independenceDate);

            // Mother Teresa Day (September 5)
            var teresaDate = SQ_ALHolidayStrategy.MotherTheresaDay.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 9, 5), teresaDate);
        }

        [Test]
        public void WeekendHolidays_AreStillObserved()
        {
            Assert.IsTrue(albanianCulture.IsHoliday(new DateTime(2023, 1, 1)));
        }
    }
}