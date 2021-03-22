using LawProject.Application.Events;
using LawProject.Domain.Events.Products;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LawProject.Application.Features.Products.EvenHandlers
{
    public class ProductCompletedEvenHandler : INotificationHandler<DomainEventNotification<ProductCompletedEvent>>
    {
        private readonly ILogger<ProductCompletedEvenHandler> _logger;

        public ProductCompletedEvenHandler(ILogger<ProductCompletedEvenHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<ProductCompletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("LawProject Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
