using System;

namespace PhotoShop.Core.DomainEvents
{
    public class BlogCreated: DomainEvent
    {
        public BlogCreated(Guid blogId, string name)
        {
            BlogId = blogId;
            Name = name;
        }

		public Guid BlogId { get; set; }
        public string Name { get; set; }
    }
}
