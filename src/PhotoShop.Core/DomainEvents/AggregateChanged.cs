using System;

namespace PhotoShop.Core.DomainEvents
{
    public class AggregateChanged: DomainEvent
    {
        public Guid AggregateId { get; set; }
    }
}
