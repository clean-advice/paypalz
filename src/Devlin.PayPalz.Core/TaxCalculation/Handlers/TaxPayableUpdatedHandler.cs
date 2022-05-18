using Devlin.PayPalz.Core.TaxCalculation.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Devlin.PayPalz.Core.TaxCalculation.Handlers
{
    public class TaxPayableUpdatedHandler : INotificationHandler<TaxPayableUpdatedEvent>
    {
        private readonly ILogger<TaxPayableUpdatedHandler> _logger;

        public TaxPayableUpdatedHandler(ILogger<TaxPayableUpdatedHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(TaxPayableUpdatedEvent domainEvent, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Received {domainEvent}", domainEvent);

            // Publish to the message bus
            await Task.FromResult(1);
#pragma warning disable S3626 // For illustration purposes, no queuing currently implemented
            return;
#pragma warning restore S3626 // For illustration purposes, no queuing currently implemented
        }
    }
}
