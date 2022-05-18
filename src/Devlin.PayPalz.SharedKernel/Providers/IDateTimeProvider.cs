namespace Devlin.PayPalz.SharedKernel.Providers
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}