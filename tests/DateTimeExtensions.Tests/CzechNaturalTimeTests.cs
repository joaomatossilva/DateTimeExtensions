using DateTimeExtensions.NaturalText;
using NUnit.Framework;
using System;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class CzechNaturalTimeTests
    {
        private NaturalTextCultureInfo czechTextCulture = new NaturalTextCultureInfo("cs-CZ");
        private DateTime fromTime = new DateTime(2025, 1, 23, 5, 21, 10);

        [Test]
        public void Can_Tranlate_To_Natural_Text_Czech()
        {
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var actualText = fromTime.ToNaturalText(toTime, false, czechTextCulture);

            Assert.IsNotNull(actualText);
            Assert.IsNotEmpty(actualText);
            Assert.That(actualText, Is.EqualTo("2 hodiny"));
        }

        [Test]
        public void Can_Tranlate_To_Natural_Text_Rounded_Czech()
        {
            var toTime = fromTime.AddHours(2).AddMinutes(45);

            var actualText = fromTime.ToNaturalText(toTime, true, czechTextCulture);

            Assert.IsNotNull(actualText);
            Assert.IsNotEmpty(actualText);
            Assert.That(actualText, Is.EqualTo("3 hodiny"));
        }


        [Test]
        public void Can_Tranlate_To_Exact_Natural_Text_Czech()
        {
            var toTime = fromTime.AddHours(2).AddMinutes(30);

            var actualText = fromTime.ToExactNaturalText(toTime, czechTextCulture);

            Assert.IsNotNull(actualText);
            Assert.IsNotEmpty(actualText);
            Assert.That(actualText, Is.EqualTo("2 hodiny, 30 minut"));
        }

        [Test]
        [TestCase(1, "1 rok")]
        [TestCase(2, "2 roky")]
        [TestCase(3, "3 roky")]
        [TestCase(4, "4 roky")]
        [TestCase(5, "5 let")]
        [TestCase(12, "12 let")]
        [TestCase(7, "7 let")]
        public void Correct_Form_Of_Year_In_Czech(int years, string expectedText)
        {
            var toTime = fromTime.AddYears(years);
            var actualText = fromTime.ToExactNaturalText(toTime, czechTextCulture);
            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        [Test]
        [TestCase(1, "1 měsíc")]
        [TestCase(2, "2 měsíce")]
        [TestCase(3, "3 měsíce")]
        [TestCase(4, "4 měsíce")]
        [TestCase(5, "5 měsíců")]
        [TestCase(11, "11 měsíců")]
        [TestCase(7, "7 měsíců")]
        public void Correct_Form_Of_Month_In_Czech(int months, string expectedText)
        {
            var toTime = fromTime.AddMonths(months);
            var actualText = fromTime.ToExactNaturalText(toTime, czechTextCulture);
            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        [Test]
        [TestCase(1, "1 den")]
        [TestCase(2, "2 dny")]
        [TestCase(3, "3 dny")]
        [TestCase(4, "4 dny")]
        [TestCase(5, "5 dnů")]
        [TestCase(12, "12 dnů")]
        [TestCase(7, "7 dnů")]
        public void Correct_Form_Of_Day_In_Czech(int days, string expectedText)
        {
            var toTime = fromTime.AddDays(days);
            var actualText = fromTime.ToExactNaturalText(toTime, czechTextCulture);
            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        [Test]
        [TestCase(1, "1 hodina")]
        [TestCase(2, "2 hodiny")]
        [TestCase(3, "3 hodiny")]
        [TestCase(4, "4 hodiny")]
        [TestCase(5, "5 hodin")]
        [TestCase(12, "12 hodin")]
        [TestCase(7, "7 hodin")]
        public void Correct_Form_Of_Hour_In_Czech(int hours, string expectedText)
        {
            var toTime = fromTime.AddHours(hours);
            var actualText = fromTime.ToExactNaturalText(toTime, czechTextCulture);
            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        [Test]
        [TestCase(1, "1 minuta")]
        [TestCase(2, "2 minuty")]
        [TestCase(3, "3 minuty")]
        [TestCase(4, "4 minuty")]
        [TestCase(5, "5 minut")]
        [TestCase(12, "12 minut")]
        [TestCase(7, "7 minut")]
        public void Correct_Form_Of_Minute_In_Czech(int minutes, string expectedText)
        {
            var toTime = fromTime.AddMinutes(minutes);
            var actualText = fromTime.ToExactNaturalText(toTime, czechTextCulture);
            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        [Test]
        [TestCase(1, "1 vteřina")]
        [TestCase(2, "2 vteřiny")]
        [TestCase(3, "3 vteřiny")]
        [TestCase(4, "4 vteřiny")]
        [TestCase(5, "5 vteřin")]
        [TestCase(12, "12 vteřin")]
        [TestCase(7, "7 vteřin")]
        public void Correct_Form_Of_Second_In_Czech(int seconds, string expectedText)
        {
            var toTime = fromTime.AddSeconds(seconds);
            var actualText = fromTime.ToExactNaturalText(toTime, czechTextCulture);
            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        [Test]
        [TestCase(1, "1 rok, 1 měsíc, 1 den, 1 hodina, 1 minuta, 1 vteřina")]
        [TestCase(3, "3 roky, 3 měsíce, 3 dny, 3 hodiny, 3 minuty, 3 vteřiny")]
        [TestCase(6, "6 let, 6 měsíců, 6 dnů, 6 hodin, 6 minut, 6 vteřin")]
        public void Can_Translate_To_Czech_Full(int addedTime, string expectedText)
        {
            var toTime = fromTime.AddYears(addedTime).AddMonths(addedTime).AddDays(addedTime).AddHours(addedTime).AddMinutes(addedTime).AddSeconds(addedTime);
            var actualText = fromTime.ToExactNaturalText(toTime, czechTextCulture);
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
    }
}
