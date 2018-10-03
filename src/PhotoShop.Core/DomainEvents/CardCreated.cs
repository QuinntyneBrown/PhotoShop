using System;

namespace PhotoShop.Core.DomainEvents
{
    public class CardCreated: DomainEvent
    {
        public CardCreated(string name, Guid cardId)
        {
            Name = name;
            CardId = cardId;
        }
        public string Name { get; set; }
        public Guid CardId { get; set; }
    }
}
