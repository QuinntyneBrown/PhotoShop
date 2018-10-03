using PhotoShop.Core.Common;
using PhotoShop.Core.DomainEvents;
using System;

namespace PhotoShop.Core.Models
{
    public class Article: Entity
    {
        public Article(string name)
            => Apply(new ArticleCreated(ArticleId, name));

        public Guid ArticleId { get; set; } = Guid.NewGuid();          
		public string Title { get; set; }
        public string Body { get; set; }
        public string AuthorName { get; set; }
        public string Slug { get; set; }
        public DateTime PublishedOn { get; set; }
        public ArticleStatus Status { get; set; }
		public int Version { get; set; }

        protected override void EnsureValidState()
        {
            
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case ArticleCreated articleCreated:
                    Title = articleCreated.Name;
					ArticleId = articleCreated.ArticleId;
					Status = ArticleStatus.Active;
                    break;

                case ArticleRemoved articleRemoved:
                    Status = ArticleStatus.InActive;
					Version++;
                    break;
            }
        }
        
        public void Remove()
            => Apply(new ArticleRemoved());
    }

    public enum ArticleStatus
    {
        Active,
        Published,
        Draft,
        InActive
    }
}
