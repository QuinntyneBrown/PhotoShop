using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PhotoShop.Core.Interfaces;
using PhotoShop.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoShop.Infrastructure
{
    public class EventStoreMessageProcessor : BackgroundService
    {
        private readonly IEventStoreMessageQueue _queue;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private SemaphoreSlim _signal = new SemaphoreSlim(0);

        public EventStoreMessageProcessor(IEventStoreMessageQueue queue, IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;

            _queue = queue;
        }

        protected async override Task ExecuteAsync(
            CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var message = await _queue.TryDequeue();
                var context = default(IAppDbContext);
                
                if (!string.IsNullOrEmpty(message))
                {
                    var @event = JsonConvert.DeserializeObject<StoredEvent>(message);

                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        context = scope.ServiceProvider.GetRequiredService<IAppDbContext>();
                        context.StoredEvents.Add(@event);
                        await context.SaveChangesAsync(default(CancellationToken));
                    }
                }
            }
        }
    }
}
