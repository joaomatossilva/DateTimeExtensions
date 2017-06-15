using DateTimeExtensions.Common;
using DateTimeExtensions.WorkingDays;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading;
using DateTimeExtensions.WorkingDays.CultureStrategies;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class ExampleTests
    {
        [Test]
        public void simple_calculation()
        {
            var friday = new DateTime(2011, 5, 13); // A friday
            var friday_plus_two_working_days = friday.AddWorkingDays(2); // friday + 2 working days

            Assert.IsTrue(friday_plus_two_working_days == friday.AddDays(4));
            Assert.IsTrue(friday_plus_two_working_days.DayOfWeek == DayOfWeek.Tuesday);

            //not recomended because the default DateTimeCultureInfo by default is pulled from current CultureInfo
        }

        [Test]
        public void recomended_calculation()
        {
            var workingDayCultureInfo = new WorkingDayCultureInfo("pt-PT");
            var friday = new DateTime(2011, 5, 13); // A friday
            var friday_plus_two_working_days = friday.AddWorkingDays(2, workingDayCultureInfo);
            // friday + 2 working days

            Assert.IsTrue(friday_plus_two_working_days == friday.AddDays(4));
            Assert.IsTrue(friday_plus_two_working_days.DayOfWeek == DayOfWeek.Tuesday);
        }

        [Test]
        public void globally_recomended_calculation()
        {
            //Ensure we're running on portuguese context
            new CultureInfo("pt-PT").SetCurrentCultureInfo();

            var friday = new DateTime(2011, 5, 13); // A friday
            var friday_plus_two_working_days = friday.AddWorkingDays(2); // friday + 2 working days

            Assert.IsTrue(friday_plus_two_working_days == friday.AddDays(4));
            Assert.IsTrue(friday_plus_two_working_days.DayOfWeek == DayOfWeek.Tuesday);
        }

        [Test]
        public void holidays()
        {
            var ptWorkingDayCultureInfo = new WorkingDayCultureInfo("pt-PT");
            var enWorkingDayCultureInfo = new WorkingDayCultureInfo("default");

            var thursday = new DateTime(2011, 4, 21); // A thursday
            var thursday_plus_two_working_days_pt = thursday.AddWorkingDays(2, ptWorkingDayCultureInfo);
            // friday + 2 working days on PT
            var thursday_plus_two_working_days_en = thursday.AddWorkingDays(2, enWorkingDayCultureInfo);
            // friday + 2 working days on Default

            //Default doesn't have supported holidays
            Assert.IsTrue(thursday_plus_two_working_days_en == thursday.AddDays(4));
            Assert.IsTrue(thursday_plus_two_working_days_en.DayOfWeek == DayOfWeek.Monday);

            //Portuguese Holidays are supported
            Assert.IsTrue(thursday_plus_two_working_days_pt == thursday.AddDays(6));
            // + Good Friday (22-4-2011) + Carnation Revolution (25-4-2011)
            Assert.IsTrue(thursday_plus_two_working_days_pt.DayOfWeek == DayOfWeek.Wednesday);
        }

        [Test]
        public void check_working_day()
        {
            var ptWorkingDayCultureInfo = new WorkingDayCultureInfo("pt-PT");
            var carnationRevolution = new DateTime(2011, 4, 25);
            var nextDay = carnationRevolution.AddDays(1);

            Assert.IsTrue(carnationRevolution.IsWorkingDay(ptWorkingDayCultureInfo) == false);
            Assert.IsTrue(carnationRevolution.DayOfWeek == DayOfWeek.Monday);

            Assert.IsTrue(nextDay.IsWorkingDay(ptWorkingDayCultureInfo));
            Assert.IsTrue(nextDay.DayOfWeek == DayOfWeek.Tuesday);
        }

        /* Extensibility */

        [Locale("CustomTest")]
        public class CustomHolidayStrategy : IHolidayStrategy
        {
            public bool IsHoliDay(DateTime day)
            {
                if (day.Date == DateTime.Today)
                {
                    return true;
                }
                return false;
            }

            public IEnumerable<Holiday> Holidays
            {
                get { return null; }
            }

            public IEnumerable<Holiday> GetHolidaysOfYear(int year)
            {
                return null;
            }
        }

        [Locale("CustomTest")]
        public class CustomeWorkingDayOfWeekStrategy : IWorkingDayOfWeekStrategy
        {
            public bool IsWorkingDay(DayOfWeek dayOfWeek)
            {
                return true;
            }
        }

        [Test]
        public void provide_custom_strategies()
        {
            var thisAssembly = typeof(ExampleTests).GetTypeInfo().Assembly;
            var customWorkingDayCultureInfo = new WorkingDayCultureInfo("CustomTest")
            {
                LocateHolidayStrategy = (name, region) =>
                    LocaleImplementationLocator.FindImplementationOf<IHolidayStrategy>(name, region, thisAssembly) ??
                    new DefaultHolidayStrategy(),
                LocateWorkingDayOfWeekStrategy = (name, region) =>
                    LocaleImplementationLocator.FindImplementationOf<IWorkingDayOfWeekStrategy>(name, region, thisAssembly) ??
                    new DefaultWorkingDayOfWeekStrategy()
        };


            Assert.IsTrue(DateTime.Today.IsWorkingDay(customWorkingDayCultureInfo) == false);
            Assert.IsTrue(DateTime.Today.AddDays(1).IsWorkingDay(customWorkingDayCultureInfo) == true);
        }

        public class CustomWorkingDayCultureInfo : IWorkingDayCultureInfo
        {
            public bool IsHoliday(DateTime date)
            {
                return date.Date == DateTime.Today;
            }

            public bool IsWorkingDay(DateTime date)
            {
                return !this.IsHoliday(date);
            }

            public bool IsWorkingDay(DayOfWeek dayOfWeek)
            {
                switch (dayOfWeek)
                {
                    case DayOfWeek.Sunday:
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Friday:
                        return false;
                    default:
                        return true;
                }
            }

            public IEnumerable<Holiday> Holidays
            {
                get { return null; }
            }

            public IEnumerable<Holiday> GetHolidaysOfYear(int year)
            {
                return null;
            }

            public string Name
            {
                get { return "Hello World!"; }
            }
        }

        [Test]
        public void provide_custom_culture()
        {
            var customWorkingDayCultureInfo = new CustomWorkingDayCultureInfo();
            var today = DateTime.Today;
            var next_friday = today.NextDayOfWeek(DayOfWeek.Friday);

            Assert.IsTrue(today.IsWorkingDay(customWorkingDayCultureInfo) == false);
            Assert.IsTrue(today.IsHoliday(customWorkingDayCultureInfo));
            Assert.IsTrue(next_friday.IsWorkingDay(customWorkingDayCultureInfo) == false);
        }

        [Test]
        public void get_year_since_2013_holidays_in_portugal()
        {
            var portugalWorkingDayCultureInfo = new WorkingDayCultureInfo("pt-PT");
            var today = new DateTime(2013, 2, 1);
            var holidays = today.AllYearHolidays(portugalWorkingDayCultureInfo);

            Assert.IsTrue(holidays.Count == 9, "expecting 9 holidays but got {0}", holidays.Count);

            foreach (DateTime holidayDate in holidays.Keys)
            {
                var holiday = holidays[holidayDate];
                Assert.IsTrue(holidayDate.IsWorkingDay(portugalWorkingDayCultureInfo) == false,
                    "holiday {0} shouln't be working day in Portugal", holiday.Name);
            }
        }

        [Test]
        public void get_year_prior_2013_holidays_in_portugal()
        {
            var portugalWorkingDayCultureInfo = new WorkingDayCultureInfo("pt-PT");
            var today = new DateTime(2010, 2, 1);
            var holidays = today.AllYearHolidays(portugalWorkingDayCultureInfo);

            Assert.IsTrue(holidays.Count == 13, "expecting 13 holidays but got {0}", holidays.Count);

            foreach (DateTime holidayDate in holidays.Keys)
            {
                var holiday = holidays[holidayDate];
                Assert.IsTrue(holidayDate.IsWorkingDay(portugalWorkingDayCultureInfo) == false,
                    "holiday {0} shouln't be working day in Portugal", holiday.Name);
            }
        }

        [Test]
        public void get_us_holidays_in_2015_passes()
        {
            var usWorkingDayCultureInfo = new WorkingDayCultureInfo("en-US");
            var today = new DateTime(2015, 1, 1);
            var holidays = today.AllYearHolidays(usWorkingDayCultureInfo);

            Assert.IsTrue(holidays.Count == 10, "expecting 10 holidays but got {0}", holidays.Count);

            foreach (DateTime holidayDate in holidays.Keys)
            {
                var holiday = holidays[holidayDate];
                Assert.IsTrue(holidayDate.IsWorkingDay(usWorkingDayCultureInfo) == false,
                    "holiday {0} shouln't be working day in US", holiday.Name);
            }

        }

        [Test]
        public void get_next_and_last_tuesday()
        {
            var a_saturday = new DateTime(2011, 8, 20);

            var nextTuesday = a_saturday.NextDayOfWeek(DayOfWeek.Tuesday);
            var lastTuesday = a_saturday.LastDayOfWeek(DayOfWeek.Tuesday);
            Assert.IsTrue((nextTuesday.DayOfWeek == DayOfWeek.Tuesday) && (nextTuesday == new DateTime(2011, 8, 23)));
            Assert.IsTrue((lastTuesday.DayOfWeek == DayOfWeek.Tuesday) && (lastTuesday == new DateTime(2011, 8, 16)));
        }

        [Test]
        public void get_first_and_last_tuesday_of_august()
        {
            var a_saturday = new DateTime(2011, 8, 13);

            var firstTuesday = a_saturday.FirstDayOfWeekOfTheMonth(DayOfWeek.Tuesday);
            var lastTuesday = a_saturday.LastDayOfWeekOfTheMonth(DayOfWeek.Tuesday);
            Assert.IsTrue((firstTuesday.DayOfWeek == DayOfWeek.Tuesday) && (firstTuesday == new DateTime(2011, 8, 2)));
            Assert.IsTrue((lastTuesday.DayOfWeek == DayOfWeek.Tuesday) && (lastTuesday == new DateTime(2011, 8, 30)));
        }
    }
}