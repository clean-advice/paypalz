namespace Devlin.PayPalz.Core.TaxCalculation.Services
{
    internal interface ITaxCalculationServiceType
    {
        decimal CalculateTax(decimal annualIncome);
    }
}
