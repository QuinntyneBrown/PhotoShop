using System;

namespace PhotoShop.Core.DomainEvents
{
    public class BlogNameChanged: DomainEvent
    {
        public BlogNameChanged(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
