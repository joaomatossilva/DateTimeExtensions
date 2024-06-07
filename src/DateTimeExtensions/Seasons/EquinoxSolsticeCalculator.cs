using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

[assembly: InternalsVisibleTo("TestProject1")]

namespace DateTimeExtensions.Seasons
{
    public class EquinoxSolsticeCalculator
    {
        public DateTime Calculate(EquinoxSolstice point, int year)
        {
            return DateTime.Now;
        }

        //Based on table 27 (A and B)
        internal double MeanEquinoxOrSolstice(EquinoxSolstice point, int year)
        {
            double y;
            if(year < -1000 || year > 3000)
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Year must be between -1000 and 3000");
            }

            if(year <= 1000)
            {
                y = year / 1000.0;

                if(point == EquinoxSolstice.MarchEquinox)
                {
                    return 1721_139.29189 + 365_242.13740 * y + 0.06134 * Math.Pow(y, 2) + 0.00111 * Math.Pow(y, 3) + 0.00071 * Math.Pow(y, 4);
                }
                else if(point == EquinoxSolstice.JuneSolstice)
                {
                    return 1721_233.25401 + 365_241.7256 * y + 0.05323 * Math.Pow(y, 2) + 0.00907 * Math.Pow(y, 3) + 0.00025 * Math.Pow(y, 4);
                }
                else if(point == EquinoxSolstice.SeptemberEquinox)
                {
                    return 1721_325.70455 + 365_242.49558 * y + 0.11677 * Math.Pow(y, 2) + 0.00297 * Math.Pow(y, 3) + 0.00074 * Math.Pow(y, 4);
                }
                else
                {
                    return 1721_414.39987 + 365_242.88257 * y + 0.00769 * Math.Pow(y, 2) + 0.00769 * Math.Pow(y, 3) + 0.00006 * Math.Pow(y, 4);
                }

            }
            else
            {
                y = (year - 2000) / 1000.0;

                if (point == EquinoxSolstice.MarchEquinox)
                {
                    return 2451_623.80984 + 365_242.37404 * y + 0.05169 * Math.Pow(y, 2) + 0.00411 * Math.Pow(y, 3) + 0.00057 * Math.Pow(y, 4);
                }
                else if (point == EquinoxSolstice.JuneSolstice)
                {
                    return 2451_716.56767 + 365_241.62603 * y + 0.00325 * Math.Pow(y, 2) + 0.00888 * Math.Pow(y, 3) + 0.00030 * Math.Pow(y, 4);
                }
                else if (point == EquinoxSolstice.SeptemberEquinox)
                {
                    return 2451_810.21715 + 365_242.01767 * y + 0.11575 * Math.Pow(y, 2) + 0.00337 * Math.Pow(y, 3) + 0.00078 * Math.Pow(y, 4);
                }
                else
                {
                    return 2451_900.05952 + 365_242.74049 * y + 0.06223 * Math.Pow(y, 2) + 0.00823 * Math.Pow(y, 3) + 0.00032 * Math.Pow(y, 4);
                }
            }
        }

        internal double T(double jde0)
        {
            return (jde0 - 2451545.0) / 36525;
        }

        internal double Delta(double t)
        {
            var w = ToRadians(35999.373) * t - ToRadians(2.47);
            return 1 + 0.0334 * Math.Cos(w) + 0.0007 * Math.Cos(2 * w);
        }

        internal double S(double t)
        {
            double Calculate((int, double, double) term, double innerT)
            {
                var positions = 3;

                var angle = Math.Round(ToRadians(term.Item2), positions) + Math.Round(ToRadians(term.Item3), positions) * t;
                var cos = Math.Cos(angle);
                var termS = term.Item1 * Math.Round(cos, 2);
                return termS;
            }

            
            var rads = PeriodicTerms()
                .Select(term => Calculate(term, t))
                .Sum();

            //var degs = ToDegrees(rads);

            return Math.Round(rads);
        }

        internal static double ToRadians(double val)
        {
            return (Math.PI / 180) * val;
        }

        internal static double ToDegrees(double val)
        {
            return (180 / Math.PI) * val;
        }

        internal double Final(double mean, double delta, double s)
        {
            return mean + 0.00001 * s / delta;
        }

        public double EquinoxOrSolstice(EquinoxSolstice point, int year)
        {
            var mean = MeanEquinoxOrSolstice(point, year);
            
            var t = T(mean);
            var delta = Delta(t);

            var s = S(t);

            return Final(mean, delta, s);
        }

        internal IEnumerable<(int, double, double)> PeriodicTerms()
        {
            yield return (485, 324.96, 1934.136);
            yield return (203, 337.23, 32964.467);
            yield return (199, 342.08, 20.186);
            yield return (182, 27.85, 445267.112);
            yield return (156, 73.14, 45036.886);
            yield return (136, 171.52, 22518.443);
            yield return (77, 222.54, 65928.934);
            yield return (74, 296.72, 3034.906);
            yield return (70, 243.58, 9037.513);
            yield return (58, 119.81, 33718.147);
            yield return (52, 297.17, 150.678);
            yield return (50, 21.02, 2281.226);

            yield return (45, 247.54, 29929.562);
            yield return (44, 325.15, 31555.956);
            yield return (29, 60.93, 4443.417);
            yield return (18, 155.12, 67555.328);
            yield return (17, 228.79, 4562.452);
            yield return (16, 198.04, 62894.029);
            yield return (14, 199.76, 31436.921);
            yield return (12, 95.39, 14577.848);
            yield return (12, 287.11, 31931.756);
            yield return (12, 320.81, 34777.259);
            yield return (9, 227.73, 1222.114);
            yield return (8, 15.45, 16859.074);
        }
    }
}
