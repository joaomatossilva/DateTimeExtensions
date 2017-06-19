using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using DateTimeExtensions.WorkingDays.RegionIdentifiers;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class PTCalendarTests
    {
        private WorkingDayCultureInfo pt_ci = new WorkingDayCultureInfo("pt-PT");

        [Test]
        public void default_working_days()
        {
            DateTime startDate = new DateTime(2011, 5, 2); //Monday
            DateTime referenceDate = startDate;
            Assert.IsTrue(startDate.DayOfWeek == DayOfWeek.Monday);
            Assert.IsTrue(startDate == referenceDate);

            for (int i = 0; i < 7; i++)
            {
                var testDate = startDate.AddDays(i);
                if (testDate.DayOfWeek == DayOfWeek.Saturday || testDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    Assert.IsFalse(testDate.IsWorkingDay(pt_ci),
                        Enum.GetName(typeof (DayOfWeek), testDate.DayOfWeek) + " is not be a working day by default");
                }
                else
                {
                    Assert.IsTrue(testDate.IsWorkingDay(pt_ci),
                        Enum.GetName(typeof (DayOfWeek), testDate.DayOfWeek) + " is be a working day by default");
                }
            }

            Assert.IsTrue(startDate == referenceDate);
        }

        [Test]
        public void adding_working_days_should_not_count_weekends()
        {
            DateTime startDate = new DateTime(2011, 5, 2); //Monday
            DateTime referenceDate = startDate;
            Assert.IsTrue(startDate.DayOfWeek == DayOfWeek.Monday);
            Assert.IsTrue(startDate == referenceDate);

            DateTime startPlus5 = startDate.AddWorkingDays(5, pt_ci);
            Assert.IsTrue(startPlus5.DayOfWeek == DayOfWeek.Monday);

            DateTime startPlus4 = startDate.AddWorkingDays(4, pt_ci);
            Assert.IsTrue(startPlus4.DayOfWeek == DayOfWeek.Friday);

            Assert.IsTrue(startDate == referenceDate);
        }

        [Test]
        public void subtracting_working_days_should_not_count_weekends()
        {
            DateTime startDate = new DateTime(2011, 5, 9); //Monday
            DateTime referenceDate = startDate;
            Assert.IsTrue(startDate.DayOfWeek == DayOfWeek.Monday);
            Assert.IsTrue(startDate == referenceDate);

            DateTime startMinus5 = startDate.AddWorkingDays(-5, pt_ci);
            Assert.IsTrue(startMinus5.DayOfWeek == DayOfWeek.Monday);

            DateTime startMinus1 = startDate.AddWorkingDays(-1, pt_ci);
            Assert.IsTrue(startMinus1.DayOfWeek == DayOfWeek.Friday);

            Assert.IsTrue(startDate == referenceDate);
        }

        [Test]
        public void adding_zero_working_days_should_return_same_day()
        {
            DateTime startDate = new DateTime(2011, 5, 2); //Monday
            Assert.IsTrue(startDate.DayOfWeek == DayOfWeek.Monday);

            DateTime startPlus0 = startDate.AddWorkingDays(0, pt_ci);
            Assert.IsTrue(startPlus0.DayOfWeek == DayOfWeek.Monday);
            Assert.IsTrue(startDate == startPlus0);
        }

        [Test]
        public void adding_large_number_of_days()
        {
            DateTime startDate = new DateTime(2011, 5, 2); //Monday
            Assert.IsTrue(startDate.DayOfWeek == DayOfWeek.Monday);

            //we substract 2 working day because in 60 days we get an holiday at 10-6 and another at 23-6
            DateTime startPlus60 = startDate.AddWorkingDays(60 - 2, pt_ci);
            Assert.IsTrue(startPlus60.DayOfWeek == DayOfWeek.Monday);
        }

        [Test]
        public void use_holidays_in_calulations()
        {
            DateTime startDate = new DateTime(2011, 4, 21);

            //21-04-2011 - start
            //22-04-2011 - holiday
            //23-04-2011 - saturday
            //24-04-2011 - sunday
            //25-04-2011 - holiday
            //26-04-2011 - end

            DateTime endDate = startDate.AddWorkingDays(1, pt_ci);
            Assert.IsTrue(endDate == startDate.AddDays(5), "Expecting 26-04-2011 but got " + endDate.ToString("dd-MM-yyyy"));
        }

        [Test]
        public void can_use_christian_holidays_in_calulations()
        {
            DateTime corpus = new DateTime(2010, 12, 8);

            Assert.IsFalse(corpus.IsWorkingDay(pt_ci));
            Assert.IsTrue(corpus.IsHoliday(pt_ci));
        }

        [Test]
        public void can_use_national_holidays_in_calulations()
        {
            DateTime nationalDay = new DateTime(2011, 6, 10);

            Assert.IsFalse(nationalDay.IsWorkingDay(pt_ci));
            Assert.IsTrue(nationalDay.IsHoliday(pt_ci));
        }

        [Test]
        public void can_use_reginal_holidays_Lisboa()
        {
            var cultureInfo = new WorkingDayCultureInfo("pt-PT", PortugalRegion.Lisboa);
            DateTime stAntonio = new DateTime(2017, 6, 13);

            Assert.AreEqual(stAntonio.DayOfWeek, DayOfWeek.Tuesday);
            Assert.IsTrue(stAntonio.IsHoliday(cultureInfo));
        }

        [Test]
        public void can_use_reginal_holidays_Porto()
        {
            var cultureInfo = new WorkingDayCultureInfo("pt-PT", PortugalRegion.Porto);
            DateTime stJoao = new DateTime(2017, 6, 24);

            Assert.AreEqual(stJoao.DayOfWeek, DayOfWeek.Saturday);
            Assert.IsTrue(stJoao.IsHoliday(cultureInfo));
        }

        [Test]
        public void can_use_reginal_holidays_CasteloBranco()
        {
            var cultureInfo = new WorkingDayCultureInfo("pt-PT", PortugalRegion.CasteloBranco);
            // not using 2017 since it's 25th April, same day as another national Holiday
            var sraMerculesDay = new DateTime(2016, 4, 5);

            Assert.AreEqual(sraMerculesDay.DayOfWeek, DayOfWeek.Tuesday);
            Assert.IsTrue(sraMerculesDay.IsHoliday(cultureInfo));
        }

        [Test]
        public void revert_to_national_holidays_on_unknown_region()
        {
            var cultureInfo = new WorkingDayCultureInfo("pt-PT", "non-existing-region");
            // not using 2017 since it's 25th April, same day as another national Holiday
            var sraMerculesDay = new DateTime(2017, 4, 25);

            Assert.AreEqual(sraMerculesDay.DayOfWeek, DayOfWeek.Tuesday);
            Assert.IsTrue(sraMerculesDay.IsHoliday(cultureInfo));
        }
    }
}