using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-NZ")]
    public class EN_NZHolidayStrategy : HolidayStrategyBase, IObservancesStrategy
    {
        // Rules / Dates sourced from
        //		https://www.employment.govt.nz/leave-and-holidays/public-holidays/public-holidays-and-anniversary-dates/
        //		http://www.whatdate.co.nz/

        public EN_NZHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(DayAfterNewYear);
            this.InnerObservances.AddHoliday(WaitangiDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.GoodFriday);
            this.InnerObservances.AddHoliday(ChristianHolidays.Easter);
            this.InnerObservances.AddHoliday(ChristianHolidays.EasterMonday);
            this.InnerObservances.AddHoliday(AnzacDay);
            this.InnerObservances.AddHoliday(QueensBirthday);
            this.InnerObservances.AddHoliday(KingsBirthday);
            this.InnerObservances.AddHoliday(Matariki);
            this.InnerObservances.AddHoliday(LabourDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
            this.InnerObservances.AddHoliday(GlobalHolidays.BoxingDay);
        }

        protected override IDictionary<DateTime, Observance> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Observance> holidayMap = new Dictionary<DateTime, Observance>();
            foreach (var innerHoliday in InnerObservances)
            {
                var date = innerHoliday.CalendarDay.GetInstance(year);
                if (date.HasValue)
                {
                    // If the holiday already exists in the map, combine the two holidays.
                    // This is apparent for Easter Monday/Anzac Day on 25 April 2011.
                    if (holidayMap.TryGetValue(date.Value, out var existingHoliday))
                    {
                        var combinedHoliday = new NamedDay($"{existingHoliday.CalendarDay.Name}/{innerHoliday.CalendarDay.Name}", new FixedDayResolver(date.Value.Month, date.Value.Day));
                        holidayMap[date.Value] = new Observance(combinedHoliday, true);
                    }
                    else
                    {
                        holidayMap.Add(date.Value, innerHoliday);
                    }

                    // New Year, Day After New Year, Christmas and Boxing Days are 'Mondayised'
                    // ie if these dates fall on a weekday then they are observed on the actual day.
                    // If they fall on a weekend then they are observed on the following Monday/Tuesday

                    if (IsMondayised(innerHoliday.CalendarDay, date.Value.DayOfWeek))
                    {
                        var observation = new NamedDay(
                            innerHoliday.CalendarDay.Name + " Observed",
                            new NthDayOfWeekAfterDayResolver(1, DayOfWeek.Monday, innerHoliday.CalendarDay.Resolver));
                        var observedIntance = observation.GetInstance(year);
                        if (observedIntance != null)
                        {
                            holidayMap.Add(observedIntance.Value, new Observance(observation, true));
                        }
                    }
                    if (IsTuesdayised(innerHoliday.CalendarDay, date.Value.DayOfWeek))
                    {
                        var observation = new NamedDay(
                            innerHoliday.CalendarDay.Name + " Observed",
                            new NthDayOfWeekAfterDayResolver(1, DayOfWeek.Tuesday, innerHoliday.CalendarDay.Resolver));
                        var observedIntance = observation.GetInstance(year);
                        if (observedIntance != null)
                        {
                            holidayMap.Add(observedIntance.Value, new Observance(observation, true));
                        }
                    }
                }
            }
            return holidayMap;
        }


        private static bool IsMondayised(NamedDay holiday, DayOfWeek occurenceDay)
        {
            return
                (holiday.Equals(GlobalHolidays.NewYear) && occurenceDay == DayOfWeek.Saturday) ||
                (holiday.Equals(DayAfterNewYear) && occurenceDay == DayOfWeek.Saturday) ||
                (holiday.Equals(ChristianHolidays.Christmas) && occurenceDay == DayOfWeek.Saturday) ||
                (holiday.Equals(GlobalHolidays.BoxingDay) && occurenceDay == DayOfWeek.Saturday);
        }

        private static bool IsTuesdayised(NamedDay holiday, DayOfWeek occurenceDay)
        {
            return
                (holiday.Equals(GlobalHolidays.NewYear) && occurenceDay == DayOfWeek.Sunday) ||
                (holiday.Equals(DayAfterNewYear) && occurenceDay == DayOfWeek.Sunday) ||
                (holiday.Equals(ChristianHolidays.Christmas) && occurenceDay == DayOfWeek.Sunday) ||
                (holiday.Equals(GlobalHolidays.BoxingDay) && occurenceDay == DayOfWeek.Sunday);
        }


        // 2nd Janurary - Day after New Year's Day
        private static NamedDay dayAfterNewYear;

        public static NamedDay DayAfterNewYear
        {
            get
            {
                if (dayAfterNewYear == null)
                {
                    dayAfterNewYear = new NamedDay("Day after New Year's Day", new FixedDayResolver(1, 2));
                }
                return dayAfterNewYear;
            }
        }

        // 6th Feburary - Waitangi Day
        private static NamedDay waitangiDay;

        public static NamedDay WaitangiDay
        {
            get
            {
                if (waitangiDay == null)
                {
                    waitangiDay = new NamedDay("Waitangi Day", new FixedDayResolver(2, 6));
                }
                return waitangiDay;
            }
        }

        // 25th April - Anzac Day
        private static NamedDay anzacDay;

        public static NamedDay AnzacDay
        {
            get
            {
                if (anzacDay == null)
                {
                    anzacDay = new NamedDay("Anzac Day", new FixedDayResolver(4, 25));
                }
                return anzacDay;
            }
        }

        // 1st Monday in June (2022 and earlier) - Queen's Birthday
        private static NamedDay queensBirthday;

        public static NamedDay QueensBirthday
        {
            get
            {
                if (queensBirthday == null)
                {
                    queensBirthday = new NamedDay(
                        "Queen's Birthday",
                        new YearDependantDayResolver(
                            year => year <= 2022,
                            new NthDayOfWeekInMonthDayResolver(1, DayOfWeek.Monday, 6, CountDirection.FromFirst)));
                }
                return queensBirthday;
            }
        }

        // 1st Monday in June (2023 and later) - King's Birthday
        private static NamedDay kingsBirthday;

        public static NamedDay KingsBirthday
        {
            get
            {
                if (kingsBirthday == null)
                {
                    kingsBirthday = new NamedDay(
                        "King's Birthday",
                        new YearDependantDayResolver(
                            year => year >= 2023,
                            new NthDayOfWeekInMonthDayResolver(1, DayOfWeek.Monday, 6, CountDirection.FromFirst)));
                }
                return kingsBirthday;
            }
        }

        // Some Friday on June or July - Matariki
        private static NamedDay matariki;
        private static NamedDay Matariki
        {
            get
            {
                if (matariki == null)
                {
                    // Matariki doesn't have a readily-available algorithm and its dates have been calulated up to
                    // 2052 by the Matariki Advisory Committee.
                    // See https://www.mbie.govt.nz/assets/matariki-dates-2022-to-2052-matariki-advisory-group.pdf

                    var knownMatarikiOccurences = new Dictionary<int, DayInYear>
                    {
                        {2022, new DayInYear(6, 24)},
                        {2023, new DayInYear(7, 14)},
                        {2024, new DayInYear(6, 28)},
                        {2025, new DayInYear(6, 20)},
                        {2026, new DayInYear(7, 10)},
                        {2027, new DayInYear(6, 25)},
                        {2028, new DayInYear(7, 14)},
                        {2029, new DayInYear(7, 6)},
                        {2030, new DayInYear(6, 21)},
                        {2031, new DayInYear(7, 11)},
                        {2032, new DayInYear(7, 2)},
                        {2033, new DayInYear(6, 24)},
                        {2034, new DayInYear(7, 7)},
                        {2035, new DayInYear(6, 29)}
                    };

                    matariki = new YearMapNamedDay("Matariki", knownMatarikiOccurences);
                }
                return matariki;
            }
        }

        // 4th Monday in October - Labour Day
        private static NamedDay labourDay;

        public static NamedDay LabourDay
        {
            get
            {
                if (labourDay == null)
                {
                    labourDay = new NamedDay("Labour Day", new NthDayOfWeekInMonthDayResolver(4, DayOfWeek.Monday, 10, CountDirection.FromFirst));
                }
                return labourDay;
            }
        }

        // Todo: Regional Holidays
    }
}
