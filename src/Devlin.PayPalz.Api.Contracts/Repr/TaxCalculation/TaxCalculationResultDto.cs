namespace Devlin.PayPalz.Application.TaxCalculations.Commands
{
    public class TaxCalculationResultDto
    {
        public string PostalCode { get; set; }
        public decimal Salary { get; set; }
        public decimal TaxPayable { get; set; }
    }
}
