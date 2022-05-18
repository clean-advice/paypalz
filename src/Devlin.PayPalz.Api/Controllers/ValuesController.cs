using Devlin.PayPalz.Application.TaxCalculations.Commands;
using Devlin.PayPalz.Core.TaxCalculation;
using Devlin.PayPalz.Core.TaxCalculation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devlin.PayPalz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<TaxController> _logger;
        private readonly TaxCalculationService _taxCalculationService;
        private readonly ITaxCalculationCommand _calculationCommand;

        public ValuesController(ILogger<TaxController> logger, TaxCalculationService taxCalculationService, ITaxCalculationCommand calculationCommand)
        {
            _logger = logger;
            _taxCalculationService = taxCalculationService;
            _calculationCommand = calculationCommand;
        }

        [HttpPost(Name = nameof(SayHello))]
        public async Task<ActionResult<string>> SayHello(
            [FromBody] string request,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(request))
            {
                ModelState.AddModelError(nameof(request), $"{nameof(request)} must be provided.");
                return BadRequest(ModelState);
            }

            _taxCalculationService.CalculateTax(new PostalCode("A100"), 12345);
            _calculationCommand.CalculateTax("A100", 12345);

            _logger.LogDebug("Found :: {Response}", request);
            return Ok($"Hello {request}");
        }
    }
}
