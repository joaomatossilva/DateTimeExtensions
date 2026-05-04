using System;
using System.Linq;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class EN_GHHolidayStrategyTests
    {
        private readonly WorkingDayCultureInfo _culture = new("en-GH");

        [Test]
        public void StrategyResolution_Returns_EN_GHHolidayStrategy()
        {
            var strategy = _culture.LocateHolidayStrategy(_culture.Name, null);
            Assert.That(strategy, Is.TypeOf<EN_GHHolidayStrategy>());
        }

        [Test]
        public void Holidays_Collection_Count_Is_11()
        {
            var holidays = _culture.Observances;
            Assert.That(holidays.Count(), Is.EqualTo(11));
        }

        [Test]
        public void Christmas_On_Sunday_2022_And_BoxingDay_Collision_Behaviour()
        {
            var year = 2022;
            var christmas = new DateTime(year, 12, 25);
            var boxingDay = new DateTime(year, 12, 26);

            var holidaysMap = new DateTime(year, 1, 1).AllYearHolidays(_culture);

            Assert.Multiple(() =>
            {
                Assert.That(christmas.DayOfWeek, Is.EqualTo(DayOfWeek.Sunday));
                Assert.That(holidaysMap.ContainsKey(christmas), Is.True, "Christmas (original date) should be present.");
                Assert.That(holidaysMap.ContainsKey(boxingDay), Is.True, "Boxing Day / observed slot should be present.");
                Assert.That(holidaysMap[christmas].CalendarDay.Name, Is.EqualTo("Christmas"));
                Assert.That(holidaysMap[boxingDay].CalendarDay.Name, Is.EqualTo("Boxing Day"));
                Assert.That(christmas.IsWorkingDay(_culture), Is.False);
                Assert.That(boxingDay.IsWorkingDay(_culture), Is.False);
            });
        }

        [Test]
        public void Christmas_Sunday_2033_Is_Observed_On_Monday_2033()
        {
            var christmasSunday = new DateTime(2033, 12, 25);
            var observed = christmasSunday.AddDays(1);

            Assert.Multiple(() =>
            {
                Assert.That(christmasSunday.DayOfWeek, Is.EqualTo(DayOfWeek.Sunday));
                Assert.That(observed.IsHoliday(_culture), Is.True, "Following Monday should be observed as a holiday.");
                Assert.That(observed.IsWorkingDay(_culture), Is.False);
            });
        }

        public void Assert_LabourDayHoliday_On_Sunday_Observed_On_Monday()
        {
            // 02-05-2033 Labour day on a Sunday
            var mondayAfterLabourDay = new DateTime(2033, 05, 2);
            Assert.Multiple(() =>
            {
                Assert.That(mondayAfterLabourDay.DayOfWeek, Is.EqualTo(DayOfWeek.Monday));
                Assert.That(mondayAfterLabourDay.IsWorkingDay(_culture), Is.False);
            });
        }

        [TestCase("2024-04-05", 1, "2024-04-08")]
        [TestCase("2024-04-05", 0, "2024-04-05")]
        public void AddWorkingDays_Respects_Holidays_And_Weekends(string startIso, int addDays, string expectedIso)
        {
            var start = DateTime.Parse(startIso).AddHours(13); // ensure time part exists
            var expected = DateTime.Parse(expectedIso);
            var result = start.AddWorkingDays(addDays, _culture);
            Assert.That(result.Date, Is.EqualTo(expected.Date));
        }

        [Test]
        public void GetWorkingDays_Counts_Properly_For_Range()
        {
            var from = new DateTime(2024, 12, 23); // Mon
            var to = new DateTime(2024, 12, 27);   // Fri (exclusive)
            var count = from.GetWorkingDays(to, _culture);

            // 2024-12-25 Christmas and 2024-12-26 Boxing Day are holidays -> working days are 23 and 24
            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public void IsHoliday_Default_And_With_Culture()
        {
            var date = new DateTime(2024, 12, 25);
            Assert.That(date.IsHoliday(_culture), Is.True);
            // exercise idempotency / caching
            Assert.That(date.IsHoliday(_culture), Is.True);
        }

        [Test]
        public void AllYearHolidays_Returns_Mapping_With_Observed_Entries()
        {
            var year = 2022;
            var map = new DateTime(year, 1, 1).AllYearHolidays(_culture);

            Assert.Multiple(() =>
            {
                Assert.That(map.ContainsKey(new DateTime(year, 1, 1)), Is.True, "New Year should be present");
                Assert.That(map.ContainsKey(new DateTime(year, 12, 25)), Is.True, "Christmas original should be present");
                Assert.That(map.ContainsKey(new DateTime(year, 12, 26)), Is.True, "Observed Boxing Day slot should be present");
            });
        }
    }
}
