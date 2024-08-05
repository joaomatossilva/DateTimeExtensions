using System;

namespace DateTimeExtensions
{
    public static class DateTimeExtensions
    {
        public static bool IsWithinBusinessHours(this DateTime dateTime, TimeSpan startTime, TimeSpan endTime)
        {
            var timeOfDay = dateTime.TimeOfDay;
            return timeOfDay >= startTime && timeOfDay <= endTime;
        }
    }
}
