using MediatR;

namespace Devlin.PayPalz.SharedKernel
{
    public interface IBaseDomainEvent : INotification

    {
        DateTime DateOccurred { get; }
    }
}