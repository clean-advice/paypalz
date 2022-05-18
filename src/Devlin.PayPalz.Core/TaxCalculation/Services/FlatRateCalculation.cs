namespace Devlin.PayPalz.Core.TaxCalculation.Services
{
    internal class FlatRateCalculation : ITaxCalculationServiceType
    {
        // This should come from configuration
        private const decimal flatRateTaxPercentage = 0.175m;

        public decimal CalculateTax(decimal annualIncome)
        {
            if (annualIncome == 0)
            {
                return 0;
            }

            decimal tax = annualIncome * flatRateTaxPercentage;
            return tax;
        }
    }
}
