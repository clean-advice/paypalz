using Ardalis.GuardClauses;
using Devlin.PayPalz.Core.TaxCalculation;
using Devlin.PayPalz.SharedKernel.Interfaces;

namespace Devlin.PayPalz.Application.TaxCalculationTypeMappings.Queries
{
    public class TaxCalculationTypeMappingByIdQuery : ITaxCalculationTypeMappingByIdQuery
    {
        private readonly IReadRepository<TaxCalculationTypeMapping> repository;

        public TaxCalculationTypeMappingByIdQuery(IReadRepository<TaxCalculationTypeMapping> repository)
        {
            this.repository = repository;
        }

        public async Task<TaxCalculationTypeMappingDto> GetByIdAsync(int id)
        {
            var calculationTypeMapping = await repository.GetByIdAsync(id);
            Guard.Against.NotFound(id, calculationTypeMapping, nameof(calculationTypeMapping));

            TaxCalculationTypeMappingDto calculationTypeMappingDto = new TaxCalculationTypeMappingDto()
            {
                PostalCode = calculationTypeMapping.PostalCode.Code,
                TaxCalculationType = calculationTypeMapping.TaxCalculationType.Name,
            };

            return calculationTypeMappingDto;
        }
    }
}
