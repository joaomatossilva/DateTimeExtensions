using DateTimeExtensions.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeExtensions.WorkingDays.CultureStrategies.PortugeseRegionalHolidayStrategies
{
    [Locale("PT-pt", PortugueseRegionIdentifiers.Lisbon)]
    public class LisbonHolidayStrategy : PT_PTHolidayStrategy
    {
        public LisbonHolidayStrategy(): base()
        {
            this.InnerHolidays.Add(StAntonioDay);
        }

        private static Holiday stAntonioDay;

        public static Holiday StAntonioDay
        {
            get
            {
                if (stAntonioDay == null)
                {
                    stAntonioDay = new FixedHoliday("Portugal_StAntonioDay", 6, 13);
                }
                return stAntonioDay;
            }
        }
    }
}
