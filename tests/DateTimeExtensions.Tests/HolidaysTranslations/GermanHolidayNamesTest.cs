using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;
using System.Globalization;

namespace DateTimeExtensions.Tests.HolidaysTranslations
{
    [TestFixture]
    public class GermanHolidayNamesTest
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            //setup a default culture
           new CultureInfo("en-US").SetCurrentUICultureInfo();
        }

        [Test]
        public void AssertGermanHolidaysAreTranslated()
        {
            //test holidays still on default culture (en-US)
            Assert.AreEqual(DE_DEHolidayStrategy.GermanUnityDay.Name, "German Unity Day");

            new CultureInfo("de-DE").SetCurrentUICultureInfo();
            Assert.AreEqual("de-DE", CultureInfo.CurrentUICulture.Name);

            Assert.AreEqual(DE_DEHolidayStrategy.GermanUnityDay.Name, "Tag der Deutschen Einheit");

            Assert.AreEqual(ChristianHolidays.Christmas.Name, "Weihnachten");
            Assert.AreEqual(GlobalHolidays.NewYear.Name, "Neujahr");
            Assert.AreEqual(ChristianHolidays.Epiphany.Name, "Heilige Drei Könige");
            Assert.AreEqual(ChristianHolidays.Carnival.Name, "Fasching");
            Assert.AreEqual(ChristianHolidays.AllSaints.Name, "Allerheiligen");
            Assert.AreEqual(ChristianHolidays.CorpusChristi.Name, "Fronleichnam");
            Assert.AreEqual(ChristianHolidays.Easter.Name, "Ostern");
            Assert.AreEqual(ChristianHolidays.GoodFriday.Name, "Karfreitag");
            Assert.AreEqual(ChristianHolidays.MaundyThursday.Name, "Gründonnerstag");
            Assert.AreEqual(ChristianHolidays.Assumption.Name, "Maria Himmelfahrt");
            Assert.AreEqual(ChristianHolidays.ImaculateConception.Name, "Maria Empfängnis");
            Assert.AreEqual(ChristianHolidays.Pentecost.Name, "Pfingsten");
            Assert.AreEqual(ChristianHolidays.PentecostMonday.Name, "Pfingstmontag");
            Assert.AreEqual(GlobalHolidays.InternationalWorkersDay.Name, "Tag der Arbeit");
        }
    }
}
