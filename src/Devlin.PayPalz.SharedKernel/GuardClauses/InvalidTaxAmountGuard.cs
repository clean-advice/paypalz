namespace Ardalis.GuardClauses
{
    public static class InvalidTaxAmountGuard
    {
        public static decimal InvalidTaxAmount(this IGuardClause guardClause, decimal taxAmount, decimal salary, string parameterName)
        {
            // Probably put this into own Guard clause implementation
            var compareToSalay = (Func<decimal, bool>)(x => x <= salary);
            Guard.Against.Null(taxAmount, parameterName);
            Guard.Against.Null(salary, nameof(salary));
            Guard.Against.InvalidInput(taxAmount, nameof(taxAmount), compareToSalay, $"{parameterName} can not be greater than the {nameof(salary)} amount.");

            return taxAmount;
        }
    }
}
