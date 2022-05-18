using Ardalis.GuardClauses;
using Devlin.PayPalz.SharedKernel;

namespace Devlin.PayPalz.Core.TaxCalculation
{
    public class AnnualIncome : ValueObject
    {
        public decimal TaxableAmount { get; private set; }

        private AnnualIncome()
        {
            // required by EF
        }

        public AnnualIncome(decimal taxableAmount)
        {
            TaxableAmount = Guard.Against.Negative(taxableAmount, nameof(taxableAmount));
        }
    }
}
