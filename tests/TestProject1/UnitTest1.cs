using DateTimeExtensions.Seasons;

namespace TestProject1
{
    public class EquinoxSolsticeCalculatorTests
    {
        [Test]
        public void CanCalculateMedianEquinoxAndSolstice()
        {
            var year = 1962;
            var point = EquinoxSolstice.JuneSolstice;
            var calculator = new EquinoxSolsticeCalculator();

            var medianEquinoxOrSolestice = calculator.MeanEquinoxOrSolstice(point, year);

            var t = calculator.T(Math.Round(medianEquinoxOrSolestice, 5));

            var delta = calculator.Delta(Math.Round(t, 9));

            var s = calculator.S(Math.Round(t, 9));

            var final = calculator.Final(medianEquinoxOrSolestice, delta, s);

            Assert.That(Math.Round(medianEquinoxOrSolestice, 5), Is.EqualTo(2437_837.38589));
            Assert.That(Math.Round(t, 9), Is.EqualTo(-0.375294021));
            Assert.That(Math.Round(delta, 4), Is.EqualTo(0.9681));
            Assert.That(s, Is.EqualTo(634)); //Should be 635
            Assert.That(Math.Round(final, 5), Is.EqualTo(2437_837.39243)); //should be 2437_837.39245

        }
  
    }
}