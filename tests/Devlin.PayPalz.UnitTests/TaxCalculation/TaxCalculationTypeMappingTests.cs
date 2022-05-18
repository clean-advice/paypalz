using Devlin.PayPalz.Core.TaxCalculation;
using Devlin.PayPalz.Domain.UnitTests.ObjectMother;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace Devlin.PayPalz.Domain.UnitTests.CoreTests.TaxCalculation
{
    [TestFixture]
    public class TaxCalculationTypeMappingTests
    {
        [Test]
        public void TaxCalculationTypeMapping_CanBeInitialized_WithValidDefaultValues()
        {

            var expectedId = 1;
            var expectedPostalCode = new PostalCode("A100");
            var expectedCalculationType = TaxCalculationType.FromValue(0);

            var result = new TaxCalculationTypeMappingBuilder().BuildWithDefaultValues();

            Expect(result)
                .Not.To.Be.Null()
                .And
                .To.Intersection.Equal(new
                {
                    Id = expectedId,
                    PostalCode = expectedPostalCode,
                    CalculationType = expectedCalculationType,
                });
        }

        [Test]
        public void TaxCalculationTypeMapping_Throws_WithEmptyPostalCode()
        {
            Func<TaxCalculationTypeMapping> sut = () => CreateTaxCalculationTypeMappingWithEmptyPostalCode();

            Expect(sut)
                .To.Throw<ArgumentException>()
                .With.Message
                .Equal.To("Required input postalCode was empty. (Parameter 'postalCode')");
        }

        [Test]
        public void TaxCalculationTypeMapping_Throws_WithShortPostalCode()
        {
            Func<TaxCalculationTypeMapping> sut = () => CreateTaxCalculationTypeMappingWithShortPostalCode();
            Expect(sut)
                .To.Throw<ArgumentException>()
                .With.Message
                .Equal.To("Invalid PostalCode: code must be 4 characters long. (Parameter 'code')");
        }

        [Test]
        public void TaxCalculationTypeMapping_Throws_WithLongPostalCode()
        {
            Func<TaxCalculationTypeMapping> sut = () => CreateTaxCalculationTypeMappingWithLongPostalCode();
            Expect(sut)
                .To.Throw<ArgumentException>()
                .With.Message
                .Equal.To("Invalid PostalCode: code must be 4 characters long. (Parameter 'code')");
        }

        private TaxCalculationTypeMapping CreateTaxCalculationTypeMappingWithEmptyPostalCode()
        {
            return new TaxCalculationTypeMappingBuilder()
                .WithPostalCode(string.Empty)
                .Build();
        }

        private TaxCalculationTypeMapping CreateTaxCalculationTypeMappingWithShortPostalCode()
        {
            return new TaxCalculationTypeMappingBuilder()
                .WithPostalCode("234")
                .Build();
        }

        private TaxCalculationTypeMapping CreateTaxCalculationTypeMappingWithLongPostalCode()
        {
            return new TaxCalculationTypeMappingBuilder()
                .WithPostalCode("56789")
                .Build();
        }
    }
}
