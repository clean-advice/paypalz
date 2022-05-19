namespace Devlin.PayPalz.Application.TaxCalculations.Commands
{
    public interface ITaxCalculationCommand
    {
        Task<TaxCalculationResultDto> CalculateTax(
            string postalCode,
            decimal annualSalary,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}