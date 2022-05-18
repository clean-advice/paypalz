using Devlin.PayPalz.SharedKernel;
using Devlin.PayPalz.SharedKernel.Interfaces;

namespace Devlin.PayPalz.Core.TaxCalculation
{
    public class TaxCalculationTypeMapping : BaseEntity, IAggregateRoot
    {
        public PostalCode PostalCode { get; private set; }

        public TaxCalculationType TaxCalculationType { get; private set; }

        private TaxCalculationTypeMapping()
        {
            // required by EF
        }

        public TaxCalculationTypeMapping(
            PostalCode postalCode,
            TaxCalculationType taxCalculationType)
        {
            PostalCode = postalCode;
            TaxCalculationType = taxCalculationType;
        }
    }
}
