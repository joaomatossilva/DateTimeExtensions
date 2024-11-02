using System;
using System.IO;
using System.Linq;

using DateTimeExtensions.Export;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;

using NUnit.Framework;

#pragma warning disable NUnit2005

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class UAHolidaysTests
    {
        private WorkingDayCultureInfo dateTimeCulture = new WorkingDayCultureInfo("uk-UA");

        [Test]
        public void UA_has_11_main_holidays()
        {
            Assert.AreEqual(11, dateTimeCulture.Holidays.Count());
        }

        [Test]
        public void Easter2017_is_16_april()
        {
            Assert.That(new DateTime(2017, 4, 16).IsHoliday(dateTimeCulture));
        }

        [Test]
        public void Easter2018_is_1_april()
        {
            Assert.That(new DateTime(2018, 4, 1).IsHoliday(dateTimeCulture));
        }

        [Test]
        public void Test2()
        {
            var holidaysStrategy = dateTimeCulture.LocateHolidayStrategy(dateTimeCulture.Name, null);

            Assert.AreEqual(typeof(UK_UAHolidayStrategy), holidaysStrategy.GetType());
            var workingDaysStrategy = dateTimeCulture.LocateWorkingDayOfWeekStrategy(dateTimeCulture.Name, null);
            Assert.AreEqual(typeof(DefaultWorkingDayOfWeekStrategy), workingDaysStrategy.GetType());
        }

        [Test]
        public void can_identify_VictoryInEuropeDay()
        {
            var holiday = UK_UAHolidayStrategy.VictoryInEuropeDay;
            var day = new DateTime(2024, 5, 8);
            TestHoliday(holiday, day);
        }

        [Test]
        public void test_export()
        {
            var easter = ChristianHolidays.Easter;
            var easter_1800 = easter.GetInstance(1800);
            var easter_2017 = easter.GetInstance(2017);
            var easter_2018 = easter.GetInstance(2018);
            var easter_2022 = easter.GetInstance(2022);
            var easter_2023 = easter.GetInstance(2023);
            var easter_2024 = easter.GetInstance(2024);
            var easter_2025 = easter.GetInstance(2025);

            TextWriter textwriter = new StringWriter();
            var exporter = ExportHolidayFormatLocator.LocateByType(ExportType.OfficeHolidays);
            exporter.Export(dateTimeCulture, 2024, textwriter);
            var s = textwriter.ToString();
            Assert.NotNull(s);
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