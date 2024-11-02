using DateTimeExtensions.Common;

namespace DateTimeExtensions.NaturalText.CultureStrategies
{
    [Locale("uk-UA")]
    public class UK_UANaturalTimeStrategy : NaturalTimeStrategyBase
    {
        protected override string YearText
        {
            get { return "рік"; }
        }

        protected override string MonthText
        {
            get { return "місяць"; }
        }

        protected override string DayText
        {
            get { return "день"; }
        }

        protected override string HourText
        {
            get { return "година"; }
        }

        protected override string MinuteText
        {
            get { return "хвилина"; }
        }

        protected override string SecondText
        {
            get { return "секунда"; }
        }

        protected override string Pluralize(string text, int value)
        {
            if (text.EndsWith("рік"))
            {
                return "роки";
            }

            if (text.EndsWith("день"))
            {
                return "дні";
            }

            if (text.EndsWith("ь"))
            {
                return text.Substring(0, text.Length - 1) + "і";
            }

            if (text.EndsWith("а"))
            {
                return text.Substring(0, text.Length - 1) + "и";
            }

            return text;
        }
    }
}