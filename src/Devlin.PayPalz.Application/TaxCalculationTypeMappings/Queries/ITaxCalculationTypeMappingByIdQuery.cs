
namespace Devlin.PayPalz.Application.TaxCalculationTypeMappings.Queries
{
    public interface ITaxCalculationTypeMappingByIdQuery
    {
        Task<TaxCalculationTypeMappingDto> GetByIdAsync(int id);
    }
}