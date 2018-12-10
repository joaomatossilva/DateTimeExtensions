using DateTimeExtensions.WorkingDays;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class ThreadSafeTests
    {
        [Test]
        public void AddWorkingDays_MultipleThreads_CanCalculate()
        {
            //Arrange
            var culture = new WorkingDayCultureInfo("en-US");
            var startDate = new DateTime(2018,5,1);

            //Act
            Parallel.ForEach(Enumerable.Range(1,10), (i) => startDate.AddWorkingDays(i, culture));
        }
    }
}
