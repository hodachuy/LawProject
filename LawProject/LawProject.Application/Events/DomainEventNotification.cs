using LawProject.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Application.Events
{
    public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : DomainEvent
    {
        public DomainEventNotification(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }

        public TDomainEvent DomainEvent { get; }
    }
}
