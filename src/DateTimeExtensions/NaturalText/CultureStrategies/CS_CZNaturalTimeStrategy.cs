using DateTimeExtensions.Common;
using System;

namespace DateTimeExtensions.NaturalText.CultureStrategies
{
    [Locale("cs-CZ")]
    public class CS_CZNaturalTimeStrategy : NaturalTimeStrategyBase
    {
        protected override string YearText
        {
            get { return "rok"; }
        }

        protected override string MonthText
        {
            get { return "měsíc"; }
        }

        protected override string DayText
        {
            get { return "den"; }
        }

        protected override string HourText
        {
            get { return "hodina"; }
        }

        protected override string MinuteText
        {
            get { return "minuta"; }
        }

        protected override string SecondText
        {
            get { return "vteřina"; }
        }

        protected override string Pluralize(string text, int value)
        {
            if (text.Equals("rok", StringComparison.OrdinalIgnoreCase))
            {
                if (value < 5)
                {
                    return "roky";
                }
                return "let";
            }
            if (text.Equals("měsíc", StringComparison.OrdinalIgnoreCase))
            {
                if (value < 5)
                {
                    return "měsíce";
                }
                return "měsíců";
            }
            if (text.Equals("den", StringComparison.OrdinalIgnoreCase))
            {
                if (value < 5)
                {
                    return "dny";
                }
                return "dnů";
            }
            if (text.Equals("hodina", StringComparison.OrdinalIgnoreCase))
            {
                if (value < 5)
                {
                    return "hodiny";
                }
                return "hodin";
            }
            if (text.Equals("minuta", StringComparison.OrdinalIgnoreCase))
            {
                if (value < 5)
                {
                    return "minuty";
                }
                return "minut";
            }
            if (text.Equals("vteřina", StringComparison.OrdinalIgnoreCase))
            {
                if (value < 5)
                {
                    return "vteřiny";
                }
                return "vteřin";
            }
            return text;
        }
    }
}
