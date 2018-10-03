namespace PhotoShop.Core.DomainEvents
{
    public class MenteeRegistrationRequested: DomainEvent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
