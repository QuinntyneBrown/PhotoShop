using System;

namespace PhotoShop.Core.DomainEvents
{
    public class ArticleNameChanged: DomainEvent
    {
        public ArticleNameChanged(Guid articleNameChangedId, string name)
        {
            ArticleNameChangedId = articleNameChangedId;
            Name = name;
        }

		public Guid ArticleNameChangedId { get; set; }
        public string Name { get; set; }
    }
}
