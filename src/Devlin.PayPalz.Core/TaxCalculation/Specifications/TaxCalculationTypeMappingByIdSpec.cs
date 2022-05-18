using Ardalis.Specification;

namespace Devlin.PayPalz.Core.TaxCalculation.Specifications
{
    internal class TaxCalculationTypeMappingByIdSpec : Specification<TaxCalculationTypeMapping>, ISingleResultSpecification
    {
        public TaxCalculationTypeMappingByIdSpec(int mappingId)
        {
            Query.Where(mapping => mapping.Id == mappingId);
        }
    }
}
