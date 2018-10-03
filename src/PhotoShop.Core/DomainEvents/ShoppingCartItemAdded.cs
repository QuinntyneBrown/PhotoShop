using System;

namespace PhotoShop.Core.DomainEvents
{
    public class ShoppingCartItemAdded: DomainEvent
    {
        public ShoppingCartItemAdded(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
    }
}
