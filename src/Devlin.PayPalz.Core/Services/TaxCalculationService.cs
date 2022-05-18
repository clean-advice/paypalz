using Devlin.PayPalz.Core.TaxCalculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devlin.PayPalz.Core.Services
{
    public class TaxCalculationService
    {
        public TaxCalculationResult CalculateTax(PostalCode postalCode, decimal incomeAmount)
        {
            return new TaxCalculationResult(DateTime.UtcNow, postalCode, new Salary(incomeAmount), new TaxPayable(0));
        }
    }
}
