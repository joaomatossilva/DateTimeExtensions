using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DateTimeExtensions.Export;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]

    public class RomanianHolidaysTests
    {
        private WorkingDayCultureInfo dateTimeCulture = new WorkingDayCultureInfo("ro-RO");


        [Test]
        public void Romanian_has_12_main_holidays()
        {
            var holidays = dateTimeCulture.Holidays;
            Assert.AreEqual(16, holidays.Count());
        }

        [Test]
        public void Easter2017_is_16_april()
        {
            Assert.That(new DateTime(2017, 4, 16).IsHoliday(dateTimeCulture));
        }

        [Test]
        public void Easter2018_is_1_april()
        {
            Assert.That(new DateTime(2018, 4, 8).IsHoliday(dateTimeCulture));
        }

        [Test]
        public void Test2()
        {
            var holidaysStrategy = dateTimeCulture.LocateHolidayStrategy(dateTimeCulture.Name, null);

            Assert.AreEqual(typeof(RomanianHolidayStrategy), holidaysStrategy.GetType());
            var workingDaysStrategy = dateTimeCulture.LocateWorkingDayOfWeekStrategy(dateTimeCulture.Name, null);
            Assert.AreEqual(typeof(DefaultWorkingDayOfWeekStrategy), workingDaysStrategy.GetType());
        }

        [Test]
        public void can_identify_ChildrensDay()
        {
            var holiday = RomanianHolidayStrategy.ChildrensDay;
            var day = new DateTime(2022, 6, 1);
            TestHoliday(holiday, day);
        }
        
        [Test]
        public void test_export()
        {
            var orthodoxEaster = ChristianOrthodoxHolidays.Easter;
            var easter_1800 = orthodoxEaster.GetInstance(1800);
            var easter_2017 = orthodoxEaster.GetInstance(2017);
            var easter_2018 = orthodoxEaster.GetInstance(2018);
            var easter_2022 = orthodoxEaster.GetInstance(2022);
            var easter_2023 = orthodoxEaster.GetInstance(2023);
            var easter_2024 = orthodoxEaster.GetInstance(2024);
            var easter_2025 = orthodoxEaster.GetInstance(2025);

            TextWriter textwriter = new StringWriter();
            var exporter = ExportHolidayFormatLocator.LocateByType(ExportType.OfficeHolidays);
            exporter.Export(dateTimeCulture, 2024, textwriter);
            var s = textwriter.ToString();
            Assert.NotNull(s);
        }

        [Test]
        public void can_calculate_orthodox_easter()
        {
            var years = new int[] { 1800, 1899, 1900, 1999, 2000, 2025, 2035, 2067, 2099 };
            var easterDates = new Dictionary<int, DateTime>
            {
                {1800, new DateTime(1800, 4, 21)},
                {1899, new DateTime(1899, 5, 1)},
                {1900, new DateTime(1900, 4, 22)},
                {1999, new DateTime(1999, 4, 11)},
                {2000, new DateTime(2000, 4, 30)},
                {2025, new DateTime(2025, 4, 20)},
                {2035, new DateTime(2035, 4, 29)},
                {2067, new DateTime(2067, 4, 10)},
                {2099, new DateTime(2099, 4, 12)}
            };

            foreach (int year in years)
            {
                var easterHoliday = ChristianOrthodoxHolidays.Easter;
                var easter = easterHoliday.GetInstance(year);
                Assert.IsTrue(easter.HasValue);
                Assert.AreEqual(easterDates[year], easter.Value);
            }
        }

        private void TestHoliday(Holiday holiday, DateTime dateOnGregorian)
        {
            var holidayInstance = holiday.GetInstance(dateOnGregorian.Year);
            Assert.True(holidayInstance.HasValue);
            Assert.AreEqual(dateOnGregorian, holidayInstance.Value);
            Assert.True(holiday.IsInstanceOf(dateOnGregorian));
        }
    }
}