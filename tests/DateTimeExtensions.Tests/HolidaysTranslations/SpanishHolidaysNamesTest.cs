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
        [OneTimeSetUp]
        public void Setup()
        {
            //setup a default culture
            new CultureInfo("en-US").SetCurrentUICultureInfo();
        }

        [Test]
        public void AssertSpanishHolidaysAreTranslated()
        {
            //test holidays still on default culture (en-US)
            Assert.AreEqual(ES_ESHolidayStrategy.NationalDay.Value.Name, "National Day");
            Assert.AreEqual(ES_ESHolidayStrategy.ConstitutionDay.Value.Name, "Constitution Day");

            new CultureInfo("es-ES").SetCurrentUICultureInfo();
            Assert.AreEqual("es-ES", CultureInfo.CurrentUICulture.Name);

            Assert.AreEqual(ES_ESHolidayStrategy.NationalDay.Value.Name, "Fiesta Nacional de España");
            Assert.AreEqual(ES_ESHolidayStrategy.ConstitutionDay.Value.Name, "Día de la Constitución");

            Assert.AreEqual(ChristianHolidays.Christmas.Value.Name, "Natividad");
            Assert.AreEqual(GlobalHolidays.NewYear.Value.Name, "Año Nuevo");
            Assert.AreEqual(ChristianHolidays.Epiphany.Value.Name, "Epifanía del Señor");
            Assert.AreEqual(ChristianHolidays.Carnival.Value.Name, "Carnaval");
            Assert.AreEqual(ChristianHolidays.AllSaints.Value.Name, "Todos los Santos");
            Assert.AreEqual(ChristianHolidays.CorpusChristi.Value.Name, "Corpus Cristi");
            Assert.AreEqual(ChristianHolidays.Easter.Value.Name, "Pascua");
            Assert.AreEqual(ChristianHolidays.GoodFriday.Value.Name, "Viernes Santo");
            Assert.AreEqual(ChristianHolidays.MaundyThursday.Value.Name, "Jueves Santo");
            Assert.AreEqual(ChristianHolidays.Assumption.Value.Name, "Asunción de la Virgen");
            Assert.AreEqual(ChristianHolidays.ImaculateConception.Value.Name, "La Inmaculada Concepción");
            Assert.AreEqual(ChristianHolidays.Pentecost.Value.Name, "Pentecostés");
            Assert.AreEqual(ChristianHolidays.PentecostMonday.Value.Name, "Lunes de Pentecostés");
            Assert.AreEqual(GlobalHolidays.InternationalWorkersDay.Value.Name, "Fiesta del Trabajo");
        }
    }
}