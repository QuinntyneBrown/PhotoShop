using PhotoShop.API.Features.Addresses;
using PhotoShop.Core.Models;
using System;
using System.Collections.Generic;

namespace PhotoShop.API.Features.Events
{
    public class EventDto
    {        
        public Guid EventId { get; set; }
        public Guid? ParentEventId { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public IEnumerable<EventDto> Events { get; set; }
        public static EventDto FromEvent(Event @event)
            => new EventDto
            {
                EventId = @event.EventId,
                Name = @event.Name
            };
    }
}
