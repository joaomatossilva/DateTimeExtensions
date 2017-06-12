using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions;
using NUnit.Framework;
using System.Globalization;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class PTWorkingDayCultureInfoTests
    {
        [Test]
        public void can_locate_by_name()
        {
            string name = "pt-PT";
            WorkingDayCultureInfo workingdayCultureInfo = new WorkingDayCultureInfo(name);
            Assert.IsTrue(name == workingdayCultureInfo.Name);
            Assert.IsInstanceOf<PT_PTHolidayStrategy>(workingdayCultureInfo.LocateHolidayStrategy(name, null));
        }

        [Test]
        public void can_locate_by_culture_info()
        {
            string name = "pt-PT";
            new CultureInfo(name).SetCurrentCultureInfo();
            WorkingDayCultureInfo workingdayCultureInfo = new WorkingDayCultureInfo();
            Assert.IsTrue(name == workingdayCultureInfo.Name);
            Assert.IsInstanceOf<PT_PTHolidayStrategy>(workingdayCultureInfo.LocateHolidayStrategy(name, null));
        }
    }
}