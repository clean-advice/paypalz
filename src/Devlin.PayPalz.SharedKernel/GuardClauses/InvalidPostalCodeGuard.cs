namespace Ardalis.GuardClauses
{
    public static class InvalidPostalCodeGuard
    {
        public static string InvalidPostalCode(this IGuardClause guardClause, string postalCode, string parameterName)
        {
            Guard.Against.NullOrEmpty(postalCode, nameof(postalCode));

            if (postalCode?.ToCharArray().Length != 4) // Max length should come from config
            {
                throw new ArgumentException($"Invalid PostalCode: {parameterName} must be 4 characters long.", parameterName);
            }

            // Should postal code be validated against the list of postal codes and tax types?
            // Or, do we allow unmapped valid postal code and throw Domain Exception when not mapped?
            // Either way, this needs to be read from DB and I cannot do that here, soo, decision forced on me :P
            var validPostalCodes = new List<string>{ "7441", "A100", "7000", "1000" };
            if (!validPostalCodes.Any(p => p == postalCode))
            {
                throw new ArgumentException($"Invalid PostalCode: {parameterName} must be set up as tax calculation type.", parameterName);
            }

            return postalCode;
        }
    }
}
