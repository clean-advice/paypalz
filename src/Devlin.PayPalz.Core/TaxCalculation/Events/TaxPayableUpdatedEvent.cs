using Devlin.PayPalz.SharedKernel;

namespace Devlin.PayPalz.Core.TaxCalculation.Events
{
    public class TaxPayableUpdatedEvent : BaseDomainEvent
    {
        public TaxCalculationResult TaxCalculationResult { get; set; }

        public TaxPayableUpdatedEvent(TaxCalculationResult taxCalculationResult)
        {
            TaxCalculationResult = taxCalculationResult;
        }
    }
}
