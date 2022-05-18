using Devlin.PayPalz.Api.Endpoints.TaxCalculator;
using Devlin.PayPalz.Application.TaxCalculations.Commands;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Devlin.PayPalz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ITaxCalculationCommand _calculationCommand;

        public TaxController(ILogger<TaxController> logger, ITaxCalculationCommand calculationCommand)
        {
            _calculationCommand = calculationCommand;
        }

        [HttpPost(Name = nameof(Calculate))]
        [SwaggerOperation(
            Summary = "Performs the tax calculation based on the annual salary for the postal code provided.",
            Description = "Performs tax calculation.",
            OperationId = "Tax.Calculate",
            Tags = new[] { "TaxCalculatorEndpoint" })
        ]
        public async Task<ActionResult<CalculateResponse>> Calculate(
            [FromBody] CalculateRequest request,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(request.PostalCode))
            {
                ModelState.AddModelError(nameof(request.PostalCode), $"{nameof(request.PostalCode)} must be provided.");
                return BadRequest(ModelState);
            }

            TaxCalculationResultDto? resultDto = await _calculationCommand.CalculateTax(request.PostalCode, request.Salary);
            CalculateResponse response = new CalculateResponse(resultDto);

            return Ok(response);
        }
    }
}