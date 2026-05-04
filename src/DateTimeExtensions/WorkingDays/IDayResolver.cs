using System;

public interface IDayResolver
{
    /// <summary>
    /// Gets the date of the day for a given year
    /// </summary>
    /// <param name="year">The year to get the date for</param>
    /// <returns>The date of the day for the given year</returns>
    DateTime? GetInstance(int year);

    /// <summary>
    /// Determines if the given date is an instance of the day
    /// </summary>
    /// <param name="date">The date to check</param>
    /// <returns>true if the given date is an instance of the day, false otherwise</returns>
    bool IsInstanceOf(DateTime date);
}