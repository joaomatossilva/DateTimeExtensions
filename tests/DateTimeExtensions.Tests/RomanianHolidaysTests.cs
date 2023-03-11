using System;
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
            Assert.AreEqual(12, holidays.Count());
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

        private void TestHoliday(Holiday holiday, DateTime dateOnGregorian)
        {
            var holidayInstance = holiday.GetInstance(dateOnGregorian.Year);
            Assert.True(holidayInstance.HasValue);
            Assert.AreEqual(dateOnGregorian, holidayInstance.Value);
            Assert.True(holiday.IsInstanceOf(dateOnGregorian));
        }
    }
}