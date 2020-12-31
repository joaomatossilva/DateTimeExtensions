#region License

//
// Copyright (c) 2011-2012, João Matos Silva <kappy@acydburne.com.pt>
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

using DateTimeExtensions.WorkingDays;
using NUnit.Framework;
using System;
using System.Linq;

namespace DateTimeExtensions.Tests
{
    using WorkingDays.CultureStrategies;

    [TestFixture]
    public class EsCoHolidaysTests
    {
        [Test]
        public void Holidays_ColombianCulture_Counts20PerYear()
        {
            var strategy = new ES_COHolidayStrategy();
            //var strategy2 = new ES_ARHolidayStrategy();
            var workingDayCultureInfo = new WorkingDayCultureInfo("es-CO");

            var holidays = workingDayCultureInfo.ObservedDays;

            Assert.AreEqual(20, holidays.Count());
        }

        [Test]
        public void IsHoliday_FixedDateColombianHoliday_ReturnsTrue()
        {
            var workingDayCultureInfo = new WorkingDayCultureInfo("es-CO");

            var newYear = new DateTime(2018, 1, 1);
            Assert.IsTrue(newYear.IsHoliday(workingDayCultureInfo));

            var laboursDay = new DateTime(2018, 5, 1);
            Assert.IsTrue(laboursDay.IsHoliday(workingDayCultureInfo));

            var independenceDay = new DateTime(2018, 7, 20);
            Assert.IsTrue(independenceDay.IsHoliday(workingDayCultureInfo));

            var boyacaBattle = new DateTime(2018, 8, 7);
            Assert.IsTrue(boyacaBattle.IsHoliday(workingDayCultureInfo));

            var immaculateConception = new DateTime(2018, 12, 8);
            Assert.IsTrue(immaculateConception.IsHoliday(workingDayCultureInfo));

            var christmas = new DateTime(2018, 12, 25);
            Assert.IsTrue(christmas.IsHoliday(workingDayCultureInfo));
        }

        [Test]
        public void IsHoliday_NextMondayColombianHoliday_ReturnsTrue()
        {
            var workingDayCultureInfo = new WorkingDayCultureInfo("es-CO");

            var epiphany = new DateTime(2018, 1, 8);
            Assert.IsTrue(epiphany.IsHoliday(workingDayCultureInfo));

            var saintJoseph = new DateTime(2018, 3, 19);
            Assert.IsTrue(saintJoseph.IsHoliday(workingDayCultureInfo));

            var saintPeterAndSaintPaul = new DateTime(2018, 7, 2);
            Assert.IsTrue(saintPeterAndSaintPaul.IsHoliday(workingDayCultureInfo));

            var virginAssumption = new DateTime(2018, 8, 20);
            Assert.IsTrue(virginAssumption.IsHoliday(workingDayCultureInfo));

            var raceDay = new DateTime(2018, 10, 15);
            Assert.IsTrue(raceDay.IsHoliday(workingDayCultureInfo));

            var allSaintsDay = new DateTime(2018, 11, 5);
            Assert.IsTrue(allSaintsDay.IsHoliday(workingDayCultureInfo));

            var independenceOfCartagena = new DateTime(2018, 11, 12);
            Assert.IsTrue(independenceOfCartagena.IsHoliday(workingDayCultureInfo));
        }

        [Test]
        public void IsHoliday_EasterColombianHoliday_ReturnsTrue()
        {
            var workingDayCultureInfo = new WorkingDayCultureInfo("es-CO");

            var palmSunday = new DateTime(2018, 3, 25);
            Assert.IsTrue(palmSunday.IsHoliday(workingDayCultureInfo));

            var maundyThursday = new DateTime(2018, 3, 29);
            Assert.IsTrue(maundyThursday.IsHoliday(workingDayCultureInfo));

            var goodFriday = new DateTime(2018, 3, 30);
            Assert.IsTrue(goodFriday.IsHoliday(workingDayCultureInfo));

            var easter = new DateTime(2018, 4, 1);
            Assert.IsTrue(easter.IsHoliday(workingDayCultureInfo));

            var ascension = new DateTime(2018, 5, 14);
            Assert.IsTrue(ascension.IsHoliday(workingDayCultureInfo));

            var corpusChristi = new DateTime(2018, 6, 4);
            Assert.IsTrue(corpusChristi.IsHoliday(workingDayCultureInfo));

            var sacredHeart = new DateTime(2018, 6, 11);
            Assert.IsTrue(sacredHeart.IsHoliday(workingDayCultureInfo));
        }

        [Test]
        public void IsHoliday_TwoHolidaysFallsInTheSameDay_ReturnsTrue()
        {
            var workingDayCultureInfo = new WorkingDayCultureInfo("es-CO");

            var sacredHeart = new DateTime(2019, 7, 1);
            Assert.IsTrue(sacredHeart.IsHoliday(workingDayCultureInfo));

            var saintPeterAndSaintPaul = new DateTime(2019, 7, 1);
            Assert.IsTrue(saintPeterAndSaintPaul.IsHoliday(workingDayCultureInfo));
        }
    }
}
