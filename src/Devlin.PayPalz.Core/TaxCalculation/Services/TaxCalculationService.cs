namespace Devlin.PayPalz.Core.TaxCalculation.Services
{
    public class TaxCalculationService : ITaxCalculationService
    {
        public TaxCalculationResult CalculateTax(PostalCode postalCode, AnnualIncome annualIncome)
        {
            ITaxCalculationServiceType calculationService = TaxCalculationFactory.Create(postalCode.Code);
            decimal taxAmount = calculationService.CalculateTax(annualIncome.TaxableAmount);
            TaxCalculationResult taxCalculationResult = new TaxCalculationResult(DateTime.UtcNow, postalCode, annualIncome);
            taxCalculationResult.UpdateTaxPayable(taxAmount);

            return taxCalculationResult;
        }
    }
}
