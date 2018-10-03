﻿using PhotoShop.Core.Common;
using PhotoShop.Core.Interfaces;
using PhotoShop.Core.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace UnitTests
{

    public class MockEventStore : IEventStore
    {
        private readonly Subject<EventStoreChanged> _subject = new Subject<EventStoreChanged>();
        private readonly Dictionary<string, IEnumerable<object>> _state = new Dictionary<string, IEnumerable<object>>();

        public MockEventStore(Dictionary<string, IEnumerable<object>> state)
        {
            _state = state;
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        

        public async Task<Dictionary<string, IEnumerable<object>>> GetStateAsync()
        {
            return await Task.FromResult(_state);
        }

        public Task<IEnumerable<StoredEvent>> GetEvents()
        {
            throw new NotImplementedException();
        }

        public TAggregateRoot Load<TAggregateRoot>(Guid id) where TAggregateRoot : Entity
        {
            throw new NotImplementedException();
        }

        public Task PersistStateAsync()
        {
            throw new NotImplementedException();
        }

        public TAggregateRoot[] Query<TAggregateRoot>() where TAggregateRoot : Entity
        {
            throw new NotImplementedException();
        }

        public void Save(Entity aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(Action<EventStoreChanged> onNext)
        {
            _subject.Subscribe(onNext);
        }

        public ConcurrentDictionary<string, ConcurrentBag<Entity>> UpdateState<TAggregateRoot>(Type type, TAggregateRoot aggregateRoot, Guid aggregateId) where TAggregateRoot : Entity
        {
            throw new NotImplementedException();
        }
    }
}
