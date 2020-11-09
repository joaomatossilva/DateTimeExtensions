namespace DateTimeExtensions.WorkingDays
{
    using System;

    public class NamedDayInitializer
    {
        private readonly Lazy<NamedDay> factory;
        
        public NamedDayInitializer(Func<NamedDay> initializer)
        {
            this.factory = new Lazy<NamedDay>(initializer);
        }

        public NamedDay Value => this.factory.Value ?? 
                                 throw new InvalidOperationException("Could not initialize instance");

        public static implicit operator NamedDay(NamedDayInitializer initializer) => initializer.Value;

        public static bool operator ==(NamedDayInitializer initializer, NamedDay namedDay) =>
            initializer?.Value == namedDay;
        
        public static bool operator ==(NamedDay namedDay, NamedDayInitializer initializer) =>
            initializer?.Value == namedDay;
        
        public static bool operator !=(NamedDayInitializer initializer, NamedDay namedDay) =>
            initializer?.Value != namedDay;
        
        public static bool operator !=(NamedDay namedDay, NamedDayInitializer initializer) =>
            initializer?.Value != namedDay;
    }
}