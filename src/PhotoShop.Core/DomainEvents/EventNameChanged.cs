using System;

namespace PhotoShop.Core.DomainEvents
{
    public class EventNameChanged: DomainEvent
    {
        public EventNameChanged(string name)
        {
             Name = name;
        }

        public string Name { get; set; }
    }
}
