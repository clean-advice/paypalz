using Devlin.PayPalz.Core.TaxCalculation;
using Devlin.PayPalz.Core.TaxCalculation.Services;
using Devlin.PayPalz.SharedKernel.Interfaces;

namespace Devlin.PayPalz.Application.TaxCalculations.Commands
{
    public class TaxCalculationCommand : ITaxCalculationCommand
    {
        private readonly ITaxCalculationService _taxCalculationService;

        private readonly IRepository<TaxCalculationResult> _repository;

        public TaxCalculationCommand(
            ITaxCalculationService taxCalculationService,
            IRepository<TaxCalculationResult> repository)
        {
            _taxCalculationService = taxCalculationService;
            _repository = repository;
        }

        public async Task<TaxCalculationResultDto> CalculateTax(
            string postalCode,
            decimal annualSalary,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            TaxCalculationResult? calculationResult = _taxCalculationService.CalculateTax(new PostalCode(postalCode), new AnnualIncome(annualSalary));
            await _repository.AddAsync(calculationResult, cancellationToken);

            var taxCalculationResultDto = new TaxCalculationResultDto()
                {
                    PostalCode = calculationResult.PostalCode.Code,
                    Salary = annualSalary,
                    TaxPayable = calculationResult.TaxPayable.Amount
                };

            return taxCalculationResultDto;
        }
    }
}
