using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions;
using NUnit.Framework;
using System.Globalization;
using DateTimeExtensions.Strategies;
using NUnit.Mocks;

namespace DateTimeExtensions.Tests {
	[TestFixture]
	public class GenericWorkingDayCultureInfoTests {

		DynamicMock dynamicMockHoliday;
		DynamicMock dynamicMockDayOfWeek;

		[SetUp]
		public void Init() {
			dynamicMockHoliday = new NUnit.Mocks.DynamicMock(typeof(IHolidayStrategy));
			dynamicMockDayOfWeek = new NUnit.Mocks.DynamicMock(typeof(IWorkingDayOfWeekStrategy));

		}

		[Test]
		public void can_locate_default_strategies() {
			string name = "foo";
			WorkingDayCultureInfo workingdayCultureInfo = new WorkingDayCultureInfo(name);
			Assert.IsTrue(name == workingdayCultureInfo.Name);
			Assert.IsInstanceOf<DefaultHolidayStrategy>(workingdayCultureInfo.LocateHolidayStrategy(name));
			Assert.IsInstanceOf<DefaultWorkingDayOfWeekStrategy>(workingdayCultureInfo.LocateWorkingDayOfWeekStrategy(name));
		}

		[Test]
		public void can_provide_custom_locator_holiday_dayOfWeek_strategy() {
			dynamicMockHoliday.ExpectAndReturn("IsHoliDay", true, new object[] { new DateTime(1991, 3, 1) });
			dynamicMockDayOfWeek.ExpectAndReturn("IsWorkingDay", true, new object[] { DayOfWeek.Friday });
			dynamicMockDayOfWeek.ExpectAndReturn("IsWorkingDay", true, new object[] { DayOfWeek.Friday });

			WorkingDayCultureInfo workingdayCultureInfo = new WorkingDayCultureInfo() {
				LocateHolidayStrategy = (n) => {
					return (IHolidayStrategy)dynamicMockHoliday.MockInstance;
				},
				LocateWorkingDayOfWeekStrategy = (n) => {
					return (IWorkingDayOfWeekStrategy)dynamicMockDayOfWeek.MockInstance;
				}
			};

			DateTime marchFirst = new DateTime(1991, 3, 1);
			Assert.IsFalse(marchFirst.IsWorkingDay(workingdayCultureInfo));
		}

		[Test]
		public void can_provide_custom_locator_dayOfWeek_strategy() {
			dynamicMockDayOfWeek.ExpectAndReturn("IsWorkingDay", false, new object[] { DayOfWeek.Thursday });

			WorkingDayCultureInfo workingdayCultureInfo = new WorkingDayCultureInfo() {
				LocateWorkingDayOfWeekStrategy = (n) => {
					return (IWorkingDayOfWeekStrategy)dynamicMockDayOfWeek.MockInstance;
				}
			};

			DateTime aThursday = new DateTime(2011, 5, 12);
			Assert.IsFalse(aThursday.IsWorkingDay(workingdayCultureInfo));
		}

	}
}
