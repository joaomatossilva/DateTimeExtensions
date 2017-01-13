using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DateTimeExtensions.WorkingDays;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class GenericCalendarTests
    {
        private WorkingDayCultureInfo foo_ci = new WorkingDayCultureInfo("foo");

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
                    Assert.IsFalse(testDate.IsWorkingDay(foo_ci),
                        Enum.GetName(typeof (DayOfWeek), testDate.DayOfWeek) + " is not be a working day by default");
                }
                else
                {
                    Assert.IsTrue(testDate.IsWorkingDay(foo_ci),
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

            DateTime startPlus5 = startDate.AddWorkingDays(5, foo_ci);
            Assert.IsTrue(startPlus5.DayOfWeek == DayOfWeek.Monday);

            DateTime startPlus4 = startDate.AddWorkingDays(4, foo_ci);
            Assert.IsTrue(startPlus4.DayOfWeek == DayOfWeek.Friday);

            Assert.IsTrue(startDate == referenceDate);
        }

        [Test]
        public void subtracting_working_days_should_not_count_weekends()
        {
            DateTime startDate = new DateTime(2011, 5, 2); //Monday
            DateTime referenceDate = startDate;
            Assert.IsTrue(startDate.DayOfWeek == DayOfWeek.Monday);
            Assert.IsTrue(startDate == referenceDate);

            DateTime startMinus5 = startDate.AddWorkingDays(-5, foo_ci);
            Assert.IsTrue(startMinus5.DayOfWeek == DayOfWeek.Monday);

            DateTime startMinus1 = startDate.AddWorkingDays(-1, foo_ci);
            Assert.IsTrue(startMinus1.DayOfWeek == DayOfWeek.Friday);

            Assert.IsTrue(startDate == referenceDate);
        }

        [Test]
        public void adding_zero_working_days_should_return_same_day()
        {
            DateTime startDate = new DateTime(2011, 5, 2); //Monday
            Assert.IsTrue(startDate.DayOfWeek == DayOfWeek.Monday);

            DateTime startPlus0 = startDate.AddWorkingDays(0, foo_ci);
            Assert.IsTrue(startPlus0.DayOfWeek == DayOfWeek.Monday);
            Assert.IsTrue(startDate == startPlus0);
        }

        [Test]
        public void adding_large_number_of_days()
        {
            DateTime startDate = new DateTime(2011, 5, 2); //Monday
            Assert.IsTrue(startDate.DayOfWeek == DayOfWeek.Monday);

            DateTime startPlus60 = startDate.AddWorkingDays(60, foo_ci);
            Assert.IsTrue(startPlus60.DayOfWeek == DayOfWeek.Monday);
        }

        [Test]
        public void get_working_days()
        {
            var start = new DateTime(2016, 11, 14); //monday
            var end = new DateTime(2016, 11, 21); // next week monday

            Assert.IsTrue(start.GetWorkingDays(end) == 5);
        }

        [Test]
        public void get_working_days_reverse()
        {
            var start = new DateTime(2016, 11, 21); //monday
            var end = new DateTime(2016, 11, 14); // week before monday

            Assert.IsTrue(start.GetWorkingDays(end) == 5);
        }

        [Test]
        public void get_working_days_same_day()
        {
            var start = new DateTime(2016, 11, 14); //monday
            var end = new DateTime(2016, 11, 14); // same day

            Assert.IsTrue(start.GetWorkingDays(end) == 0);
        }
    }
}