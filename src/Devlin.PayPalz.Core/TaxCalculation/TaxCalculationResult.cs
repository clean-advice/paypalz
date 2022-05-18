using Ardalis.GuardClauses;
using Devlin.PayPalz.Core.TaxCalculation.Events;
using Devlin.PayPalz.SharedKernel;
using Devlin.PayPalz.SharedKernel.Interfaces;

namespace Devlin.PayPalz.Core.TaxCalculation
{
    public class TaxCalculationResult : BaseEntity, IAggregateRoot
    {
        public DateTime CalculatedAt { get; private set; }

        public PostalCode? PostalCode { get; private set; }

        public AnnualIncome? AnnualIncome { get; private set; }

        public TaxPayable? TaxPayable { get; private set; }

        private TaxCalculationResult()
        {
            // required by EF
        }

        public TaxCalculationResult(
            DateTime calculatedAt,
            PostalCode postalCode,
            AnnualIncome annualIncome)
        {
            CalculatedAt = Guard.Against.OutOfSQLDateRange(calculatedAt, nameof(calculatedAt));
            PostalCode = postalCode;
            AnnualIncome = annualIncome;
            TaxPayable = new TaxPayable(0);
        }

        public void UpdateTaxPayable(decimal newTaxAmount)
        {
            Guard.Against.InvalidTaxAmount(newTaxAmount, AnnualIncome.TaxableAmount, nameof(newTaxAmount));
            this.TaxPayable = new TaxPayable(newTaxAmount);

            var taxPayableUpdatedEvent = new TaxPayableUpdatedEvent(this);
            Events.Add(taxPayableUpdatedEvent);
        }
    }
}
