using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DateTimeExtensions;
using NUnit.Framework;
using DateTimeExtensions.Strategies;
using NSubstitute;

namespace DateTimeExtensions.Tests {
	[TestFixture]
	public class GenericWorkingDayCultureInfoTests {

		[Test]
		public void can_locate_default_strategies() {
			string name = "foo";
			DateTimeCultureInfo workingdayCultureInfo = new DateTimeCultureInfo(name);
			Assert.IsTrue(name == workingdayCultureInfo.Name);
			Assert.IsInstanceOf<DefaultHolidayStrategy>(workingdayCultureInfo.LocateHolidayStrategy(name));
			Assert.IsInstanceOf<DefaultWorkingDayOfWeekStrategy>(workingdayCultureInfo.LocateWorkingDayOfWeekStrategy(name));
		}

		[Test]
		public void can_provide_custom_locator_holiday_dayOfWeek_strategy() {
			var mockHolidayStrategy = Substitute.For<IHolidayStrategy>();
			mockHolidayStrategy.IsHoliDay(Arg.Any<DateTime>()).Returns(true);
			var mockDayOfWeekStartegy = Substitute.For<IWorkingDayOfWeekStrategy>();
			mockDayOfWeekStartegy.IsWorkingDay(Arg.Any<DayOfWeek>()).Returns(true);

			DateTimeCultureInfo workingdayCultureInfo = new DateTimeCultureInfo() {
				LocateHolidayStrategy = (n) => {
					return mockHolidayStrategy;
				},
				LocateWorkingDayOfWeekStrategy = (n) => {
					return mockDayOfWeekStartegy;
				}
			};

			DateTime marchFirst = new DateTime(1991, 3, 1);
			Assert.IsTrue(marchFirst.IsHoliday(workingdayCultureInfo));
			Assert.IsFalse(marchFirst.IsWorkingDay(workingdayCultureInfo));
			mockHolidayStrategy.Received().IsHoliDay(marchFirst);
			mockDayOfWeekStartegy.Received().IsWorkingDay(marchFirst.DayOfWeek);
		}

		[Test]
		public void can_provide_custom_locator_dayOfWeek_strategy() {
			var mockDayOfWeekStartegy = Substitute.For<IWorkingDayOfWeekStrategy>();
			mockDayOfWeekStartegy.IsWorkingDay(Arg.Any<DayOfWeek>()).Returns(false);			

			DateTimeCultureInfo workingdayCultureInfo = new DateTimeCultureInfo() {
				LocateWorkingDayOfWeekStrategy = (n) => {
					return mockDayOfWeekStartegy;
				}
			};

			DateTime aThursday = new DateTime(2011, 5, 12);
			Assert.IsFalse(aThursday.IsWorkingDay(workingdayCultureInfo));
			Assert.IsFalse(aThursday.IsHoliday(workingdayCultureInfo));
			mockDayOfWeekStartegy.Received().IsWorkingDay(aThursday.DayOfWeek);
		}

		[Test]
		public void picks_a_holiday_when_two_holidays_occur_on_the_same_date() {
			/* In 2005, Ascension day was on the fifth of May. That year, the fifth of may was
			 * also a national public holiday (liberation day).	The holiday picker should not
			 * fail, but it is arbritrary which one of the holidays it should return, so either
			 * one is OK. HolidayStrategyBase.BuildObservancesMap should survive this.
			 */

			var inTheNetherlands = new DateTimeCultureInfo("nl-NL");
			var fifthOfMay = new DateTime(2005, 5, 5);

			Assert.That(fifthOfMay.IsHoliday(inTheNetherlands));

		}
	}
}
