using PhotoShop.Core.Common;
using PhotoShop.Core.DomainEvents;
using System;

namespace PhotoShop.Core.Models
{
    public class Card: Entity
    {
        public Card(string name)
            => Apply(new CardCreated(name,CardId));

        public Guid CardId { get; set; } = Guid.NewGuid();          
        public string Name { get; set; }        
        protected override void EnsureValidState()
        {
            
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case CardCreated cardCreated:
                    Name = cardCreated.Name;
                    CardId = cardCreated.CardId;
                    break;

                case CardNameChanged cardNameChanged:
                    Name = cardNameChanged.Name;
                    break;

                case CardRemoved cardRemoved:
                    
                    break;
            }
        }

        public void ChangeName(string name)
            => Apply(new CardNameChanged(name));

        public void Remove()
            => Apply(new CardRemoved());
    }
}
