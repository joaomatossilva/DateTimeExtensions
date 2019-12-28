using DateTimeExtensions.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeExtensions.NaturalText.CultureStrategies
{
    [Locale("sl-SI")]
    public class SL_SINaturalTimeStrategy : NaturalTimeStrategyBase
    {
        protected override string YearText
        {
            get { return "leto"; }
        }

        protected override string MonthText
        {
            get { return "mesec"; }
        }

        protected override string DayText
        {
            get { return "dan"; }
        }

        protected override string HourText
        {
            get { return "ura"; }
        }

        protected override string MinuteText
        {
            get { return "minuta"; }
        }

        protected override string SecondText
        {
            get { return "sekunda"; }
        }

        protected override string Pluralize(string text, int value)
        {
            if (text.Equals("leto", StringComparison.OrdinalIgnoreCase))
            {
                if (value == 2)
                {
                    return "leti";
                }
                else if (value == 3)
                {
                    return "leta";
                }
                return "let";
            }
            if (text.Equals("mesec", StringComparison.OrdinalIgnoreCase))
            {
                if (value == 2)
                {
                    return "mesca";
                }
                else if (value == 3)
                {
                    return "mesci";
                }
                return "mescev";
            }
            if (text.Equals("dan", StringComparison.OrdinalIgnoreCase))
            {
                return "dni";
            }
            if (text.Equals("ura", StringComparison.OrdinalIgnoreCase))
            {
                if (value == 2)
                {
                    return "uri";
                }
                else if (value == 3)
                {
                    return "ure";
                }
                return "ur";
            }
            if (text.Equals("minuta", StringComparison.OrdinalIgnoreCase))
            {
                if (value == 2)
                {
                    return "minuti";
                }
                else if (value == 3)
                {
                    return "minute";
                }
                return "minut";
            }
            if (text.Equals("sekunda", StringComparison.OrdinalIgnoreCase))
            {
                if (value == 2)
                {
                    return "sekundi";
                }
                else if (value == 3)
                {
                    return "sekunde";
                }
                return "sekund";
            }

            return text;
        }
    }
}
