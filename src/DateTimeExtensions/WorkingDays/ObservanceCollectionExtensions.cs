using System;
using System.Collections.Generic;

namespace DateTimeExtensions.WorkingDays;

public static class ObservanceCollectionExtensions
{
    public static void AddHoliday(this IList<Observance> observances, NamedDay calendarDay)
    {
        ArgumentNullException.ThrowIfNull(observances);
        ArgumentNullException.ThrowIfNull(calendarDay);
        observances.Add(new Observance(calendarDay, true));
    }

    public static void AddObservance(this IList<Observance> observances, NamedDay calendarDay)
    {
        ArgumentNullException.ThrowIfNull(observances);
        ArgumentNullException.ThrowIfNull(calendarDay);
        observances.Add(new Observance(calendarDay, false));
    }
}
