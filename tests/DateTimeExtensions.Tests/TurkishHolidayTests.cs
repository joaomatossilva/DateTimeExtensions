#region License

// 
// Copyright (c) 2011-2012, Onur Özten <onur301@gmail.com>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 

#endregion

using System;
using System.Linq;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class TurkishHolidayTests
    {
        [Test]
        public void can_get_strategies()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("tr-TR");
            var holidaysStrategy = dateTimeCulture.LocateHolidayStrategy(dateTimeCulture.Name, null);
            Assert.AreEqual(typeof (TurkishHolidayStrategy), holidaysStrategy.GetType());
            var workingDaysStrategy = dateTimeCulture.LocateWorkingDayOfWeekStrategy(dateTimeCulture.Name, null);
            Assert.AreEqual(typeof (TurkishWorkingDayStrategy), workingDaysStrategy.GetType());
        }

        [Test]
        public void are_working_days_on_sunday()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("tr-TR");
            Assert.IsTrue(dateTimeCulture.IsWorkingDay(DayOfWeek.Saturday));
            Assert.IsFalse(dateTimeCulture.IsWorkingDay(DayOfWeek.Sunday));
        }

        [Test]
        public void holiday_days_span()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("tr-TR");
            //Eid-al-Fitr
            DateTime day = new DateTime(2021, 5, 13);
            do
            {
                Assert.IsTrue(dateTimeCulture.IsHoliday(day), day + " should be a holiday");
                day = day.AddDays(1);
            } while (day <= new DateTime(2021, 5, 15));

            //Eid-al-Adha
            day = new DateTime(2021, 7, 20);
            do
            {
                Assert.IsTrue(dateTimeCulture.IsHoliday(day), day + " should be a holiday");
                day = day.AddDays(1);
            } while (day <= new DateTime(2021, 7, 23));

            // 23 Nisan Ulusal Egemenlik ve Çocuk Bayramı 
            day = new DateTime(2021, 4, 22);
            Assert.IsFalse(dateTimeCulture.IsHoliday(day), day + " April 22 shouldn't be a holiday");
            day = day.AddDays(1);
            Assert.IsTrue(dateTimeCulture.IsHoliday(day), day + " April 23 should be a holiday");
            day = day.AddDays(1);
            Assert.IsFalse(dateTimeCulture.IsHoliday(day), day + " April 24 shouldn't be a holiday");

            // 19 Mayıs Atatürk'ü Anma Gençlik ve Spor Bayramı 
            day = new DateTime(2021, 5, 18);
            Assert.IsFalse(dateTimeCulture.IsHoliday(day), day + " May 18 shouldn't be a holiday");
            day = day.AddDays(1);
            Assert.IsTrue(dateTimeCulture.IsHoliday(day), day + " May 19 should be a holiday");
            day = day.AddDays(1);
            Assert.IsFalse(dateTimeCulture.IsHoliday(day), day + " May 20 shouldn't be a holiday");

        }

        [Test]
        public void can_generate_holidays()
        {
            var dateTimeCulture = new WorkingDayCultureInfo("tr-TR");
            var year = 2000;
            do
            {
                var holidays = dateTimeCulture.GetHolidaysOfYear(year);
                Assert.Greater(holidays.Count(), 0);
                year++;
            } while (year < 2020);
        }
    }
}