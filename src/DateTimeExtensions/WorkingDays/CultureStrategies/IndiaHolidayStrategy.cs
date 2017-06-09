using DateTimeExtensions.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("en-IN")]
    public class IndiaHolidayStrategy : HolidayStrategyBase
    {
        private static readonly Calendar IndianCalendar = new GregorianCalendar(GregorianCalendarTypes.Localized);

        public IndiaHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(GlobalHolidays.MayDay);
            this.InnerHolidays.Add(IndependenceDay);
            this.InnerHolidays.Add(RepublicDay);
            this.InnerHolidays.Add(GandhiBirthAnniversary);

        }
        private static Holiday independenceDay;
        public static Holiday IndependenceDay
        {
            get
            {
                if (independenceDay == null)
                {
                    independenceDay = new FixedHoliday("Independence Day", 8, 15, IndianCalendar);
                }
                return independenceDay;
            }
        }


        private static Holiday republicDay;
        public static Holiday RepublicDay
        {
            get
            {
                if (republicDay == null)
                {
                    republicDay = new FixedHoliday("Republic Day", 1, 26, IndianCalendar);
                }
                return republicDay;
            }
        }


        private static Holiday gandhiBirthAnniversary;
        public static Holiday GandhiBirthAnniversary
        {
            get
            {
                if (gandhiBirthAnniversary == null)
                {
                    gandhiBirthAnniversary = new FixedHoliday("Gandhi's Birth Anniversary", 10, 2, IndianCalendar);
                }
                return gandhiBirthAnniversary;
            }
        }
    }
}
