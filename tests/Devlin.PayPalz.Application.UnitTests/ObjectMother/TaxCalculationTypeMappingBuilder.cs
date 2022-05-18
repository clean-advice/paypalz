using Devlin.PayPalz.Core.TaxCalculation;

namespace Devlin.PayPalz.Application.UnitTests.ObjectMother
{
    internal class TaxCalculationTypeMappingBuilder
    {
        private int id = 1;

        private PostalCode postalCode = new PostalCode("A100");

        private TaxCalculationType calculationType = TaxCalculationType.FromValue(0);

        public TaxCalculationTypeMappingBuilder WithId(int id)
        {
            this.id = id;
            return this;
        }

        public TaxCalculationTypeMappingBuilder WithPostalCode(string postalCode)
        {
            this.postalCode = new PostalCode(postalCode);
            return this;
        }

        public TaxCalculationTypeMappingBuilder WithCalculationType(string calculationType)
        {
            this.calculationType = TaxCalculationType.FromName(calculationType);
            return this;
        }

        public TaxCalculationTypeMapping Build()
        {
            TaxCalculationTypeMapping calculationTypeMapping = new TaxCalculationTypeMapping(postalCode, calculationType);
            calculationTypeMapping.Id = id;

            return calculationTypeMapping;
        }

        public TaxCalculationTypeMapping BuildWithDefaultValues()
        {
            return new TaxCalculationTypeMappingBuilder().Build();
        }
    }
}
