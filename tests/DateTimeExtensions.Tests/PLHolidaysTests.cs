using System;
using NUnit.Framework;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class PLHolidaysTests
    {
        private WorkingDayCultureInfo dateTimeCulture = new WorkingDayCultureInfo("pl-PL");

        [Test]
        [TestCase(2024, false)]
        [TestCase(2025, true)]
        [TestCase(2026, true)]
        public void ChristmasEve_Is_Holiday_From_2025(int year, bool shouldBeHoliday)
        {
            var date = new DateTime(year, 12, 24);
            Assert.That(dateTimeCulture.IsHoliday(date), Is.EqualTo(shouldBeHoliday), $"Christmas Eve {year} should be a holiday: {shouldBeHoliday}");
        }

        [Test]
        public void AddWorkingDays_Skips_ChristmasEve_From_2025()
        {
            // 23.12.2025 (Tuesday) + 1 working day = 29.12.2025 (Monday); 24-26.12 are holidays
            var start = new DateTime(2025, 12, 23);
            var result = start.AddWorkingDays(1, dateTimeCulture);
            Assert.That(result, Is.EqualTo(new DateTime(2025, 12, 29)));
        }

        [Test]
        public void AddWorkingDays_DoesNotSkip_ChristmasEve_Before_2025()
        {
            // 23.12.2024 (Monday) + 1 working day = 24.12.2024 (Tuesday); Christmas Eve is not a holiday
            var start = new DateTime(2024, 12, 23);
            var result = start.AddWorkingDays(1, dateTimeCulture);
            Assert.That(result, Is.EqualTo(new DateTime(2024, 12, 24)));
        }
    }
}
