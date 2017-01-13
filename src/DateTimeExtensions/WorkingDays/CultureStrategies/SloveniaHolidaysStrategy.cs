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

        protected override IDictionary<DateTime, Holiday> BuildObservancesMap(int year)
        {
            IDictionary<DateTime, Holiday> holidayMap = new Dictionary<DateTime, Holiday>();
            foreach (var innerHoliday in InnerHolidays)
            {
                var date = innerHoliday.GetInstance(year);
                if (date.HasValue)
                {
                    holidayMap.Add(date.Value, innerHoliday);

                    //May Day occours both in 1st May and 2nd May
                    if (innerHoliday.Equals(GlobalHolidays.MayDay))
                    {
                        var secondMayDay = new FixedHoliday(innerHoliday.Name + " 2nd Day", 5, 2);
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

        private static Holiday preserenDay;

        public static Holiday PreserenDay
        {
            get { return preserenDay ?? (preserenDay = new FixedHoliday("Prešeren Day", 2, 8)); }
        }

        private static Holiday dayOfUprisingAgainstOccupation;

        public static Holiday DayOfUprisingAgainstOccupation
        {
            get
            {
                return dayOfUprisingAgainstOccupation ??
                       (dayOfUprisingAgainstOccupation = new FixedHoliday("Day of Uprising Against Occupation", 4, 27));
            }
        }

        private static Holiday statehoodDay;

        public static Holiday StatehoodDay
        {
            get { return statehoodDay ?? (statehoodDay = new FixedHoliday("Statehood Day", 6, 25)); }
        }

        private static Holiday reformationDay;

        public static Holiday ReformationDay
        {
            get { return reformationDay ?? (reformationDay = new FixedHoliday("Reformation Day", 10, 31)); }
        }

        private static Holiday independenceAndUnityDay;

        public static Holiday IndependenceAndUnityDay
        {
            get
            {
                return independenceAndUnityDay ??
                       (independenceAndUnityDay = new FixedHoliday("Independence and Unity Day", 12, 26));
            }
        }
    }
}