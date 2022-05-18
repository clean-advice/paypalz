using Devlin.PayPalz.Application.TaxCalculationTypeMappings.Queries;
using Devlin.PayPalz.Application.UnitTests.ObjectMother;
using Devlin.PayPalz.Core.TaxCalculation;
using Devlin.PayPalz.SharedKernel.Interfaces;
using NExpect;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using static NExpect.Expectations;

namespace Devlin.PayPalz.Application.UnitTests.TaxCalculation
{
    [TestFixture]
    public class TaxCalculationTypeMappingByIdQueryTests
    {

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public async Task Should_Return_CalculationTypeMapping()
        {
            var expectedPostalCode = new PostalCode("A100");
            var expectedCalculationType = TaxCalculationType.FromValue(0);

            IReadRepository<TaxCalculationTypeMapping> repository = Substitute.For<IReadRepository<TaxCalculationTypeMapping>>();
            repository
                .GetByIdAsync(Arg.Any<int>())
                .Returns(new TaxCalculationTypeMappingBuilder().BuildWithDefaultValues());
            var query = new TaxCalculationTypeMappingByIdQuery(repository);

            var result = await query.GetByIdAsync(1);

            Expect(result)
                .Not.To.Be.Null()
                .And
                .To.Be.An.Instance.Of<TaxCalculationTypeMappingDto>()
                .And
                .To.Intersection.Equal(new
                {
                    PostalCode = expectedPostalCode.Code,
                    CalculationType = expectedCalculationType.Name,
                });

        }
    }
}
