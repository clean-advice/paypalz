using Devlin.PayPalz.Core.TaxCalculation;
using Devlin.PayPalz.Core.TaxCalculation.Services;
using Devlin.PayPalz.Domain.UnitTests.ObjectMother;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace Devlin.PayPalz.UnitTests.CoreTests.TaxCalculation
{
    [TestFixture]
    public class TaxCalculationServiceTests
    {

        [SetUp]
        public void SetUp()
        {

        }

        private ITaxCalculationService CreateService()
        {
            return new TaxCalculationService();
        }

        [Test]
        public void TaxCalculationService_CalculateTax_IsNotNullForValidInput()
        {
            // Arrange
            var service = this.CreateService();
            PostalCode postalCode = new PostalCode("A100");
            AnnualIncome annualIncome = new AnnualIncome(0);

            // Act
            var result = service.CalculateTax(
                postalCode,
                annualIncome);

            // Assert
            Expect(result)
                .Not.To.Be.Null();
        }

        [Test]
        public void TaxCalculationService_CalculateTax_TaxPayableAmountIsZeroForZeroIncome()
        {
            // Arrange
            var service = this.CreateService();
            PostalCode postalCode = new PostalCode("A100");
            AnnualIncome incomeAmount = new AnnualIncome(0);

            // Act
            var result = service.CalculateTax(
                postalCode,
                incomeAmount);

            // Assert
            Expect(result.TaxPayable.Amount).To.Equal(0);
        }

        [Test]
        public void TaxCalculationService_CalculateTax_TypeTesting()
        {
            // Arrange
            var service = this.CreateService();
            PostalCode postalCode = new PostalCode("A100");
            AnnualIncome incomeAmount = new AnnualIncome(0);

            // Act
            var result = service.CalculateTax(
                postalCode,
                incomeAmount);

            // Assert
            Expect(result).To.Be.An.Instance.Of<TaxCalculationResult>();
        }

        [Test]
        [TestCaseSource(typeof(TaxCalculationServiceTestData), nameof(TaxCalculationServiceTestData.FlatValueTestCases))]
        public decimal TaxCalculationService_CalculateTax_CalculatesFlatValue_TaxPayable(string code, decimal annualIncome)
        {
            // Arrange
            var service = this.CreateService();
            PostalCode postalCode = new PostalCode(code);
            AnnualIncome incomeAmount = new AnnualIncome(annualIncome);

            // Act
            var result = service.CalculateTax(
                postalCode,
                incomeAmount);

            // Assert
            Expect(result).To.Be.An.Instance.Of<TaxCalculationResult>();
            return result.TaxPayable.Amount;
        }

        [Test]
        [TestCaseSource(typeof(TaxCalculationServiceTestData), nameof(TaxCalculationServiceTestData.FlatRateTestCases))]
        public decimal TaxCalculationService_CalculateTax_CalculatesFlatRate_TaxPayable(string code, decimal annualIncome)
        {
            // Arrange
            var service = this.CreateService();
            PostalCode postalCode = new PostalCode(code);
            AnnualIncome incomeAmount = new AnnualIncome(annualIncome);

            // Act
            var result = service.CalculateTax(
                postalCode,
                incomeAmount);

            // Assert
            Expect(result).To.Be.An.Instance.Of<TaxCalculationResult>();
            return result.TaxPayable.Amount;
        }

        [Test]
        [TestCaseSource(typeof(TaxCalculationServiceTestData), nameof(TaxCalculationServiceTestData.ProgressiveTaxTestCases))]
        public decimal TaxCalculationService_CalculateTax_CalculatesProgressiveTax_TaxPayable(string code, decimal annualIncome)
        {
            // Arrange
            var service = this.CreateService();
            PostalCode postalCode = new PostalCode(code);
            AnnualIncome incomeAmount = new AnnualIncome(annualIncome);

            // Act
            var result = service.CalculateTax(
                postalCode,
                incomeAmount);

            // Assert
            Expect(result).To.Be.An.Instance.Of<TaxCalculationResult>();
            return result.TaxPayable.Amount;
        }
    }
}
