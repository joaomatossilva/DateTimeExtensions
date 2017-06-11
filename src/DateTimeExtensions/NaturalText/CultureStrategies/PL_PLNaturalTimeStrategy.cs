using DateTimeExtensions.Common;

namespace DateTimeExtensions.NaturalText.CultureStrategies
{
    [Locale("pl-PL")]
    public class PL_PLNaturalTimeStrategy : NaturalTimeStrategyBase
    {
        protected override string YearText
        {
            get { return "rok"; }
        }

        protected override string MonthText
        {
            get { return "miesiąc"; }
        }

        protected override string DayText
        {
            get { return "dzień"; }
        }

        protected override string HourText
        {
            get { return "godzina"; }
        }

        protected override string MinuteText
        {
            get { return "minuta"; }
        }

        protected override string SecondText
        {
            get { return "sekunda"; }
        }

        protected override string Pluralize(string text)
        {
            if (text.Equals("rok", StringComparison.OrdinalIgnoreCase))
            {
                return "lata";
            }
            if (text.Equals("miesiąc", StringComparison.OrdinalIgnoreCase))
            {
                return "miesiące";
            }
            if (text.Equals("dzień", StringComparison.OrdinalIgnoreCase))
            {
                return "dni";
            }
            if (text.EndsWith("a"))
            {
                return text.Remove(text.Length - 1) + "y";
            }
            return base.Pluralize(text);
        }
    }
}
