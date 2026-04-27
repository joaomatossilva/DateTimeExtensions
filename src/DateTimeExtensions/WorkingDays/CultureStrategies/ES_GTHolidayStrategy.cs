using DateTimeExtensions.Common;

namespace DateTimeExtensions.WorkingDays.CultureStrategies
{
    [Locale("es-GT")]
    public class ES_GTHolidayStrategy : HolidayStrategyBase, IHolidayStrategy
    {
        public ES_GTHolidayStrategy()
        {
            this.InnerHolidays.Add(GlobalHolidays.NewYear);
            this.InnerHolidays.Add(ChristianHolidays.MaundyThursday); // Jueves Santo
            this.InnerHolidays.Add(ChristianHolidays.GoodFriday); // Viernes Santo
            this.InnerHolidays.Add(ChristianHolidays.EasterSaturday); // Sábado de Gloria
            this.InnerHolidays.Add(GlobalHolidays.InternationalWorkersDay); // Día del Trabajo
            this.InnerHolidays.Add(MothersDay);
            this.InnerHolidays.Add(ChristianHolidays.Assumption); // Feriado Ciudad Capital Guatemala
            this.InnerHolidays.Add(ChristianHolidays.DayOfTheDead);
            this.InnerHolidays.Add(ChristianHolidays.Christmas);
            this.InnerHolidays.Add(ChristianHolidays.ChristmasEve);
            this.InnerHolidays.Add(GlobalHolidays.NewYearsEve);
            this.InnerHolidays.Add(IndependenceDay); // Día de la Independencia
            this.InnerHolidays.Add(RevolutionDay); // Día de la Revolución
            this.InnerHolidays.Add(ArmyDay); // Día del Ejército
            this.InnerHolidays.Add(AllSaintsDay); // Día de Todos los Santos
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