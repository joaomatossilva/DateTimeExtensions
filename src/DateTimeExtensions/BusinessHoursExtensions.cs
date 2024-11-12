using System;

namespace DateTimeExtensions
{
    public static class BusinessHoursExtensions
    {
        /// <summary>
        /// This method helps determine if a given time is during standard working hours.
        /// </summary>
        /// <param name="startTime">Start time of the business hours.</param>
        /// <param name="endTime">End time of the business hours.</param>
        /// <returns>If given time is during business hours, method returns true else it returns false.</returns>
        public static bool IsWithinBusinessHours(this DateTime dateTime, TimeSpan startTime, TimeSpan endTime)
        {
            var currentTime = dateTime.TimeOfDay;
            //if startTime is less than endTime (ex:Business hours from 9AM to 5PM)
            if (startTime <= endTime)
            {
                return currentTime >= startTime && currentTime <= endTime;
            }
            //if startTime is greater than endTime (ex:Business hours from 9PM to 5AM)
            else
            {
                return currentTime >= startTime || currentTime <= endTime;
            }
        }
    }
}
