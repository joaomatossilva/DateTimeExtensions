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
    public class KRHolidaysNamesTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            //setup a default culture
            new CultureInfo("en-US").SetCurrentUICultureInfo();
        }

        [Test]
        public void AssertKoreanHolidaysAreTranslated()
        {
            //test holidays still on default culture (en-US)
            Assert.AreEqual(KO_KRHolidayStrategy.Seolnal.Value.Name, "Seolnal");

            new CultureInfo("ko-KR").SetCurrentUICultureInfo();
            Assert.AreEqual("ko-KR", CultureInfo.CurrentUICulture.Name);

            Assert.AreEqual(KO_KRHolidayStrategy.Seolnal.Value.Name, "설날");
            Assert.AreEqual(KO_KRHolidayStrategy.Samiljeol.Value.Name, "삼일절");
            Assert.AreEqual(KO_KRHolidayStrategy.Eorininal.Value.Name, "어린이날");
            Assert.AreEqual(KO_KRHolidayStrategy.SeokgaTansinil.Value.Name, "석가탄신일");
            Assert.AreEqual(KO_KRHolidayStrategy.Hyeonchungil.Value.Name, "현충일");
            Assert.AreEqual(KO_KRHolidayStrategy.Gwangbokjeol.Value.Name, "광복절");
            Assert.AreEqual(KO_KRHolidayStrategy.Chuseok.Value.Name, "추석");
            Assert.AreEqual(KO_KRHolidayStrategy.Gaecheonjeol.Value.Name, "개천절");
            Assert.AreEqual(KO_KRHolidayStrategy.Hangulnal.Value.Name, "한글날");

            Assert.AreEqual(ChristianHolidays.Christmas.Value.Name, "성탄절");
            Assert.AreEqual(GlobalHolidays.NewYear.Value.Name, "신정");
            Assert.AreEqual(GlobalHolidays.InternationalWorkersDay.Value.Name, "근로자의 날");
        }
    }
}