using System;

namespace PhotoShop.Core.DomainEvents
{
    public class ArticleCreated: DomainEvent
    {
        public ArticleCreated(Guid articleId, string name)
        {
            ArticleId = articleId;
            Name = name;
        }

		public Guid ArticleId { get; set; }
        public string Name { get; set; }
    }
}
