namespace Devlin.PayPalz.Core.TaxCalculation.Services
{
    internal class FlatValueCalculation : ITaxCalculationServiceType
    {
        // This should come from configuration
        private const decimal lowIncomeBound = 200000m;
        private const decimal lowIncomeTaxPercentage = 0.05m;
        private const decimal defaultFlatTaxAmount = 10000m;

        public decimal CalculateTax(decimal annualIncome)
        {
            if (annualIncome == 0)
            {
                return 0;
            }

            if (annualIncome < lowIncomeBound)
            {
                return annualIncome * lowIncomeTaxPercentage;
            }

            decimal tax = defaultFlatTaxAmount;
            return tax;
        }
    }
}
