using System;

namespace DateTimeExtensions.WorkingDays.OccurrencesCalculators
{
    public class NamedDayStrategy : ICalculateDayStrategy
    {
        private readonly NamedDay day;

        public NamedDayStrategy(NamedDay day) => this.day = day ?? throw new ArgumentNullException(nameof(day));

        public DateTime? GetInstance(int year) => day.GetInstance(year);

        public bool IsInstanceOf(DateTime date) => day.IsInstanceOf(date);
    }
}