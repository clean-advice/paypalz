using Devlin.PayPalz.Application.TaxCalculations.Commands;

namespace Devlin.PayPalz.Api.Endpoints.TaxCalculator
{
    public class CalculateResponse
    {
        public TaxCalculationResultDto TaxCalculationResult { get; set; }

        public CalculateResponse(TaxCalculationResultDto taxCalculationResult)
        {
            TaxCalculationResult = taxCalculationResult;
        }
    }
}
