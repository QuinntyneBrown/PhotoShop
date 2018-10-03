using System;

namespace PhotoShop.Core.DomainEvents
{
    public class AddressNameChanged: DomainEvent
    {
        public AddressNameChanged(string name)
        {
             Name = name;
        }

        public string Name { get; set; }
    }
}
