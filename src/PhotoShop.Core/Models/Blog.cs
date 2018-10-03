using PhotoShop.Core.Common;
using PhotoShop.Core.DomainEvents;
using System;

namespace PhotoShop.Core.Models
{
    public class Blog: Entity
    {
        public Blog(string name)
            => Apply(new BlogCreated(BlogId,name));

        public Guid BlogId { get; set; } = Guid.NewGuid();          
		public string Name { get; set; }        
		public BlogStatus Status { get; set; }
		public int Version { get; set; }

        protected override void EnsureValidState()
        {
            
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case BlogCreated blogCreated:
                    Name = blogCreated.Name;
					BlogId = blogCreated.BlogId;
					Status = BlogStatus.Active;
                    break;

                case BlogNameChanged blogNameChanged:
                    Name = blogNameChanged.Name;
					Version++;
                    break;

                case BlogRemoved blogRemoved:
                    Status = BlogStatus.InActive;
					Version++;
                    break;
            }
        }

        public void ChangeName(string name)
            => Apply(new BlogNameChanged(name));

        public void Remove()
            => Apply(new BlogRemoved());
    }

    public enum BlogStatus
    {
        Active,
        InActive
    }
}
