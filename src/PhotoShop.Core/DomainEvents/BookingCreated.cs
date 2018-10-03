using System;

namespace PhotoShop.Core.DomainEvents
{
    public class BookingCreated: DomainEvent
    {
        public BookingCreated(Guid bookingId, string name)
        {
            BookingId = bookingId;
            Name = name;
        }

		public Guid BookingId { get; set; }
        public string Name { get; set; }
    }
}
