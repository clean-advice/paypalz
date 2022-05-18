namespace Devlin.PayPalz.Core.TaxCalculation.Services
{
    internal class ProgressiveTaxBrackets
    {
        public decimal UpperBound { get; set; }

        public decimal BandTaxableAmount { get; set; }

        public decimal TaxRate { get; set; }
    }
}
