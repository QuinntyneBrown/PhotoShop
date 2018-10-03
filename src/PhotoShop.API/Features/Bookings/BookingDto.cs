using PhotoShop.Core.Models;
using System;

namespace PhotoShop.API.Features.Bookings
{
    public class BookingDto
    {        
        public Guid BookingId { get; set; }
        
        public static BookingDto FromBooking(Booking booking)
            => new BookingDto
            {
                BookingId = booking.BookingId                
            };
    }
}
