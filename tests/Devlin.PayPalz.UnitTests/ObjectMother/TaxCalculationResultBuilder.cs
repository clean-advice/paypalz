using Devlin.PayPalz.Core.TaxCalculation;

namespace Devlin.PayPalz.Domain.UnitTests.ObjectMother
{
    internal class TaxCalculationResultBuilder
    {
        private DateTime calculatedAt = new DateTime(2022, 5, 14, 8, 16, 53);

        private PostalCode postalCode = new PostalCode("A100");

        private AnnualIncome salary = new AnnualIncome(10000);

        private TaxPayable taxPayable = new TaxPayable(500);

        public TaxCalculationResultBuilder WithCalulatedAt(DateTime calculatedAt)
        {
            this.calculatedAt = calculatedAt;
            return this;
        }

        public TaxCalculationResultBuilder WithPostalCode(string postalCode)
        {
            this.postalCode = new PostalCode(postalCode);
            return this;
        }

        public TaxCalculationResultBuilder Withsalary(decimal salary)
        {
            this.salary = new AnnualIncome(salary);
            return this;
        }

        public TaxCalculationResultBuilder WithTaxAmount(decimal taxAmount)
        {
            this.taxPayable = new TaxPayable(taxAmount);
            return this;
        }

        public TaxCalculationResult Build()
        {
            return new TaxCalculationResult(calculatedAt, postalCode, salary);
        }

        public TaxCalculationResult BuildWithDefaultValues()
        {
            return new TaxCalculationResultBuilder().Build();
        }
    }
}
