using System;

namespace DateTimeExtensions.WorkingDays
{
    public interface ICalculateDayStrategy
    {
        DateTime? GetInstance(int year);
        bool IsInstanceOf(DateTime date);
    }
}