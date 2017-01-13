namespace DateTimeExtensions.Tests
{
    using System;
    using System.Linq;
    using DateTimeExtensions.WorkingDays;
    using NUnit.Framework;

    [TestFixture]
    public class NLHolidaysTests
    {
        private readonly WorkingDayCultureInfo dateTimeCulture = new WorkingDayCultureInfo("nl-NL");

        [Test]
        public void The_Netherlands_has_11_main_holidays()
        {
            var holidays = dateTimeCulture.Holidays;
            Assert.AreEqual(11, holidays.Count());
        }

        [Test]
        public void Kingsday_is_a_national_holiday_since_1885()
        {
            Assert.That(Kingsday(1885).IsHoliday(dateTimeCulture));
        }

        [Test]
        public void Kingsday_is_a_national_holiday_in_1949()
        {
            Assert.That(Kingsday(1949).IsHoliday(dateTimeCulture));
        }

        [Test]
        public void Kingsday_is_a_national_holiday_in_2014()
        {
            Assert.That(Kingsday(2014).IsHoliday(dateTimeCulture));
        }

        [Test]
        public void Liberation_Day_is_a_national_holiday_in_2005()
        {
            // Liberation_Day_is_a_national_holiday_once_every_5_years

            Assert.That(LiberationDay(2005).IsHoliday(dateTimeCulture));
        }

        [Test]
        public void Liberation_Day_is_a_regular_day_in_2006()
        {
            // Liberation_Day_is_a_national_holiday_once_every_5_years

            Assert.That(LiberationDay(2006).IsWorkingDay(dateTimeCulture));
        }

        private static DateTime Kingsday(int year)
        {
            if (year >= 2014)
            {
                return new DateTime(year, 4, 27);
            }

            if (year >= 1949)
            {
                return new DateTime(year, 4, 30);
            }

            if (year >= 1885)
            {
                return new DateTime(year, 8, 31);
            }

            throw new ArgumentException("No kingsday before 1885.");
        }

        private static DateTime LiberationDay(int year)
        {
            var liberationDay = new DateTime(year, 5, 5);

            return liberationDay;
        }
    }
}