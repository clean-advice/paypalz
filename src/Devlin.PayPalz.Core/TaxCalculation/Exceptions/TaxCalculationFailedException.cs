using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devlin.PayPalz.Core.TaxCalculation.Exceptions
{
    public class TaxCalculationFailedException : Exception
    {
        public TaxCalculationFailedException() { }

        public TaxCalculationFailedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
