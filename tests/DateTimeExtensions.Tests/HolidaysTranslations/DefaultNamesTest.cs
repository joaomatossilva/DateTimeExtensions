using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class DefaultNamesTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            //setup a default culture
            new CultureInfo("en-US").SetCurrentCultureInfo();
        }

        [Test]
        public void AssertDefaultGlobalHolidaysAreTranslated()
        {
            Assert.AreEqual(ChristianHolidays.Christmas.Value.Name, "Christmas");
            Assert.AreEqual(GlobalHolidays.NewYear.Value.Name, "New Year");
            Assert.AreEqual(ChristianHolidays.Carnival.Value.Name, "Carnival");
            Assert.AreEqual(ChristianHolidays.AllSaints.Value.Name, "All Saints");
            Assert.AreEqual(ChristianHolidays.CorpusChristi.Value.Name, "Corpus Christi");
            Assert.AreEqual(ChristianHolidays.Easter.Value.Name, "Easter");
            Assert.AreEqual(ChristianHolidays.GoodFriday.Value.Name, "Good Friday");
            Assert.AreEqual(ChristianHolidays.Assumption.Value.Name, "Assumption");
            Assert.AreEqual(ChristianHolidays.ImaculateConception.Value.Name, "Imaculate Conception");
            Assert.AreEqual(ChristianHolidays.MaundyThursday.Value.Name, "Maundy Thursday");
            Assert.AreEqual(ChristianHolidays.ImaculateConception.Value.Name, "Imaculate Conception");
            Assert.AreEqual(ChristianHolidays.DayOfTheDead.Value.Name, "Day of the Dead");
            Assert.AreEqual(GlobalHolidays.InternationalWorkersDay.Value.Name, "International Workers' day");
        }
    }
}