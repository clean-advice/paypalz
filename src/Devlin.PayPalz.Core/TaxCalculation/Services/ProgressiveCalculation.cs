namespace Devlin.PayPalz.Core.TaxCalculation.Services
{
    internal class ProgressiveCalculation : ITaxCalculationServiceType
    {
        private readonly List<ProgressiveTaxBrackets> taxBrackets;
        private readonly bool usePatternMatching = false;

        public ProgressiveCalculation(List<ProgressiveTaxBrackets> taxBrackets)
        {
            this.taxBrackets = taxBrackets;
        }

        public decimal CalculateTax(decimal annualIncome)
        {
            decimal taxAmount = 0m;
            if (annualIncome == 0)
            {
                return taxAmount;
            }

            foreach (var item in CalculateTaxYield(annualIncome))
            {
                taxAmount += item;
            }

            return taxAmount;
        }

        private decimal CalculateTax(decimal taxableAmount, decimal taxRate)
        {
            decimal tax = taxableAmount * taxRate;
            return tax;
        }

        private IEnumerable<decimal> CalculateTaxYield(decimal annualIncome)
        {
            bool calculationCompleted = false;
            int currentBracketIndex = 0;

            while (!calculationCompleted)
            {
                yield return CalculateTax(GetTaxableAmount(annualIncome, currentBracketIndex), taxBrackets[currentBracketIndex].TaxRate);
                calculationCompleted = annualIncome < taxBrackets[currentBracketIndex].UpperBound;
                currentBracketIndex++;
            }
        }

        private decimal GetTaxableAmount(decimal annualIncome, int taxBracket)
        {
            if (annualIncome > taxBrackets[taxBracket].UpperBound)
            {
                return taxBrackets[taxBracket].BandTaxableAmount;
            }

            decimal lowerBound = taxBracket == 0 ? 0 : taxBrackets[taxBracket - 1].UpperBound;
            decimal taxableAmount = annualIncome - lowerBound;

            return taxableAmount;
        }
    }
}
