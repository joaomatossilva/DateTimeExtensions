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
    public class SpanishHolidaysNamesTest
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            //setup a default culture
            new CultureInfo("en-US").SetCurrentUICultureInfo();
        }

        [Test]
        public void AssertSpanishHolidaysAreTranslated()
        {
            //test holidays still on default culture (en-US)
            Assert.AreEqual(ES_ESHolidayStrategy.NationalDay.Name, "National Day");
            Assert.AreEqual(ES_ESHolidayStrategy.ConstitutionDay.Name, "Constitution Day");

            new CultureInfo("es-ES").SetCurrentUICultureInfo();
            Assert.AreEqual("es-ES", CultureInfo.CurrentUICulture.Name);

            Assert.AreEqual(ES_ESHolidayStrategy.NationalDay.Name, "Fiesta Nacional de España");
            Assert.AreEqual(ES_ESHolidayStrategy.ConstitutionDay.Name, "Día de la Constitución");

            Assert.AreEqual(ChristianHolidays.Christmas.Name, "Natividad");
            Assert.AreEqual(GlobalHolidays.NewYear.Name, "Año Nuevo");
            Assert.AreEqual(ChristianHolidays.Epiphany.Name, "Epifanía del Señor");
            Assert.AreEqual(ChristianHolidays.Carnival.Name, "Carnaval");
            Assert.AreEqual(ChristianHolidays.AllSaints.Name, "Todos los Santos");
            Assert.AreEqual(ChristianHolidays.CorpusChristi.Name, "Corpus Cristi");
            Assert.AreEqual(ChristianHolidays.Easter.Name, "Pascua");
            Assert.AreEqual(ChristianHolidays.GoodFriday.Name, "Viernes Santo");
            Assert.AreEqual(ChristianHolidays.MaundyThursday.Name, "Jueves Santo");
            Assert.AreEqual(ChristianHolidays.Assumption.Name, "Asunción de la Virgen");
            Assert.AreEqual(ChristianHolidays.ImaculateConception.Name, "La Inmaculada Concepción");
            Assert.AreEqual(ChristianHolidays.Pentecost.Name, "Pentecostés");
            Assert.AreEqual(ChristianHolidays.PentecostMonday.Name, "Lunes de Pentecostés");
            Assert.AreEqual(GlobalHolidays.InternationalWorkersDay.Name, "Fiesta del Trabajo");
        }
    }
}