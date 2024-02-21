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
    public class IndianHolidaysTests
    {
        [Test]
        public void DiwaliTests()
        {
            var diwaliHoliday = IndianHolidayStrategy.Diwali;

            var observanceIn2022 = diwaliHoliday.GetInstance(2022);
            Assert.AreEqual(new DateTime(2022, 10, 24), observanceIn2022);
        
            var observanceIn2023 = diwaliHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 10, 24), observanceIn2023);

            var observanceIn2024 = diwaliHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 11, 1), observanceIn2024);

            var observanceIn2025 = diwaliHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 10, 21), observanceIn2025);

        }

        [Test]
        public void HoliTests()
        {
            var holiHoliday = IndianHolidayStrategy.Holi;
          
            var observanceIn2021 = holiHoliday.GetInstance(2021);
            Assert.AreEqual(new DateTime(2021, 3, 18), observanceIn2021);
          
            var observanceIn2022 = holiHoliday.GetInstance(2022);
            Assert.AreEqual(new DateTime(2023, 3, 18), observanceIn2022);

            var observanceIn2023 = holiHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2024, 3, 8), observanceIn2023);

            var observanceIn2024 = holiHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2025, 3, 25), observanceIn2024);
        }

        [Test]
        public void JanmashtamiTests()
        {
            var janmashtamiHoliday = IndianHolidayStrategy.Janmashtami;

            var observanceIn2022 = janmashtamiHoliday.GetInstance(2022);
            Assert.AreEqual(new DateTime(2022, 8, 19), observanceIn2022);
          
            var observanceIn2023 = janmashtamiHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 9, 7), observanceIn2023);

            var observanceIn2024 = janmashtamiHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 8, 26), observanceIn2024);

            var observanceIn2025 = janmashtamiHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 8, 16), observanceIn2025);

        }

        [Test]
        public void CanGetIndianHolidaysListIn2024()
        {
            var cultureInfo = new WorkingDayCultureInfo("en-IN");
            Assert.IsNotNull(cultureInfo);
            var holidays = cultureInfo.GetHolidaysOfYear(2024);
            Assert.AreEqual(6, holidays.Count()); // Excluding New Year
          
        }
    }
}
