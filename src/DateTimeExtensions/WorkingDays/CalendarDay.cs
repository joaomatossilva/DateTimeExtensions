namespace DateTimeExtensions.WorkingDays
{
    public class CalendarDay
    {
        public CalendarDay(NamedDay namedDay)
        {
            this.Day = namedDay;
        }

        public NamedDay Day { get; }

        public virtual bool IsWorkingDay => true;
    }
}