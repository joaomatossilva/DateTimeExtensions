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
    public class PtPortugueseHolidaysNamesTest
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            //setup a default culture
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }

        [Test]
        public void AssertDefaultGlobalHolidaysAreTranslated()
        {
            Assert.AreEqual(ChristianHolidays.Christmas.Name, "Christmas");
            Assert.AreEqual(ChristianHolidays.NewYear.Name, "New Year");
            Assert.AreEqual(ChristianHolidays.Carnival.Name, "Carnival");
            Assert.AreEqual(ChristianHolidays.AllSaints.Name, "All Saints");
            Assert.AreEqual(ChristianHolidays.CorpusChristi.Name, "Corpus Christi");
            Assert.AreEqual(ChristianHolidays.Easter.Name, "Easter");
            Assert.AreEqual(ChristianHolidays.GoodFriday.Name, "Good Friday");
            Assert.AreEqual(ChristianHolidays.Assumption.Name, "Assumption");
            Assert.AreEqual(ChristianHolidays.ImaculateConception.Name, "Imaculate Conception");
            Assert.AreEqual(ChristianHolidays.MaundyThursday.Name, "Maundy Thursday");
            Assert.AreEqual(ChristianHolidays.ChristmasEve.Name, "Christmas Eve");
            Assert.AreEqual(GlobalHolidays.InternationalWorkersDay.Name, "International Workers' day");
        }

        [Test]
        public void AssertPortugueseHolidaysAreTranslated() 
        {
            //test holidays still on default culture (en-US)
            Assert.AreEqual(PT_PTHolidayStrategy.FreedomDay.Name, "Freedom Day");
            Assert.AreEqual(PT_PTHolidayStrategy.PortugalDay.Name, "Portugal Day");
            Assert.AreEqual(PT_PTHolidayStrategy.RepublicDay.Name, "Republic Day");
            Assert.AreEqual(PT_PTHolidayStrategy.RestorationOfIndependance.Name, "Restoration of Independance");

            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-PT");
            Assert.AreEqual(ChristianHolidays.Christmas.Name, "Natal");
            Assert.AreEqual(ChristianHolidays.NewYear.Name, "Ano Novo");
            Assert.AreEqual(ChristianHolidays.Carnival.Name, "Carnaval");
            Assert.AreEqual(ChristianHolidays.AllSaints.Name, "Todos os Santos");
            Assert.AreEqual(ChristianHolidays.CorpusChristi.Name, "Corpo de Cristo");
            Assert.AreEqual(ChristianHolidays.Easter.Name, "Pascoa");
            Assert.AreEqual(ChristianHolidays.GoodFriday.Name, "Sexta-feira Santa");
            Assert.AreEqual(ChristianHolidays.Assumption.Name, "Nossa Srª Assunção");
            Assert.AreEqual(ChristianHolidays.ImaculateConception.Name, "Imaculada Conceição");
            Assert.AreEqual(ChristianHolidays.MaundyThursday.Name, "Quinta-feira de Cinzas");
            Assert.AreEqual(ChristianHolidays.ChristmasEve.Name, "Vespera de Natal");
            Assert.AreEqual(GlobalHolidays.InternationalWorkersDay.Name, "Dia do Trabalhador");
            Assert.AreEqual(PT_PTHolidayStrategy.FreedomDay.Name, "Dia da Liberdade");
            Assert.AreEqual(PT_PTHolidayStrategy.PortugalDay.Name, "Dia de Portugal");
            Assert.AreEqual(PT_PTHolidayStrategy.RepublicDay.Name, "Dia da Republica");
            Assert.AreEqual(PT_PTHolidayStrategy.RestorationOfIndependance.Name, "Restauração da Independência");
        }
    }
}
