namespace Devlin.PayPalz.Core.TaxCalculation.Services
{
    public interface ITaxCalculationService
    {
        TaxCalculationResult CalculateTax(PostalCode postalCode, AnnualIncome annualIncome);
    }
}