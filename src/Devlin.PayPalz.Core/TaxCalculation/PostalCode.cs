using Ardalis.GuardClauses;
using Devlin.PayPalz.SharedKernel;

namespace Devlin.PayPalz.Core.TaxCalculation
{
    public class PostalCode : ValueObject
    {
        public string Code { get; private set; }

        private PostalCode()
        {
            // required by EF
        }
        public PostalCode(string code)
        {
            Code = Guard.Against.InvalidPostalCode(code, nameof(code));
        }
    }
}
