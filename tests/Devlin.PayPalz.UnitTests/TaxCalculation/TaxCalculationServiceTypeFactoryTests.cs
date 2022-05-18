using Devlin.PayPalz.Core.TaxCalculation.Services;
using Devlin.PayPalz.Domain.UnitTests.ObjectMother;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace Devlin.PayPalz.UnitTests.CoreTests.TaxCalculation
{
    [TestFixture]
    public class TaxCalculationServiceTypeFactoryTests
    {
        [TestCaseSource(typeof(CalculationFactoryTestData), nameof(CalculationFactoryTestData.TestCases))]
        [Test]
        public void TaxCalculationFactory_Create_Returns_ProgressiveCalculation(string postalCode)
        {
            var service = TaxCalculationFactory.Create(postalCode);

            Expect(service)
                .Not.To.Be.Null()
                .And
                .To.Be.An.Instance.Of<ProgressiveCalculation>();
        }

        [Test]
        public void TaxCalculationFactory_Create_Returns_FlatValueCalculation()
        {
            var service = TaxCalculationFactory.Create("A100");

            Expect(service)
                .Not.To.Be.Null()
                .And
                .To.Be.An.Instance.Of<FlatValueCalculation>();
        }

        [Test]
        public void TaxCalculationFactory_Create_Returns_FlatRateCalculation()
        {
            var service = TaxCalculationFactory.Create("7000");

            Expect(service)
                .Not.To.Be.Null()
                .And
                .To.Be.An.Instance.Of<FlatRateCalculation>();
        }

    }
}
