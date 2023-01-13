using DateTimeExtensions.NaturalText;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;

namespace DateTimeExtensions.xTests
{
    public class UnitTest1
    {
        private NaturalTextCultureInfo ro_ci = new NaturalTextCultureInfo("ro-RO");
        private WorkingDayCultureInfo dateTimeCulture = new WorkingDayCultureInfo("ro-RO");

        private DateTime fromTime = new DateTime(2016, 6, 21, 10, 28, 0);
        
        
        [Fact]
        public void Test1()
        {
            //var toTime = fromTime.AddHours(2).AddMinutes(45);

            //var naturalText = fromTime.ToNaturalText(toTime, false, ro_ci);

            //Assert.NotNull(naturalText);
            //Assert.NotEmpty(naturalText);
            //Assert.Equal("2 ore", naturalText);

            var toTime = fromTime.AddSeconds(6).AddMinutes(5).AddHours(4).AddDays(3).AddMonths(2).AddYears(2);

            var naturalText = fromTime.ToExactNaturalText(toTime, ro_ci);

            Assert.NotNull(naturalText);
            Assert.NotEmpty(naturalText);
            Assert.Equal("2 ani, 2 luni, 3 zile, 4 ore, 5 minute, 6 secunde", naturalText);
        }

        [Fact]
        public void Test2()
        {
            var holidaysStrategy = dateTimeCulture.LocateHolidayStrategy(dateTimeCulture.Name, null);

            Assert.Equal(typeof(RomanianHolidayStrategy), holidaysStrategy.GetType());
            var workingDaysStrategy = dateTimeCulture.LocateWorkingDayOfWeekStrategy(dateTimeCulture.Name, null);
            Assert.Equal(typeof(DefaultWorkingDayOfWeekStrategy), workingDaysStrategy.GetType());
        }

        [Fact]
        public void Test3()
        {
            var holiday = RomanianHolidayStrategy.ChildrensDay;
            var day = new DateTime(2022, 6, 1);
            TestHoliday(holiday, day);
        }

        private void TestHoliday(Holiday holiday, DateTime dateOnGregorian)
        {
            var holidayInstance = holiday.GetInstance(dateOnGregorian.Year);
            Assert.True(holidayInstance.HasValue);
            Assert.Equal(dateOnGregorian, holidayInstance.Value);
            Assert.True(holiday.IsInstanceOf(dateOnGregorian));
        }
    }
}