using System.Globalization;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests.HolidaysTranslations
{
    [TestFixture]
    public class ViHolidaysNamesTest
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            new CultureInfo("vi-VN").SetCurrentUICultureInfo();
        }

        [Test]
        public void AssertVietNamHolidaysAreTranslated()
        {
            StringAssert.AreEqualIgnoringCase("Quốc khánh", ViVNHolidayStrategy.NationalDay.Name);
            StringAssert.AreEqualIgnoringCase("Ngày Giải phóng miền Nam thống nhất đất nước", ViVNHolidayStrategy.LiberationDay.Name);
            StringAssert.AreEqualIgnoringCase("Ngày Quốc tế Lao động", ViVNHolidayStrategy.InternationalWorkersDay.Name);
            StringAssert.AreEqualIgnoringCase("Giỗ tổ Hùng Vương", ViVNHolidayStrategy.HungKingsCommemorations.Name);
            StringAssert.AreEqualIgnoringCase("tết tây", ViVNHolidayStrategy.NewYear.Name);
        }
    }
}