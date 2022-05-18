using Ardalis.GuardClauses;
using Devlin.PayPalz.SharedKernel;

namespace Devlin.PayPalz.Core.TaxCalculation
{
    public class TaxPayable : ValueObject
    {
        public decimal Amount { get; private set; }

        private TaxPayable()
        {
            // required by EF
        }

        public TaxPayable(decimal taxableAmount)
        {
            Amount = Guard.Against.Negative(taxableAmount, nameof(taxableAmount));
        }
    }
}
