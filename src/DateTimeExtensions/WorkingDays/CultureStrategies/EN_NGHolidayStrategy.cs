using System;
using System.Collections.Generic;

namespace DateTimeExtensions.Common
{
    // Base class for holidays
    public class Holiday
    {
        public string Name { get; }
        public DateTime Date { get; }

        public Holiday(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }
    }

    // Class for fixed holidays
    public class FixedHoliday : Holiday
    {
        public FixedHoliday(string name, int month, int day) 
            : base(name, new DateTime(DateTime.Now.Year, month, day))
        {
        }
    }

    // Class for relative holidays
    public class RelativeHoliday : Holiday
    {
        public RelativeHoliday(string name, Holiday referenceHoliday, int offset) 
            : base(name, referenceHoliday.Date.AddDays(offset))
        {
        }
    }

    // Class for Islamic holidays
    public class IslamicHoliday : Holiday
    {
        public IslamicHoliday(string name) : base(name, CalculateIslamicHolidayDate(name)) { }

        private static DateTime CalculateIslamicHolidayDate(string name)
        {
            // Placeholder for actual date calculation logic
            return DateTime.Now; // Use appropriate logic to determine the date
        }
    }

    public static class GlobalHolidays
    {
        public static Holiday EasterSunday { get; } = new FixedHoliday("Easter Sunday", 4, 9);
        public static Holiday NewYear { get; } = new FixedHoliday("New Year's Day", 1, 1);
    }

    public abstract class HolidayStrategyBase
    {
        protected List<Holiday> InnerHolidays { get; } = new List<Holiday>();
    }

    public interface IHolidayStrategy
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class LocaleAttribute : Attribute
    {
        public LocaleAttribute(string locale) { }
    }
}

namespace DateTimeExtensions.WorkingDays.CultureStrategies.NigerianHolidays
{
    using DateTimeExtensions.Common;

    [Locale("en-NG")]
    public class EN_NGHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public EN_NGHolidayStrategy()
        {
            // Adding holidays to the inner holidays list
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(IndependenceDay);
            this.InnerHolidays.Add(DemocracyDay);
            this.InnerHolidays.Add(WorkersDay);
            this.InnerHolidays.Add(ChristmasDay);
            this.InnerHolidays.Add(BoxingDay);
            this.InnerHolidays.Add(GoodFriday);
            this.InnerHolidays.Add(EasterMonday);
            this.InnerHolidays.Add(Maulid);
            this.InnerHolidays.Add(EidAlFitr);
            this.InnerHolidays.Add(EidAlAdha);
        }

        private static readonly Holiday independenceDay = new FixedHoliday("Independence Day", 10, 1);
        public static Holiday IndependenceDay => independenceDay;

        private static readonly Holiday democracyDay = new FixedHoliday("Democracy Day", 6, 12);
        public static Holiday DemocracyDay => democracyDay;

        private static readonly Holiday workersDay = new FixedHoliday("Workers' Day", 5, 1);
        public static Holiday WorkersDay => workersDay;

        private static readonly Holiday christmasDay = new FixedHoliday("Christmas Day", 12, 25);
        public static Holiday ChristmasDay => christmasDay;

        private static readonly Holiday boxingDay = new FixedHoliday("Boxing Day", 12, 26);
        public static Holiday BoxingDay => boxingDay;

        private static readonly Holiday goodFriday = new RelativeHoliday("Good Friday", GlobalHolidays.EasterSunday, -2);
        public static Holiday GoodFriday => goodFriday;

        private static readonly Holiday easterMonday = new RelativeHoliday("Easter Monday", GlobalHolidays.EasterSunday, 1);
        public static Holiday EasterMonday => easterMonday;

        private static readonly Holiday eidAlFitr = new IslamicHoliday("Eid al-Fitr");
        public static Holiday EidAlFitr => eidAlFitr;

        private static readonly Holiday eidAlAdha = new IslamicHoliday("Eid al-Adha");
        public static Holiday EidAlAdha => eidAlAdha;

        private static readonly Holiday maulid = new IslamicHoliday("Maulid an-Nabi");
        public static Holiday Maulid => maulid;
    }
}

namespace HolidayProgram
{
    using DateTimeExtensions.Common;
    using DateTimeExtensions.WorkingDays.CultureStrategies.NigerianHolidays;

    public class Program
    {
        public static void Main(string[] args)
        {
            var holidayStrategy = new EN_NGHolidayStrategy();

            Console.WriteLine("Nigerian Holidays:");
            Console.WriteLine($"1. {EN_NGHolidayStrategy.IndependenceDay.Name} - {EN_NGHolidayStrategy.IndependenceDay.Date.ToShortDateString()}");
            Console.WriteLine($"2. {EN_NGHolidayStrategy.DemocracyDay.Name} - {EN_NGHolidayStrategy.DemocracyDay.Date.ToShortDateString()}");
            Console.WriteLine($"3. {EN_NGHolidayStrategy.WorkersDay.Name} - {EN_NGHolidayStrategy.WorkersDay.Date.ToShortDateString()}");
            Console.WriteLine($"4. {EN_NGHolidayStrategy.ChristmasDay.Name} - {EN_NGHolidayStrategy.ChristmasDay.Date.ToShortDateString()}");
            Console.WriteLine($"5. {EN_NGHolidayStrategy.BoxingDay.Name} - {EN_NGHolidayStrategy.BoxingDay.Date.ToShortDateString()}");
            Console.WriteLine($"6. {EN_NGHolidayStrategy.GoodFriday.Name} - {EN_NGHolidayStrategy.GoodFriday.Date.ToShortDateString()}");
            Console.WriteLine($"7. {EN_NGHolidayStrategy.EasterMonday.Name} - {EN_NGHolidayStrategy.EasterMonday.Date.ToShortDateString()}");
            Console.WriteLine($"8. {EN_NGHolidayStrategy.EidAlFitr.Name} - {EN_NGHolidayStrategy.EidAlFitr.Date.ToShortDateString()}");
            Console.WriteLine($"9. {EN_NGHolidayStrategy.EidAlAdha.Name} - {EN_NGHolidayStrategy.EidAlAdha.Date.ToShortDateString()}");
            Console.WriteLine($"10. {EN_NGHolidayStrategy.Maulid.Name} - {EN_NGHolidayStrategy.Maulid.Date.ToShortDateString()}");

            Console.ReadLine();
        }
    }
}
