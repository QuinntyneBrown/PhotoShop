using PhotoShop.Core.Models;
using System;

namespace PhotoShop.API.Features.Attendees
{
    public class AttendeeDto
    {        
        public Guid AttendeeId { get; set; }
        public string FirstName { get; set; }

        public static AttendeeDto FromAttendee(Attendee attendee)
            => new AttendeeDto
            {
                AttendeeId = attendee.AttendeeId,
                FirstName = attendee.FirstName
            };
    }
}
