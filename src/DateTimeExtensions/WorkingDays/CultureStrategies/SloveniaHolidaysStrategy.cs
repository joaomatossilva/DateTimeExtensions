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
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(PreserenDay);
            this.InnerHolidays.Add(ChristianHolidays.Easter);
            this.InnerHolidays.Add(ChristianHolidays.EasterMonday);
            this.InnerHolidays.Add(DayOfUprisingAgainstOccupation);
            //May Day occours both in 1st May and 2nd May
            this.InnerHolidays.Add(GlobalHolidays.MayDay);
            this.InnerHolidays.Add(ChristianHolidays.Pentecost);
            this.InnerHolidays.Add(StatehoodDay);
            this.InnerHolidays.Add(ChristianHolidays.Assumption);
            this.InnerHolidays.Add(ReformationDay);
            this.InnerHolidays.Add(ChristianHolidays.AllSaints);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(IndependenceAndUnityDay);
        }

        protected override IDictionary<DateTime, NamedDay> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, NamedDay> holidayMap = new Dictionary<DateTime, NamedDay>();
            foreach (var innerHoliday in InnerHolidays)
            {
                var date = innerHoliday.GetInstance(year);
                if (date.HasValue)
                {
                    holidayMap.Add(date.Value, innerHoliday);

                    //May Day occours both in 1st May and 2nd May
                    if (innerHoliday.Equals(GlobalHolidays.MayDay))
                    {
                        var secondMayDay = new NamedDay(innerHoliday.Name + " 2nd Day", new FixedDayResolver(5, 2));
                        var secondMayDayIntance = secondMayDay.GetInstance(year);
                        if (secondMayDayIntance != null)
                        {
                            holidayMap.Add(secondMayDayIntance.Value, secondMayDay);
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