using NUnit.Framework;
using System.Globalization;

namespace DateTimeExtensions.Tests.HolidaysTranslations
{
    [TestFixture]
    public class RomanianHolidayNamesTest
    {
        [SetUp]
        public void Setup()
        {
            //setup a default culture
            new CultureInfo("ro-RO").SetCurrentUICultureInfo();
        }

        [Test]
        public void AssertRomanianHolidaysAreTranslated()
        {
            //Assert.AreEqual(ES_ESHolidayStrategy.NationalDay.Name, "National Day");
        }
    }
}