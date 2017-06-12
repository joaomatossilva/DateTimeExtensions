using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        protected override string Pluralize(string text, int value)
        {
            List<int> lastDigitsWithDifferentDeclination = new List<int> { 2, 3, 4 };
            List<int> exceptions = new List<int> { 12, 13, 14 };

            bool hasDifferentDeclination = lastDigitsWithDifferentDeclination.Contains((int)(value % 10)) && !exceptions.Contains((int)(value % 100));

            if (text.Equals("rok", StringComparison.OrdinalIgnoreCase))
            {
                if(hasDifferentDeclination)
                {
                    return "lata";
                }
                return "lat";
            }
            if (text.Equals("miesiąc", StringComparison.OrdinalIgnoreCase))
            {
                if (hasDifferentDeclination)
                {
                    return "miesiące";
                }
                return "miesięcy";
            }
            if (text.Equals("dzień", StringComparison.OrdinalIgnoreCase))
            {
                return "dni";
            }
            
            if(text.EndsWith("a"))
            {
                if(hasDifferentDeclination)
                {
                    return text.Remove(text.Length - 1) + "y";
                }
                return text.Remove(text.Length - 1);
            }
            return base.Pluralize(text, value);
        }
    }
}
