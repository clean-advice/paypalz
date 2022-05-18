namespace Devlin.PayPalz.SharedKernel;

public abstract class BaseDomainEvent : IBaseDomainEvent
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
