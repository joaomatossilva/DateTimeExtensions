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
            Assert.AreEqual(PT_PTHolidayStrategy.FreedomDay.Value.Name, "Freedom Day");
            Assert.AreEqual(PT_PTHolidayStrategy.PortugalDay.Value.Name, "Portugal Day");
            Assert.AreEqual(PT_PTHolidayStrategy.RepublicDay.Value.Name, "Republic Day");
            Assert.AreEqual(PT_PTHolidayStrategy.RestorationOfIndependance.Value.Name, "Restoration of Independance");

            new CultureInfo("pt-PT").SetCurrentUICultureInfo();
            Assert.AreEqual("pt-PT", CultureInfo.CurrentUICulture.Name);

            Assert.AreEqual(PT_PTHolidayStrategy.FreedomDay.Value.Name, "Dia da Liberdade");
            Assert.AreEqual(PT_PTHolidayStrategy.PortugalDay.Value.Name, "Dia de Portugal");
            Assert.AreEqual(PT_PTHolidayStrategy.RepublicDay.Value.Name, "Dia da Republica");

            Assert.AreEqual(ChristianHolidays.Christmas.Value.Name, "Natal");
            Assert.AreEqual(GlobalHolidays.NewYear.Value.Name, "Ano Novo");
            Assert.AreEqual(ChristianHolidays.Carnival.Value.Name, "Carnaval");
            Assert.AreEqual(ChristianHolidays.AllSaints.Value.Name, "Todos os Santos");
            Assert.AreEqual(ChristianHolidays.CorpusChristi.Value.Name, "Corpo de Cristo");
            Assert.AreEqual(ChristianHolidays.Easter.Value.Name, "Pascoa");
            Assert.AreEqual(ChristianHolidays.GoodFriday.Value.Name, "Sexta-feira Santa");
            Assert.AreEqual(ChristianHolidays.Assumption.Value.Name, "Nossa Srª Assunção");
            Assert.AreEqual(ChristianHolidays.ImaculateConception.Value.Name, "Imaculada Conceição");
            Assert.AreEqual(ChristianHolidays.MaundyThursday.Value.Name, "Quinta-feira de Cinzas");
            Assert.AreEqual(ChristianHolidays.ChristmasEve.Value.Name, "Vespera de Natal");
            Assert.AreEqual(GlobalHolidays.InternationalWorkersDay.Value.Name, "Dia do Trabalhador");
            Assert.AreEqual(PT_PTHolidayStrategy.RestorationOfIndependance.Value.Name, "Restauração da Independência");
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

            Assert.AreEqual(PT_BRHolidayStrategy.IndependanceDay.Value.Name, "Dia da Independência");
            Assert.AreEqual(PT_BRHolidayStrategy.OurLadyOfAparecida.Value.Name, "Nossa Srª da Aparecida");
            Assert.AreEqual(PT_BRHolidayStrategy.RepublicDay.Value.Name, "Dia da Republica");
            Assert.AreEqual(PT_BRHolidayStrategy.TiradentesDay.Value.Name, "Dia do Tiradentes");

            Assert.AreEqual(ChristianHolidays.Christmas.Value.Name, "Natal");
            Assert.AreEqual(GlobalHolidays.NewYear.Value.Name, "Ano Novo");
            Assert.AreEqual(ChristianHolidays.Carnival.Value.Name, "Carnaval");
            Assert.AreEqual(ChristianHolidays.AllSaints.Value.Name, "Todos os Santos");
            Assert.AreEqual(ChristianHolidays.CorpusChristi.Value.Name, "Corpo de Cristo");
            Assert.AreEqual(ChristianHolidays.Easter.Value.Name, "Pascoa");
            Assert.AreEqual(ChristianHolidays.GoodFriday.Value.Name, "Sexta-feira Santa");
            Assert.AreEqual(ChristianHolidays.Assumption.Value.Name, "Nossa Srª Assunção");
            Assert.AreEqual(ChristianHolidays.ImaculateConception.Value.Name, "Imaculada Conceição");
            Assert.AreEqual(ChristianHolidays.MaundyThursday.Value.Name, "Quinta-feira de Cinzas");
            Assert.AreEqual(ChristianHolidays.ChristmasEve.Value.Name, "Vespera de Natal");
            Assert.AreEqual(GlobalHolidays.InternationalWorkersDay.Value.Name, "Dia do Trabalhador");
            Assert.AreEqual(ChristianHolidays.DayOfTheDead.Value.Name, "Dia de Finados");
        }
    }
}