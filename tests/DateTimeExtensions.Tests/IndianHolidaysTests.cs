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
        // Test for Republic Day
        [Test]
        public void RepublicDayTest()
        {
            var republicDayHoliday = IndianHolidayStrategy.RepublicDay;

            var observanceIn2023 = republicDayHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 1, 26), observanceIn2023);

            var observanceIn2024 = republicDayHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 1, 26), observanceIn2024);

            var observanceIn2025 = republicDayHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 1, 26), observanceIn2025);
        }
        // Test for Independence Day
        [Test]
        public void IndependenceDayTest()
        {
            var independenceDayHoliday = IndianHolidayStrategy.IndependenceDay;

            var observanceIn2023 = independenceDayHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 8, 15), observanceIn2023);
            
            var observanceIn2024 = independenceDayHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 8, 15), observanceIn2024);

            var observanceIn2025 = independenceDayHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 8, 15), observanceIn2025);
        }
        // Test for Gandhi Jayanti
        [Test]
        public void GandhiJayantiTest()
        {
            var gandhiJayantiHoliday = IndianHolidayStrategy.GandhiJayanti;

            var observanceIn2023 = gandhiJayantiHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 10, 2), observanceIn2023);

            var observanceIn2024 = gandhiJayantiHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 10, 2), observanceIn2024);

            var observanceIn2025 = gandhiJayantiHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 10, 2), observanceIn2025);
        }
        // Test for Diwali
        [Test]
        public void DiwaliTest()
        {
            var diwaliHoliday = IndianHolidayStrategy.Diwali;

            var observanceIn2023 = diwaliHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 11, 13), observanceIn2023);

            var observanceIn2024 = diwaliHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 11, 1), observanceIn2024);

            var observanceIn2025 = diwaliHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 10, 21), observanceIn2025);
        }
        // Test for Dussehra
        [Test]
        public void DussehraTest()
        {
            var dussehraHoliday = IndianHolidayStrategy.Dussehra;

            var observanceIn2023 = dussehraHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 10, 24), observanceIn2023);

            var observanceIn2024 = dussehraHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 10, 12), observanceIn2024);

            var observanceIn2025 = dussehraHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 10, 2), observanceIn2025);
        }
        // Test for Guru Nanak Jayanti
        [Test]
        public void GuruNanakJayantiTest()
        {
            var guruNanakJayantiHoliday = IndianHolidayStrategy.GuruNanakJayanti;

            var observanceIn2023 = guruNanakJayantiHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 11, 27), observanceIn2023);

            var observanceIn2024 = guruNanakJayantiHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 11, 15), observanceIn2024);

            var observanceIn2025 = guruNanakJayantiHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 11, 5), observanceIn2025);
        }

        // Test for Buddha Purnima
        [Test]
        public void BuddhaPurnimaTest()
        {
            var buddhaPurnimaHoliday = IndianHolidayStrategy.BuddhaPurnima;

            var observanceIn2023 = buddhaPurnimaHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 5, 5), observanceIn2023);

            var observanceIn2024 = buddhaPurnimaHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 5, 23), observanceIn2024);

            var observanceIn2025 = buddhaPurnimaHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 5, 12), observanceIn2025);
        }

        // Test for Good Friday
        [Test]
        public void GoodFridayTest()
        {
            var goodFridayHoliday = IndianHolidayStrategy.GoodFriday;

            var observanceIn2023 = goodFridayHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 4, 7), observanceIn2023);

            var observanceIn2024 = goodFridayHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 3, 29), observanceIn2024);

            var observanceIn2025 = goodFridayHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 4, 18), observanceIn2025);
        }
        // Test for Christmas Day
        [Test]
        public void ChristmasDayTest()
        {
            var christmasDayHoliday = IndianHolidayStrategy.ChristmasDay;

            var observanceIn2023 = christmasDayHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 12, 25), observanceIn2023);

            var observanceIn2024 = christmasDayHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 12, 25), observanceIn2024);

            var observanceIn2025 = christmasDayHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 12, 25), observanceIn2025);
        }
        // Test for New Year's Day
        [Test]
        public void NewYearsDayTest()
        {
            var newYearsDayHoliday = IndianHolidayStrategy.NewYearsDay;

            var observanceIn2023 = newYearsDayHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 1, 1), observanceIn2023);

            var observanceIn2024 = newYearsDayHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 1, 1), observanceIn2024);

            var observanceIn2025 = newYearsDayHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 1, 1), observanceIn2025);
        }
        // Test for Eid ul-Fitr
        [Test]
        public void EidUlFitrTest()
        {
            var eidUlFitrHoliday = IndianHolidayStrategy.EidUlFitr;

            var observanceIn2023 = eidUlFitrHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 4, 21), observanceIn2023);

            var observanceIn2024 = eidUlFitrHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 4, 10), observanceIn2024);

            var observanceIn2025 = eidUlFitrHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 3, 30), observanceIn2025);
        }
        // Test for Eid ul-Adha
        [Test]
        public void EidUlAdhaTest()
        {
            var eidUlAdhaHoliday = IndianHolidayStrategy.EidUlAdha;

            var observanceIn2023 = eidUlAdhaHoliday.GetInstance(2023);
            Assert.AreEqual(new DateTime(2023, 6, 29), observanceIn2023);

            var observanceIn2024 = eidUlAdhaHoliday.GetInstance(2024);
            Assert.AreEqual(new DateTime(2024, 6, 17), observanceIn2024);

            var observanceIn2025 = eidUlAdhaHoliday.GetInstance(2025);
            Assert.AreEqual(new DateTime(2025, 6, 6), observanceIn2025);
        }

        public void CanGetIndianHolidaysListIn2025()
        {
            var cultureInfo = new WorkingDayCultureInfo("en-IN");
            Assert.IsNotNull(cultureInfo);
            var holidays = cultureInfo.GetHolidaysOfYear(2025);
            Assert.AreEqual(12, holidays.Count()); // 12 holidays in 2025 including New year
          
        }
    }
}
