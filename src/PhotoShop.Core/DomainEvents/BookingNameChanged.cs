using System;

namespace PhotoShop.Core.DomainEvents
{
    public class BookingNameChanged: DomainEvent
    {
        public BookingNameChanged(Guid bookingNameChangedId, string name)
        {
            BookingNameChangedId = bookingNameChangedId;
            Name = name;
        }

		public Guid BookingNameChangedId { get; set; }
        public string Name { get; set; }
    }
}
