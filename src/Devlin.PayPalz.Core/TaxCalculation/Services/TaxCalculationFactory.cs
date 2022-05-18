using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Devlin.PayPalz.Domain.UnitTests")]
namespace Devlin.PayPalz.Core.TaxCalculation.Services
{
    internal static class TaxCalculationFactory
    {
        internal static ITaxCalculationServiceType Create(string code)
        {
            switch (code)
            {
                case "7441":
                case "1000":

                    return new ProgressiveCalculation(GetTaxBounds());
                case "A100":
                        return new FlatValueCalculation();
                case "7000":
                        return new FlatRateCalculation();
                default:
                    throw new ArgumentOutOfRangeException(nameof(code));
            }
        }

        private static List<ProgressiveTaxBrackets> GetTaxBounds() => new List<ProgressiveTaxBrackets>()
        {
            new ProgressiveTaxBrackets(){ BandTaxableAmount = 8350, UpperBound = 8350, TaxRate = 0.1m },
            new ProgressiveTaxBrackets(){ BandTaxableAmount = (33950 - 8350), UpperBound = 33950, TaxRate = 0.15m },
            new ProgressiveTaxBrackets(){ BandTaxableAmount = (82250 - 33950), UpperBound = 82250, TaxRate = 0.25m },
            new ProgressiveTaxBrackets(){ BandTaxableAmount = (171550 - 82250), UpperBound = 171550, TaxRate = 0.28m },
            new ProgressiveTaxBrackets(){ BandTaxableAmount = (372950 - 171550), UpperBound = 372950, TaxRate = 0.28m },
            new ProgressiveTaxBrackets(){ BandTaxableAmount = (decimal.MaxValue - 372950), UpperBound = decimal.MaxValue, TaxRate = 0.28m },
        };
    }
}
