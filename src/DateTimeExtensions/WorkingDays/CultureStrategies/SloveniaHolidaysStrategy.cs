using System;
using System.Collections.Generic;
using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("sl-SL")]
    public class SloveniaHolidaysStrategy : HolidayStrategyBase
    {
        public SloveniaHolidaysStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(PreserenDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Easter);
            this.InnerObservances.AddHoliday(ChristianHolidays.EasterMonday);
            this.InnerObservances.AddHoliday(DayOfUprisingAgainstOccupation);
            //May Day occours both in 1st May and 2nd May
            this.InnerObservances.AddHoliday(GlobalHolidays.MayDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Pentecost);
            this.InnerObservances.AddHoliday(StatehoodDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Assumption);
            this.InnerObservances.AddHoliday(ReformationDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.AllSaints);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
            this.InnerObservances.AddHoliday(IndependenceAndUnityDay);
        }

        protected override IDictionary<DateTime, Observance> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Observance> holidayMap = new Dictionary<DateTime, Observance>();
            foreach (var innerHoliday in InnerObservances)
            {
                var date = innerHoliday.CalendarDay.GetInstance(year);
                if (date.HasValue)
                {
                    holidayMap.Add(date.Value, innerHoliday);

                    //May Day occours both in 1st May and 2nd May
                    if (innerHoliday.CalendarDay.Equals(GlobalHolidays.MayDay))
                    {
                        var secondMayDay = new NamedDay(innerHoliday.CalendarDay.Name + " 2nd Day", new FixedDayResolver(5, 2));
                        var secondMayDayIntance = secondMayDay.GetInstance(year);
                        if (secondMayDayIntance != null)
                        {
                            holidayMap.Add(secondMayDayIntance.Value, new Observance(secondMayDay, true));
                        }
                    }
                }
            }
            return holidayMap;
        }

        private static NamedDay preserenDay;

        public static NamedDay PreserenDay
        {
            get { return preserenDay ?? (preserenDay = new NamedDay("Prešeren Day", new FixedDayResolver(2, 8))); }
        }

        private static NamedDay dayOfUprisingAgainstOccupation;

        public static NamedDay DayOfUprisingAgainstOccupation
        {
            get
            {
                return dayOfUprisingAgainstOccupation ??
                       (dayOfUprisingAgainstOccupation = new NamedDay("Day of Uprising Against Occupation", new FixedDayResolver(4, 27)));
            }
        }

        private static NamedDay statehoodDay;

        public static NamedDay StatehoodDay
        {
            get { return statehoodDay ?? (statehoodDay = new NamedDay("Statehood Day", new FixedDayResolver(6, 25))); }
        }

        private static NamedDay reformationDay;

        public static NamedDay ReformationDay
        {
            get { return reformationDay ?? (reformationDay = new NamedDay("Reformation Day", new FixedDayResolver(10, 31))); }
        }

        private static NamedDay independenceAndUnityDay;

        public static NamedDay IndependenceAndUnityDay
        {
            get
            {
                return independenceAndUnityDay ??
                       (independenceAndUnityDay = new NamedDay("Independence and Unity Day", new FixedDayResolver(12, 26)));
            }
        }
    }
}
