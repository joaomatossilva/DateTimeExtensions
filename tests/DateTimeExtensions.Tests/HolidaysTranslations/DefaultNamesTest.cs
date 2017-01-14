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
        [TestFixtureSetUp]
        public void Setup()
        {
            //setup a default culture
            new CultureInfo("en-US").SetCurrentCultureInfo();
        }

        [Test]
        public void AssertDefaultGlobalHolidaysAreTranslated()
        {
            Assert.AreEqual(ChristianHolidays.Christmas.Name, "Christmas");
            Assert.AreEqual(GlobalHolidays.NewYear.Name, "New Year");
            Assert.AreEqual(ChristianHolidays.Carnival.Name, "Carnival");
            Assert.AreEqual(ChristianHolidays.AllSaints.Name, "All Saints");
            Assert.AreEqual(ChristianHolidays.CorpusChristi.Name, "Corpus Christi");
            Assert.AreEqual(ChristianHolidays.Easter.Name, "Easter");
            Assert.AreEqual(ChristianHolidays.GoodFriday.Name, "Good Friday");
            Assert.AreEqual(ChristianHolidays.Assumption.Name, "Assumption");
            Assert.AreEqual(ChristianHolidays.ImaculateConception.Name, "Imaculate Conception");
            Assert.AreEqual(ChristianHolidays.MaundyThursday.Name, "Maundy Thursday");
            Assert.AreEqual(ChristianHolidays.ImaculateConception.Name, "Imaculate Conception");
            Assert.AreEqual(ChristianHolidays.DayOfTheDead.Name, "Day of the Dead");
            Assert.AreEqual(GlobalHolidays.InternationalWorkersDay.Name, "International Workers' day");
        }
    }
}