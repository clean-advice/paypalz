using Devlin.PayPalz.Application.TaxCalculationTypeMappings.Queries;
using Devlin.PayPalz.Application.UnitTests.ObjectMother;
using Devlin.PayPalz.Core.TaxCalculation;
using Devlin.PayPalz.Core.TaxCalculation.Events;
using Devlin.PayPalz.Infrastructure.Data;
using Devlin.PayPalz.SharedKernel;
using Devlin.PayPalz.SharedKernel.Interfaces;
using NExpect;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NExpect.Expectations;

namespace Devlin.PayPalz.Application.UnitTests.TaxCalculation
{
    [TestFixture]
    public class TaxCalculationCommandTestsTests : BaseEfRepoTestFixture
    {
        private EfRepository<TaxCalculationResult> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = GetRepository();
        }

        [Test]
        public async Task TaxCalculationResult_Should_Save_TaxCalculationValues()
        {
            var taxCalculationResult = new TaxCalculationResultBuilder().BuildWithDefaultValues();
            await _repository.AddAsync(taxCalculationResult);

            var newtaxCalculationResult = (await _repository.ListAsync())
                .FirstOrDefault();

            Expect(newtaxCalculationResult)
                .Not.To.Be.Null()
                .And
                .To.Be.An.Instance.Of<TaxCalculationResult>();
        }

        [Test]
        public async Task TaxCalculationResult_Should_Save_TaxCalculationValues_WithNewId()
        {
            var taxCalculationResult = new TaxCalculationResultBuilder().BuildWithDefaultValues();
            await _repository.AddAsync(taxCalculationResult);

            var newtaxCalculationResult = (await _repository.ListAsync())
                .FirstOrDefault();

            Expect(newtaxCalculationResult?.Id)
                .Not.To.Be.Null()
                .And
                .To.Be.An.Instance.Of<int>()
                .And
                .To.Be.Greater.Than(0);
        }

        [Test]
        public void TaxCalculationResult_UpdateTaxPayable_Raises_TaxPayableUpdatedEvent()
        {
            var newtaxCalculationResult = new TaxCalculationResultBuilder().Build();

            newtaxCalculationResult.UpdateTaxPayable(200m);

            Expect(newtaxCalculationResult.Events.FirstOrDefault())
                .Not.To.Be.Null()
                .And
                .To.Be.An.Instance.Of<TaxPayableUpdatedEvent>();
        }

        [Test]
        public void TaxCalculationResult_UpdateTaxPayable_Raises_TaxPayableUpdatedEvent_ExactlyOnce()
        {
            var newtaxCalculationResult = new TaxCalculationResultBuilder().Build();

            newtaxCalculationResult.UpdateTaxPayable(20m);

            Expect(newtaxCalculationResult.Events.Count)
                .To.Be.Equal.To(1);
        }

        [Test]
        public void TaxCalculationResult_UpdateTaxPayable_Raises_TaxPayableUpdatedEvent_EveryTimeCalled()
        {
            var newtaxCalculationResult = new TaxCalculationResultBuilder().Build();

            newtaxCalculationResult.UpdateTaxPayable(200m);
            newtaxCalculationResult.UpdateTaxPayable(220m);
            newtaxCalculationResult.UpdateTaxPayable(202m);
            newtaxCalculationResult.UpdateTaxPayable(201m);
            newtaxCalculationResult.UpdateTaxPayable(203m);

            Expect(newtaxCalculationResult.Events.Count)
                .To.Be.Equal.To(5);
        }
    }
}
