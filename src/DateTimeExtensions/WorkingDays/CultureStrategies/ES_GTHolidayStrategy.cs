using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("es-GT")]
    public class ES_GTHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public ES_GTHolidayStrategy()
        {
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYear);
            this.InnerObservances.AddHoliday(ChristianHolidays.MaundyThursday); // Jueves Santo
            this.InnerObservances.AddHoliday(ChristianHolidays.GoodFriday); // Viernes Santo
            this.InnerObservances.AddHoliday(ChristianHolidays.EasterSaturday); // Sábado de Gloria
            this.InnerObservances.AddHoliday(GlobalHolidays.InternationalWorkersDay); // Día del Trabajo
            this.InnerObservances.AddHoliday(MothersDay);
            this.InnerObservances.AddHoliday(ChristianHolidays.Assumption); // Feriado Ciudad Capital Guatemala
            this.InnerObservances.AddHoliday(ChristianHolidays.DayOfTheDead);
            this.InnerObservances.AddHoliday(ChristianHolidays.Christmas);
            this.InnerObservances.AddHoliday(ChristianHolidays.ChristmasEve);
            this.InnerObservances.AddHoliday(GlobalHolidays.NewYearsEve);
            this.InnerObservances.AddHoliday(IndependenceDay); // Día de la Independencia
            this.InnerObservances.AddHoliday(RevolutionDay); // Día de la Revolución
            this.InnerObservances.AddHoliday(ArmyDay); // Día del Ejército
            this.InnerObservances.AddHoliday(AllSaintsDay); // Día de Todos los Santos
        }

        private static NamedDay _mothersDay;

        private static NamedDay _independenceDay;

        private static NamedDay _revolutionDay;

        private static NamedDay _armyDay;

        private static NamedDay _allSaintsDay;

        public static NamedDay MothersDay
        {
            get
            {
                if (_mothersDay == null)
                {
                    _mothersDay = new NamedDay("Día de la Madre", new FixedDayResolver(5, 10));
                }

                return _mothersDay;
            }
        }

        public static NamedDay IndependenceDay
        {
            get
            {
                if (_independenceDay == null)
                {
                    _independenceDay = new NamedDay("Día de la Independencia", new FixedDayResolver(9, 15));
                }

                return _independenceDay;
            }
        }

        public static NamedDay RevolutionDay
        {
            get
            {
                if (_revolutionDay == null)
                {
                    _revolutionDay = new NamedDay("Día de la Revolución", new FixedDayResolver(10, 20));
                }

                return _revolutionDay;
            }
        }

        public static NamedDay ArmyDay
        {
            get
            {
                if (_armyDay == null)
                {
                    _armyDay = new NamedDay("Día del Ejercito", new FixedDayResolver(6, 30));
                }

                return _armyDay;
            }
        }

        public static NamedDay AllSaintsDay
        {
            get
            {
                if (_allSaintsDay == null)
                {
                    _allSaintsDay = new NamedDay("Día de Todos los Santos", new FixedDayResolver(11, 1));
                }

                return _allSaintsDay;
            }
        }
    }
}
