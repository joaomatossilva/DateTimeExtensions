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
    public class PortugueseHolidaysNamesTest
    {
        [SetUp]
        public void Setup()
        {
            //setup a default culture
            new CultureInfo("en-US").SetCurrentUICultureInfo();
        }

        [Test]
        public void AssertPortugueseHolidaysAreTranslated()
        {
            //test holidays still on default culture (en-US)
            Assert.AreEqual(PT_PTHolidayStrategy.FreedomDay.Name, "Freedom Day");
            Assert.AreEqual(PT_PTHolidayStrategy.PortugalDay.Name, "Portugal Day");
            Assert.AreEqual(PT_PTHolidayStrategy.RepublicDay.Name, "Republic Day");
            Assert.AreEqual(PT_PTHolidayStrategy.RestorationOfIndependance.Name, "Restoration of Independance");

            new CultureInfo("pt-PT").SetCurrentUICultureInfo();
            Assert.AreEqual("pt-PT", CultureInfo.CurrentUICulture.Name);

            Assert.AreEqual(PT_PTHolidayStrategy.FreedomDay.Name, "Dia da Liberdade");
            Assert.AreEqual(PT_PTHolidayStrategy.PortugalDay.Name, "Dia de Portugal");
            Assert.AreEqual(PT_PTHolidayStrategy.RepublicDay.Name, "Dia da Republica");

            Assert.AreEqual(ChristianHolidays.Christmas.Name, "Natal");
            Assert.AreEqual(GlobalHolidays.NewYear.Name, "Ano Novo");
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
            Assert.AreEqual(PT_PTHolidayStrategy.RestorationOfIndependance.Name, "Restauração da Independência");
        }

        [Test]
        public void AssertBrazilianHolidaysAreTranslated()
        {
            //test holidays still on default culture (en-US)
            /*
            Assert.AreEqual(PT_BRHolidayStrategy.IndependanceDay.Name, "Independance Day");
            Assert.AreEqual(PT_BRHolidayStrategy.OurLadyOfAparecida.Name, "Our Lady of Aparecida");
            Assert.AreEqual(PT_BRHolidayStrategy.RepublicDay.Name, "Republic Day");
            Assert.AreEqual(PT_BRHolidayStrategy.TiradentesDay.Name, "Tiradentes Day");
            */
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            new CultureInfo("pt-BR").SetCurrentUICultureInfo();
            Assert.AreEqual("pt-BR", CultureInfo.CurrentUICulture.Name);

            Assert.AreEqual(PT_BRHolidayStrategy.IndependanceDay.Name, "Dia da Independência");
            Assert.AreEqual(PT_BRHolidayStrategy.OurLadyOfAparecida.Name, "Nossa Srª da Aparecida");
            Assert.AreEqual(PT_BRHolidayStrategy.RepublicDay.Name, "Dia da Republica");
            Assert.AreEqual(PT_BRHolidayStrategy.TiradentesDay.Name, "Dia do Tiradentes");

            Assert.AreEqual(ChristianHolidays.Christmas.Name, "Natal");
            Assert.AreEqual(GlobalHolidays.NewYear.Name, "Ano Novo");
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
            Assert.AreEqual(ChristianHolidays.DayOfTheDead.Name, "Dia de Finados");
        }
    }
}