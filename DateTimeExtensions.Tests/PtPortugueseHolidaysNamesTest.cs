using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DateTimeExtensions.WorkingDays;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class PtPortugueseHolidaysNamesTest
    {
        [TestFixtureSetUp]
        public void SetUp() {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-PT");
        }

        [Test]
        public void AssertPortugueseWorkerDayIsTranslated() {
            var holiday = GlobalHolidays.InternationalWorkersDay;
            Assert.AreEqual(holiday.Name, "Dia do Trabalhador");
        }
    }
}
