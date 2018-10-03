using PhotoShop.Core.Common;
using System;
using System.Collections.Generic;

namespace PhotoShop.Core.Interfaces
{
    public interface IRepository
    {
        TAggregateRoot[] Query<TAggregateRoot>() where TAggregateRoot : Entity;

        TAggregateRoot Query<TAggregateRoot>(Guid id) where TAggregateRoot : Entity;

        TAggregateRoot[] Query<TAggregateRoot>(IEnumerable<Guid> ids) where TAggregateRoot : Entity;

        void OnNext(EventStoreChanged onNext);
    }
}
