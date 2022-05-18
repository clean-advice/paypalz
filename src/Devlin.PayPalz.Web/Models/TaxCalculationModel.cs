using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devlin.PayPalz.Web.Models
{
    public class TaxCalculationModel
    {
        [Required, StringLength(4, MinimumLength = 4)]
        public string? PostalCode { get; set; }

        [Required]
        [Range(0.00, 999999999999999999.99)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public string? Salary { get; set; }
    }
}
