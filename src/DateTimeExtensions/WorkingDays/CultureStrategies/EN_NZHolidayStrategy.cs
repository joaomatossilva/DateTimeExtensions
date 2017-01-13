using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-NZ")]
    public class EN_NZHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        // Rules / Dates sourced from
        //		http://www.dol.govt.nz/er/holidaysandleave/publicholidays/publicholidaydates/future-dates.asp
        //		http://www.whatdate.co.nz/

        public EN_NZHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(DayAfterNewYear);
            this.InnerHolidays.Add(WaitangiDay);
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday);
            this.InnerHolidays.Add(ChristianHolidays.Easter);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(AnzacDay);
            this.InnerHolidays.Add(QueensBirthday);
            this.InnerHolidays.Add(LabourDay);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(GlobalHolidays.BoxingDay);
        }

        protected override IDictionary<DateTime, Holiday> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Holiday> holidayMap = new Dictionary<DateTime, Holiday>();
            foreach (var innerHoliday in InnerHolidays)
            {
                var date = innerHoliday.GetInstance(year);
                if (date.HasValue)
                {
                    holidayMap.Add(date.Value, innerHoliday);

                    // New Year, Day After New Year, Christmas and Boxing Days are 'Mondayised'
                    // ie if these dates fall on a weekday then they are observed on the actual day.
                    // If they fall on a weekend then they are observed on the following Monday/Tuesday

                    if (IsMondayised(innerHoliday, date.Value.DayOfWeek))
                    {
                        var observation = new NthDayOfWeekAfterDayHoliday(innerHoliday.Name + " Observed", 1,
                            DayOfWeek.Monday, innerHoliday);
                        var observedIntance = observation.GetInstance(year);
                        if (observedIntance != null)
                        {
                            holidayMap.Add(observedIntance.Value, observation);
                        }
                    }
                    if (IsTuesdayised(innerHoliday, date.Value.DayOfWeek))
                    {
                        var observation = new NthDayOfWeekAfterDayHoliday(innerHoliday.Name + " Observed", 1,
                            DayOfWeek.Tuesday, innerHoliday);
                        var observedIntance = observation.GetInstance(year);
                        if (observedIntance != null)
                        {
                            holidayMap.Add(observedIntance.Value, observation);
                        }
                    }
                }
            }
            return holidayMap;
        }


        private static bool IsMondayised(Holiday holiday, DayOfWeek occurenceDay)
        {
            return
                (holiday.Equals(GlobalHolidays.NewYear) && occurenceDay == DayOfWeek.Saturday) ||
                (holiday.Equals(DayAfterNewYear) && occurenceDay == DayOfWeek.Saturday) ||
                (holiday.Equals(ChristianHolidays.Christmas) && occurenceDay == DayOfWeek.Saturday) ||
                (holiday.Equals(GlobalHolidays.BoxingDay) && occurenceDay == DayOfWeek.Saturday);
        }

        private static bool IsTuesdayised(Holiday holiday, DayOfWeek occurenceDay)
        {
            return
                (holiday.Equals(GlobalHolidays.NewYear) && occurenceDay == DayOfWeek.Sunday) ||
                (holiday.Equals(DayAfterNewYear) && occurenceDay == DayOfWeek.Sunday) ||
                (holiday.Equals(ChristianHolidays.Christmas) && occurenceDay == DayOfWeek.Sunday) ||
                (holiday.Equals(GlobalHolidays.BoxingDay) && occurenceDay == DayOfWeek.Sunday);
        }


        // 2nd Janurary - Day after New Year's Day
        private static Holiday dayAfterNewYear;

        public static Holiday DayAfterNewYear
        {
            get
            {
                if (dayAfterNewYear == null)
                {
                    dayAfterNewYear = new FixedHoliday("Day after New Year's Day", 1, 2);
                }
                return dayAfterNewYear;
            }
        }

        // 6th Feburary - Waitangi Day
        private static Holiday waitangiDay;

        public static Holiday WaitangiDay
        {
            get
            {
                if (waitangiDay == null)
                {
                    waitangiDay = new FixedHoliday("Waitangi Day", 2, 6);
                }
                return waitangiDay;
            }
        }

        // 25th April - Anzac Day
        private static Holiday anzacDay;

        public static Holiday AnzacDay
        {
            get
            {
                if (anzacDay == null)
                {
                    anzacDay = new FixedHoliday("Anzac Day", 4, 25);
                }
                return anzacDay;
            }
        }

        // 1st Monday in June - Queen's Birthday
        private static Holiday queensBirthday;

        public static Holiday QueensBirthday
        {
            get
            {
                if (queensBirthday == null)
                {
                    queensBirthday = new NthDayOfWeekInMonthHoliday("Queen's Birthday", 1, DayOfWeek.Monday, 6,
                        CountDirection.FromFirst);
                }
                return queensBirthday;
            }
        }

        // 4th Monday in October - Labour Day
        private static Holiday labourDay;

        public static Holiday LabourDay
        {
            get
            {
                if (labourDay == null)
                {
                    labourDay = new NthDayOfWeekInMonthHoliday("Labour Day", 4, DayOfWeek.Monday, 10,
                        CountDirection.FromFirst);
                }
                return labourDay;
            }
        }

        // Todo: Regional Holidays
    }
}