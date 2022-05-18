using Devlin.PayPalz.Core.TaxCalculation;
using Devlin.PayPalz.Domain.UnitTests.ObjectMother;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace Devlin.PayPalz.Domain.UnitTests.CoreTests.TaxCalculation
{
    [TestFixture]
    public class TaxCalculationResultTests
    {
        [Test]
        public void TaxCalculationResult_CanBeInitialized_WithValidDefaultValues()
        {
            var expectedCalculatedAt = new DateTime(2022, 5, 14, 8, 16, 53);
            var expectedPostalCode = new PostalCode("A100");
            var expectedSalary = new AnnualIncome(10000);
            var expectedTaxAmount = 0;

            var result = new TaxCalculationResultBuilder().BuildWithDefaultValues();

            Expect(result)
                .Not.To.Be.Null()
                .And
                .To.Intersection.Equal(new
                {
                    CalculatedAt = expectedCalculatedAt,
                    PostalCode = expectedPostalCode,
                    Salary = expectedSalary,
                    TaxAmount = expectedTaxAmount,
                });
        }

        [Test]
        public void TaxCalculationResult_Throws_WithEmptyPostalCode()
        {
            Func<TaxCalculationResult> sut = () => CreateTaxCalculationResultWithEmptyPostalCode();

            Expect(sut)
                .To.Throw<ArgumentException>()
                .With.Message
                .Equal.To("Required input postalCode was empty. (Parameter 'postalCode')");
        }

        [Test]
        public void TaxCalculationResult_Throws_WithShortPostalCode()
        {
            Func<TaxCalculationResult> sut = () => CreateTaxCalculationResultWithShortPostalCode();
            Expect(sut)
                .To.Throw<ArgumentException>()
                .With.Message
                .Equal.To("Invalid PostalCode: code must be 4 characters long. (Parameter 'code')");
        }

        [Test]
        public void TaxCalculationResult_Throws_WithLongPostalCode()
        {
            Func<TaxCalculationResult> sut = () => CreateTaxCalculationResultWithLongPostalCode();
            Expect(sut)
                .To.Throw<ArgumentException>()
                .With.Message
                .Equal.To("Invalid PostalCode: code must be 4 characters long. (Parameter 'code')");
        }

        private TaxCalculationResult CreateTaxCalculationResultWithEmptyPostalCode()
        {
            return new TaxCalculationResultBuilder()
                .WithPostalCode(string.Empty)
                .Build();
        }

        private TaxCalculationResult CreateTaxCalculationResultWithShortPostalCode()
        {
            return new TaxCalculationResultBuilder()
                .WithPostalCode("234")
                .Build();
        }

        private TaxCalculationResult CreateTaxCalculationResultWithLongPostalCode()
        {
            return new TaxCalculationResultBuilder()
                .WithPostalCode("56789")
                .Build();
        }
    }
}
