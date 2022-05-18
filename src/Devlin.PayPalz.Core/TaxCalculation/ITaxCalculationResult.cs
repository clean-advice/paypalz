using Devlin.PayPalz.SharedKernel;
using Devlin.PayPalz.SharedKernel.Interfaces;

namespace Devlin.PayPalz.Core.TaxCalculation
{
    public interface ITaxCalculationResult : IBaseEntity, IAggregateRoot
    {
        DateTime CalculatedAt { get; }
        PostalCode PostalCode { get; }
        AnnualIncome Salary { get; }
        TaxPayable TaxPayable { get; }

        void UpdateTaxPayable(decimal newTaxAmount);
    }
}