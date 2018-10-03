using PhotoShop.Core.Models;

namespace PhotoShop.Core.Common
{
    public class EventStoreChanged
    {
        public EventStoreChanged(StoredEvent @event) => Event = @event;
        public StoredEvent Event { get; }
    }
}
