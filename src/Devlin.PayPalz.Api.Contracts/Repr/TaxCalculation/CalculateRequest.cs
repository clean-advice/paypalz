using System.ComponentModel.DataAnnotations;

namespace Devlin.PayPalz.Api.Endpoints.TaxCalculator
{
    public class CalculateRequest
    {
        public const string Route = "/TaxCalculator/";

        [Required]
        public string? PostalCode { get; set; }

        public decimal Salary { get; set; }
    }
}
