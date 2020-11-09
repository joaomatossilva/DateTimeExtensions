namespace DateTimeExtensions.WorkingDays
{
    public class Holiday : CalendarDay
    {
        public Holiday(NamedDay namedDay)
            : base(namedDay)
        {
        }

        public override bool IsWorkingDay => false;
    }
}